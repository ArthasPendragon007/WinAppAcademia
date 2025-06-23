-- Tabela Academia
CREATE TABLE Academia (
    id_academia SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    endereco VARCHAR(255),
    telefone VARCHAR(15),
    email VARCHAR(100)
);

-- Tabela Aluno
CREATE TABLE Aluno (
    id_aluno SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    cpf VARCHAR(14) UNIQUE NOT NULL,
    data_nascimento DATE,
    sexo CHAR(1), -- 'M' para Masculino, 'F' para Feminino
    telefone VARCHAR(15),
    email VARCHAR(100),
    data_matricula DATE,
    status VARCHAR(10) CHECK (status IN ('ativo', 'inativo')) NOT NULL
);

-- Tabela Modalidade
CREATE TABLE Modalidade (
    id_modalidade SERIAL PRIMARY KEY,
    nome_modalidade VARCHAR(100) NOT NULL,
    descricao TEXT,
    valor_mensalidade DECIMAL(10, 2)
);

-- Tabela Aula
CREATE TABLE Aula (
    id_aula SERIAL PRIMARY KEY,
    id_modalidade INT NOT NULL,
    id_academia INT NOT NULL,
    id_professor INT NOT NULL,
    dia_semana VARCHAR(15), -- Ex: 'Segunda', 'Terça', etc.
    horario_inicio TIME,
    horario_fim TIME,
    capacidade_maxima INT,
	FOREIGN KEY (id_professor) REFERENCES Profesor(id_professor),
    FOREIGN KEY (id_modalidade) REFERENCES Modalidade(id_modalidade),
    FOREIGN KEY (id_academia) REFERENCES Academia(id_academia)
);

-- Tabela Matrícula
CREATE TABLE Matricula (
    id_matricula SERIAL PRIMARY KEY,
    id_aluno INT NOT NULL,
    id_modalidade INT NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE,
    status_matricula VARCHAR(10) CHECK (status_matricula IN ('ativa', 'cancelada')) NOT NULL,
    FOREIGN KEY (id_aluno) REFERENCES Aluno(id_aluno),
    FOREIGN KEY (id_modalidade) REFERENCES Modalidade(id_modalidade)
);

-- Tabela Frequência
CREATE TABLE Frequencia (
    id_frequencia SERIAL PRIMARY KEY,
    id_aluno INT NOT NULL,
    id_aula INT NOT NULL,
    data_aula DATE NOT NULL,
    presenca VARCHAR(3) CHECK (presenca IN ('sim', 'não')) NOT NULL,
    FOREIGN KEY (id_aluno) REFERENCES Aluno(id_aluno),
    FOREIGN KEY (id_aula) REFERENCES Aula(id_aula)
);

-- Tabela Pagamento
CREATE TABLE Pagamento (
    id_pagamento SERIAL PRIMARY KEY,
    id_aluno INT NOT NULL,
    data_pagamento DATE NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    status_pagamento VARCHAR(10) CHECK (status_pagamento IN ('pago', 'pendente')) NOT NULL,
    FOREIGN KEY (id_aluno) REFERENCES Aluno(id_aluno)
);

-- Tabela Equipamento
CREATE TABLE Equipamento (
    id_equipamento SERIAL PRIMARY KEY,
    id_academia INT NOT NULL,
    nome VARCHAR(255) NOT NULL,
    descricao TEXT,
    data_aquisicao DATE,
    estado VARCHAR(20) CHECK (estado IN ('novo', 'usado', 'manutenção', 'danificado')) NOT NULL,
    FOREIGN KEY (id_academia) REFERENCES Academia(id_academia)
);

-- Tabela Professor

CREATE TABLE Professor (
    id_professor SERIAL PRIMARY KEY,
    id_academia INT NOT NULL,
    id_modalidade INT NOT NULL,
    nome VARCHAR(255) NOT NULL,
    cpf VARCHAR(14) UNIQUE NOT NULL,
    data_nascimento DATE,
    sexo CHAR(1) CHECK (sexo IN ('M', 'F')),
    telefone VARCHAR(15),
    email VARCHAR(100),
    FOREIGN KEY (id_academia) REFERENCES Academia(id_academia),
    FOREIGN KEY (id_modalidade) REFERENCES Modalidade(id_modalidade)
);

