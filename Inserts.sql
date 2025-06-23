-- INSERÇÕES - SISTEMA DE ACADEMIA

-- 1. Academia
INSERT INTO Academia (nome, endereco, telefone, email) VALUES
('Academia StrongFit', 'Rua das Palmeiras, 123', '(11) 91234-5678', 'contato@strongfit.com'),
('Power Gym', 'Avenida Brasil, 456', '(21) 99876-5432', 'contato@powergym.com');

-- 2. Modalidade
INSERT INTO Modalidade (nome_modalidade, descricao, valor_mensalidade) VALUES
('Musculação', 'Treinamento de força e resistência', 150.00),
('Pilates', 'Exercícios de flexibilidade e postura', 200.00),
('Yoga', 'Exercícios de relaxamento e alongamento', 180.00);

-- 3. Aluno
INSERT INTO Aluno (nome, cpf, data_nascimento, sexo, telefone, email, data_matricula, status) VALUES
('João Silva', '123.456.789-00', '1990-05-10', 'M', '(11) 91234-0001', 'joao@gmail.com', '2024-01-15', 'ativo'),
('Maria Souza', '987.654.321-00', '1985-08-25', 'F', '(11) 91234-0002', 'maria@gmail.com', '2024-02-20', 'ativo'),
('Carlos Lima', '456.789.123-00', '1992-12-05', 'M', '(11) 91234-0003', 'carlos@gmail.com', '2024-03-10', 'inativo');

-- 4. Professor
INSERT INTO Professor (id_academia, id_modalidade, nome, cpf, data_nascimento, sexo, telefone, email) VALUES
(1, 1, 'Pedro Henrique', '321.654.987-00', '1980-07-12', 'M', '(11) 91234-0004', 'pedro@strongfit.com'),
(2, 2, 'Ana Paula', '654.321.987-00', '1990-11-30', 'F', '(21) 91234-0005', 'ana@powergym.com');

-- 5. Aula
INSERT INTO Aula (id_modalidade, id_academia, id_professor, dia_semana, horario_inicio, horario_fim, capacidade_maxima) VALUES
(1, 1, 1, 'Segunda', '08:00', '09:00', 20),
(2, 2, 2, 'Terça', '10:00', '11:00', 15),
(1, 1, 1, 'Quinta', '19:00', '20:00', 20);

-- 6. Matrícula
INSERT INTO Matricula (id_aluno, id_modalidade, data_inicio, data_fim, status_matricula) VALUES
(1, 1, '2024-01-15', NULL, 'ativa'),
(2, 2, '2024-02-20', NULL, 'ativa'),
(3, 1, '2024-03-10', '2024-06-10', 'cancelada');

-- 7. Frequência
INSERT INTO Frequencia (id_aluno, id_aula, data_aula, presenca) VALUES
(1, 1, '2024-06-01', 'sim'),
(1, 3, '2024-06-03', 'não'),
(2, 2, '2024-06-02', 'sim');

-- 8. Pagamento
INSERT INTO Pagamento (id_aluno, data_pagamento, valor, status_pagamento) VALUES
(1, '2024-06-01', 150.00, 'pago'),
(2, '2024-06-02', 200.00, 'pago'),
(3, '2024-06-03', 150.00, 'pendente');

-- 9. Equipamento
INSERT INTO Equipamento (id_academia, nome, descricao, data_aquisicao, estado) VALUES
(1, 'Esteira', 'Equipamento para corrida', '2023-01-10', 'novo'),
(1, 'Bicicleta Ergométrica', 'Equipamento para cardio', '2022-12-15', 'usado'),
(2, 'Máquina de Supino', 'Equipamento de musculação', '2023-05-20', 'manutenção');
