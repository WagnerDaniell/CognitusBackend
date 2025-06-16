
# 🧠 CognitusBackend

Backend moderno com arquitetura em camadas, autenticação via JWT  
e integração com inteligência artificial para geração de questões de revisão.

📌 **Status:** Finalizado!

---

## 🔧 Tecnologias

- ASP.NET Core  
- Entity Framework Core  
- PostgreSQL  
- JWT (JSON Web Token)  
- Serviço externo de IA (OpenRouter)

---

## 🏗️ Estrutura do Projeto

```
/Domain         → Entidades e contratos  
/Application    → Regras de negócio  
/Infrastructure → Banco de dados e repositories 
/API            → Controllers e configuração  
```

---

## 🚀 Funcionalidades

- Autenticação segura com JWT  
- Geração de questões com base em temas enviados  
- Endpoints protegidos  
- IA para respostas dinâmicas

---

## 📦 Como rodar localmente

1. **Clone o repositório:**

```bash
git clone https://github.com/wagnerdaniell/CognitusBackend.git
```

2. **Acesse o diretório:**

```bash
cd CognitusBackend
```

3. **Configure a connection string no `appsettings.json`**

4. **Atualize o banco de dados:**

```bash
dotnet ef database update
```

5. **Rode o projeto:**

```bash
dotnet run
```
