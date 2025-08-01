# IbnelveApi.BlazorApp

Frontend moderno em Blazor WebAssembly para consumir a API IbnelveApi.

## 🚀 Funcionalidades

### ✅ **Autenticação JWT**
- Login/Logout completo
- Gerenciamento de tokens no localStorage
- Proteção de rotas
- Interface de usuário responsiva

### 👥 **Gestão de Pessoas**
- Listagem com filtros e busca
- Busca por nome e CPF
- Interface CRUD completa
- Visualização de endereços

### 📋 **Gestão de Tarefas**
- Dashboard com estatísticas
- Filtros avançados (status, prioridade, categoria)
- Marcação rápida como concluída
- Alertas para tarefas vencidas
- Interface CRUD completa

### 🎨 **Design Moderno**
- Layout responsivo com Bootstrap 5
- Ícones Font Awesome
- Tipografia Google Fonts (Inter)
- Cards e componentes modernos
- Cores e badges para status/prioridades

## 🛠️ Tecnologias

- **.NET 9** - Framework principal
- **Blazor WebAssembly** - Frontend SPA
- **Bootstrap 5** - Framework CSS
- **Font Awesome 6** - Ícones
- **Google Fonts** - Tipografia
- **HttpClient** - Comunicação com API
- **System.Text.Json** - Serialização JSON

## 📁 Estrutura do Projeto

```
IbnelveApi.BlazorApp/
├── Models/                 # DTOs e modelos
│   ├── ApiResponse.cs
│   ├── AuthModels.cs
│   ├── PessoaModels.cs
│   └── TarefaModels.cs
├── Services/               # Serviços para API
│   ├── AuthService.cs
│   ├── PessoaService.cs
│   └── TarefaService.cs
├── Pages/                  # Páginas Razor
│   ├── Home.razor         # Dashboard
│   ├── Login.razor        # Autenticação
│   ├── Pessoas.razor      # Gestão de pessoas
│   └── Tarefas.razor      # Gestão de tarefas
├── Layout/                 # Layout e navegação
│   ├── MainLayout.razor
│   └── NavMenu.razor
└── wwwroot/               # Arquivos estáticos
    └── index.html
```

## ⚙️ Configuração

### 1. **URL da API**
O projeto está configurado para acessar a API em:
```
https://localhost:7202/
```

Para alterar, edite o arquivo `Program.cs`:
```csharp
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://sua-api-url/") 
});
```

### 2. **Usuários de Teste**
- **Tenant 1**: admin1@ibnelveapi.com / Admin123!
- **Tenant 2**: admin2@ibnelveapi.com / Admin123!

## 🚀 Como Executar

### 1. **Pré-requisitos**
- .NET 9 SDK instalado
- API IbnelveApi rodando em https://localhost:7202

### 2. **Executar o projeto**
```bash
cd IbnelveApi.BlazorApp
dotnet run
```

### 3. **Acessar a aplicação**
- URL: `https://localhost:5001` ou `http://localhost:5000`
- Fazer login com um dos usuários de teste
- Navegar pelas funcionalidades

## 📱 Funcionalidades por Página

### 🏠 **Dashboard (Home)**
- Estatísticas gerais (total de tarefas, pendentes, concluídas, pessoas)
- Lista de tarefas vencidas com alertas
- Ações rápidas (nova tarefa, nova pessoa)
- Tarefas recentes com status

### 🔐 **Login**
- Interface moderna com split-screen
- Validação de formulário
- Feedback de erros
- Informações de usuários de teste

### 👥 **Pessoas**
- Listagem paginada e responsiva
- Filtros por nome e CPF
- Busca em tempo real
- Ações: visualizar, editar, excluir
- Exibição de endereço completo

### 📋 **Tarefas**
- Listagem com filtros avançados
- Filtros por status, prioridade, categoria
- Busca por título/descrição
- Marcação rápida como concluída
- Alertas visuais para tarefas vencidas
- Badges coloridos para status e prioridades

## 🎨 Design System

### **Cores por Status**
- **Pendente**: Amarelo (warning)
- **Em Andamento**: Azul (info)
- **Concluída**: Verde (success)
- **Cancelada**: Vermelho (danger)

### **Cores por Prioridade**
- **Baixa**: Cinza (secondary)
- **Média**: Azul (primary)
- **Alta**: Amarelo (warning)
- **Crítica**: Vermelho (danger)

### **Ícones Principais**
- 🏠 Dashboard
- 👥 Pessoas
- 📋 Tarefas
- ⚠️ Vencidas
- ✅ Concluídas
- 🔐 Login/Logout

## 🔧 Customização

### **Alterar Cores**
Edite as classes CSS no Bootstrap ou adicione CSS customizado.

### **Adicionar Páginas**
1. Crie arquivo `.razor` na pasta `Pages/`
2. Adicione rota com `@page "/sua-rota"`
3. Injete serviços necessários
4. Adicione link no `NavMenu.razor`

### **Novos Serviços**
1. Crie interface em `Services/`
2. Implemente a interface
3. Registre no `Program.cs`
4. Injete nas páginas

## 🚀 Deploy

### **Desenvolvimento**
```bash
dotnet run
```

### **Produção**
```bash
dotnet publish -c Release
```

Os arquivos estarão em `bin/Release/net9.0/publish/wwwroot/`

## 📝 Próximas Melhorias

- [ ] Componentes reutilizáveis (modais, formulários)
- [ ] Paginação nas listagens
- [ ] Filtros salvos
- [ ] Notificações toast
- [ ] Modo escuro
- [ ] PWA (Progressive Web App)
- [ ] Testes unitários
- [ ] Internacionalização (i18n)

## 🤝 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature
3. Commit suas mudanças
4. Push para a branch
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT.

---

**Desenvolvido com ❤️ usando Blazor WebAssembly**

