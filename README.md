# 🚀 SecureSales API

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Build](https://img.shields.io/github/actions/workflow/status/SEU_USUARIO/secure-sales-api/dotnet.yml)
![License](https://img.shields.io/badge/license-MIT-green)
![PRs](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)

API desenvolvida em .NET 8 com foco em segurança, arquitetura moderna e escalabilidade, utilizando Azure Key Vault, Multi-Tenant e mensageria com RabbitMQ.

---

## 🎥 Demonstração
![Demo](docs/demo.gif)

---

## 🧠 Arquitetura

- Clean Architecture  
- Domain-Driven Design (DDD)  
- SOLID  
- Separation of Concerns  

---

## 🔐 Segurança com Key Vault

- Sem secrets no código  
- Rotação segura  
- Cloud-ready  

---

## 🔑 Autenticação

- JWT Bearer  
- Chave armazenada no Key Vault  

---

## 🏢 Multi-Tenancy

Header obrigatório:

X-Tenant-Id: empresa_123

---

## 🐇 Mensageria (RabbitMQ)

Evento: ClienteCriadoEvent

---

## 📡 Swagger

http://localhost:5000/swagger

---

## 🐳 Docker

docker build -t securesales-api .
docker run -p 5000:80 securesales-api

---

## 🚀 Executar

dotnet restore
dotnet build
dotnet run

---

## 🧪 Testes

dotnet test

---

## 👨‍💻 Autor

Andre Sombra
