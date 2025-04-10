╔════════════════════════════════════════════╗
║              CognitusBackend              ║
╚════════════════════════════════════════════╝

Backend moderno com arquitetura em camadas, JWT para autenticação
e integração com inteligência artificial para geração de questões
automáticas de revisão.

📌 Status: Em desenvolvimento

────────────────────────────────────────────
🔧 Tecnologias
────────────────────────────────────────────
• ASP.NET Core  
• Entity Framework Core  
• PostgreSQL  
• JWT (JSON Web Token)  
• Serviço externo de IA (para geração de perguntas)

────────────────────────────────────────────
🏗️ Estrutura do Projeto
────────────────────────────────────────────
📁 /Domain         → Entidades e contratos  
📁 /Application    → Regras de negócio  
📁 /Infrastructure → Banco de dados e serviços externos  
📁 /API            → Controllers e configuração  

────────────────────────────────────────────
🚀 Funcionalidades
────────────────────────────────────────────
✔ Autenticação segura com JWT  
✔ Geração de questões com base em temas enviados  
✔ Endpoints protegidos com autenticação  
✔ Respostas dinâmicas usando IA  

────────────────────────────────────────────
📦 Como rodar localmente
────────────────────────────────────────────
1️⃣ Clonar o repositório:  
   git clone https://github.com/wagnerdaniell/CognitusBackend.git

2️⃣ Acessar a pasta do projeto:  
   cd CognitusBackend

3️⃣ Configurar a connection string no arquivo:  
   appsettings.json

4️⃣ Aplicar as migrations:  
   dotnet ef database update

5️⃣ Iniciar o projeto:  
   dotnet run
