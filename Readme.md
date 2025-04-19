Cadastro de Usuários - API
<div> <img src="https://img.shields.io/badge/Concluido-green">
<img src="https://img.shields.io/github/languages/top/EversonSoucek/ControleUsuarios-api-aspnet">
<img src="https://img.shields.io/github/languages/code-size/EversonSoucek/ControleUsuarios-api-aspnet"> </div>

Este é um projeto de API de Cadastro de Usuários desenvolvida com ASP.NET Core 9. A API permite a criação, atualização, listagem e consulta de usuários. O projeto segue os princípios de Clean Architecture e utiliza FluentResults para tratar os retornos de forma consistente.

:hammer: Funcionalidades do projeto
- Listar todos os usuários
- Buscar usuário por ID
- Cadastrar novo usuário
- Atualizar dados de um usuário
- Validação de dados de entrada

:wrench: Técnicas e tecnologias utilizadas
⚙️ ASP.NET Core 9

🗄️ Entity Framework Core

💾 MySQL

📜 FluentResults (para gerenciamento de erros)

📝 Swagger (para documentação e testes da API)

🌍 DotEnv (para gerenciamento de variáveis de ambiente)

:file_folder: Acesso ao projeto
Para rodar o projeto localmente, siga os passos abaixo:

1. Clone o repositório:
git clone https://github.com/seu-usuario/cadastro-usuario-api.git

2. Configure as variáveis de ambiente:
Crie um arquivo .env na raiz do projeto e adicione sua conexão com o banco de dados MySQL:
DEFAULT_CONNECTION_STRING=server=localhost;database=CadastroUsuario;user=root;password=SuaSenha;

3.execute dotnet restore

4. Execute as migrations para criar o banco de dados:
dotnet ef database update

5. Execute o projeto:
dotnet watch run
Agora sua API estará rodando na URL: (http://localhost:5213/)

📌 Endpoints

GET	/usuario	Lista todos os usuários
GET	/usuario/{IdUsuario}	Retorna usuário por ID
PATCH /usuario/{IdUsuario} altere status do usuário
POST	/usuario	Cria um novo usuário
PUT	/usuario/{IdUsuario}	Atualiza os dados de um usuário

:pencil: Autor

<img src='https://avatars.githubusercontent.com/u/105561519?v=4' width=115><br> Everson Soucek