--Data Base

--Procedure

-- Procedure: Registrar Pagamento 
-- Justificativa: Automatiza o processo de registro de pagamento para evitar erros manuais.

CREATE OR REPLACE PROCEDURE registrar_pagamento(p_id_aluno INT, p_valor DECIMAL, p_data DATE)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO Pagamento (id_aluno, data_pagamento, valor, status_pagamento)
    VALUES (p_id_aluno, p_data, p_valor, 'pago');
END;
$$;

-- Function: Calcular Total Pago por Aluno
--  Justificativa: Permite gerar relatorios financeiros, exibir saldo devedor ou historico de pagamentos no sistema.

CREATE OR REPLACE FUNCTION total_pago_por_aluno(p_id_aluno INT)
RETURNS DECIMAL AS $$
DECLARE
    total DECIMAL;
BEGIN
    SELECT SUM(valor) INTO total
    FROM Pagamento
    WHERE id_aluno = p_id_aluno AND status_pagamento = 'pago';

    RETURN COALESCE(total, 0);
END;
$$ LANGUAGE plpgsql;

-- Procedure: Atualizar Status da Matricula
--  Justificativa: Facilita o controle de status das matriculas de forma segura.

CREATE OR REPLACE PROCEDURE atualizar_status_matricula(p_id_matricula INT, p_status VARCHAR)
LANGUAGE plpgsql
AS $$
BEGIN
    IF p_status NOT IN ('ativa', 'cancelada') THEN
        RAISE EXCEPTION 'Status invalido!';
    END IF;

    UPDATE Matricula
    SET status_matricula = p_status
    WHERE id_matricula = p_id_matricula;
END;
$$;


--Trigger

-- Trigger: Atualizar Status do Aluno ao Cancelar Matricula
-- Justificativa: Mantem a consistencia automatica entre matriculas e o status geral do aluno.

CREATE OR REPLACE FUNCTION trigger_inativar_aluno()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.status_matricula = 'cancelada' THEN
        UPDATE Aluno
        SET status = 'inativo'
        WHERE id_aluno = NEW.id_aluno;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_inativar_aluno
AFTER UPDATE ON Matricula
FOR EACH ROW
WHEN (OLD.status_matricula <> 'cancelada' AND NEW.status_matricula = 'cancelada')
EXECUTE FUNCTION trigger_inativar_aluno();


--Views

-- View: Alunos Ativos e Suas Modalidades
-- Justificativa: Ãštil para consultas rÃ¡pidas de alunos ativos e suas atividades.

CREATE VIEW vw_alunos_ativos_modalidades AS
SELECT a.nome AS aluno_nome, m.nome_modalidade, ma.status_matricula
FROM Aluno a
JOIN Matricula ma ON a.id_aluno = ma.id_aluno
JOIN Modalidade m ON ma.id_modalidade = m.id_modalidade
WHERE a.status = 'ativo' AND ma.status_matricula = 'ativa';


-- View: Frequencia de Alunos por Aula
-- Justificativa: Auxilia a coordenação a avaliar o engajamento por aula e professor.

CREATE VIEW vw_frequencia_por_aula AS
SELECT
    f.id_aula,
    a.id_professor,
    COUNT(*) FILTER (WHERE f.presenca = 'sim') AS total_presentes
FROM Frequencia f
JOIN Aula a ON f.id_aula = a.id_aula
GROUP BY f.id_aula, a.id_professor;

-- View: Pagamentos Pendentes
--  Justificativa: Auxilia o setor financeiro a monitorar inadimplÃªncia.
CREATE VIEW vw_pagamentos_pendentes AS
SELECT p.id_aluno, a.nome AS aluno_nome, p.valor, p.data_pagamento
FROM Pagamento p
JOIN Aluno a ON p.id_aluno = a.id_aluno
WHERE p.status_pagamento = 'pendente';

--
select * from aluno;


call registrar_pagamento()
