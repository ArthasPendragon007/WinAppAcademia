

# WinAppAcademia

## Capa do Projeto

![Captura de tela 2025-06-23 031709](https://github.com/user-attachments/assets/30ce630f-ec83-44a7-a633-26bfa95077a1)

## Descrição
Um sistema desktop completo para gestão de frequência em academias, desenvolvido em C# com Windows Forms e persistência de dados utilizando SQL Server LocalDB.
## 📝 Visão Geral

O WinAppAcademia é uma aplicação desktop intuitiva projetada para otimizar o controle de frequência de alunos e a gestão de aulas em ambientes de academia. Com uma interface amigável baseada em Windows Forms, o sistema permite registrar a presença dos alunos, gerenciar aulas e ter uma visão clara do histórico de frequência.

**Funcionalidades Principais:**

* **Registro de Frequência:** Marque a presença de alunos em aulas específicas.
* **Gestão de Alunos:** Cadastro e manutenção de informações de alunos.
* **Gestão de Aulas:** Cadastro e manutenção de diferentes tipos de aulas.
* **Visualização Detalhada:** Acompanhe a frequência através de um DataGridView interativo.
* **Interface Intuitiva:** Design limpo e fácil de usar.

## ✨ Destaques Técnicos

* **Linguagem:** C#
* **Framework:** .NET (Windows Forms)
* **Banco de Dados:** PostgreSQL
* **Conectividade DB:** Npgsql (driver .NET para PostgreSQL)
* **Arquitetura:** Orientada a Objetos com padrão MVC (Modelo-Visão-Controlador) para separação de responsabilidades.
* **Controle de UI:** DataGridView, ComboBoxes, DateTimePicker para uma experiência de usuário eficiente.

## 🚀 Como Executar o Projeto

Siga os passos abaixo para configurar e rodar o WinAppAcademia em sua máquina local.

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (Versão 8.0 ou superior, compatível com o projeto `net8.0-windows`)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (ou superior, com as cargas de trabalho "Desenvolvimento para desktop com .NET")
* [PostgreSQL Server](https://www.postgresql.org/download/) (instalado e em execução)
* [pgAdmin](https://www.pgadmin.org/download/) (opcional, para gerenciar o banco de dados visualmente)

### Instalação

1.  **Clone o Repositório:**
    ```bash
    git clone [https://github.com/SeuUsuario/WinAppAcademia.git](https://github.com/SeuUsuario/WinAppAcademia.git) # Substitua pelo link do seu repositório
    cd WinAppAcademia
    ```

2.  **Abrir no Visual Studio:**
    * Abra o arquivo de solução `WinAppAcademia.sln` no Visual Studio.

3.  **Configurar o Banco de Dados PostgreSQL:**

    a.  **Crie o Banco de Dados:**
        * No seu servidor PostgreSQL (usando `psql` no terminal, pgAdmin, ou outra ferramenta), crie um novo banco de dados para o projeto. Ex: `academia_db`.

    b.  **Crie as Tabelas (se ainda não existirem):**
        * Execute os seguintes scripts SQL no do github se precisar de inserts `Insert` que do arquivo manualmente:


    c.  **Ajuste as Credenciais de Conexão no Código:**
        * No Visual Studio, navegue até a pasta `Utils` (ou onde seus arquivos `DBConfig.cs` e `Conexao.cs` estão localizados).
        * Abra o arquivo `DBConfig.cs` e/ou `Conexao.cs`.
        * Localize a seção onde a *string de conexão* é definida. Você precisará ajustar os valores , `user` e `Password` para corresponder à sua configuração do PostgreSQL.

        ```csharp
        internal class Conexao
        {
          public static string ObterStringConexao()
          {
              string host = ObterVariavelAmbiente("POSTGRES_HOST", "localhost");
              string user = ObterVariavelAmbiente("POSTGRES_USER", "postgres");
              string password = ObterVariavelAmbiente("POSTGRES_PASSWORD", "1234");
              string database = ObterVariavelAmbiente("POSTGRES_DATABASE", "academia");

              return $"Host={host};Username={user};Password={password};Database={database}";
        }

        private static string ObterVariavelAmbiente(string nome, string padrao)
        {
            return Environment.GetEnvironmentVariable(nome) ?? padrao;
        }
        ```

5.  **Restaurar Pacotes NuGet:**
    * No Visual Studio, vá em `Ferramentas` (Tools) > `Gerenciador de Pacotes NuGet` (NuGet Package Manager) > `Gerenciar Pacotes NuGet para a Solução...` (Manage NuGet Packages for Solution...).
    * Verifique se o pacote `Npgsql` está instalado. Se não estiver, instale-o. Geralmente, ao abrir a solução, o Visual Studio já tenta restaurar os pacotes necessários.

6.  **Compilar e Executar:**
    * Pressione `F5` ou clique no botão `Iniciar` (Start) no Visual Studio para compilar e executar o projeto.


## 📜 Feito por:

[Luiz Arthur, Vitor Nascimento e Guilherme]
