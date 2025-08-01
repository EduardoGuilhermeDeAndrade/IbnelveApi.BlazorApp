# 🚀 IbnelveApi - Frontend Blazor WebAssembly

## 📋 **Resumo do Projeto**

Frontend moderno e completo em **Blazor WebAssembly** para consumir a API IbnelveApi. O projeto implementa todas as funcionalidades de gestão de pessoas e tarefas com interface responsiva e intuitiva.

## ✅ **Funcionalidades Implementadas**

### 🔐 **Sistema de Autenticação**
- **Login/Logout** com JWT
- **Proteção de rotas** automática
- **Gerenciamento de tokens** no localStorage
- **Redirecionamento** automático para login

### 🏠 **Dashboard Interativo**
- **Estatísticas em tempo real** (tarefas, pessoas)
- **Cards informativos** com métricas
- **Alertas visuais** para tarefas vencidas
- **Ações rápidas** (nova tarefa, nova pessoa)
- **Lista de tarefas recentes**

### 👥 **Gestão de Pessoas - CRUD Completo**
- ✅ **Listar Pessoas** - Tabela responsiva com filtros
- ✅ **Nova Pessoa** - Formulário completo com validação
- ✅ **Editar Pessoa** - Formulário pré-preenchido
- ✅ **Visualizar Pessoa** - Detalhes completos em cards
- ✅ **Buscar Pessoas** - Filtros por nome e CPF
- ✅ **Excluir Pessoa** - Com confirmação

### 📋 **Gestão de Tarefas - Sistema Completo**

#### **Páginas Principais:**
- ✅ **Todas as Tarefas** - Lista geral com filtros
- ✅ **Nova Tarefa** - Formulário avançado com preview
- ✅ **Editar Tarefa** - Formulário completo
- ✅ **Visualizar Tarefa** - Detalhes e histórico

#### **Páginas Especializadas:**
- ✅ **Tarefas Vencidas** - Alertas e ações urgentes
- ✅ **Tarefas Concluídas** - Histórico de produtividade
- ✅ **Tarefas Em Andamento** - Foco na execução
- ✅ **Tarefas Pendentes** - Organização por prioridade

#### **Funcionalidades Avançadas:**
- 🎯 **Filtros por Status** (Pendente, Em Andamento, Concluída, Cancelada)
- 🔥 **Filtros por Prioridade** (Baixa, Média, Alta, Crítica)
- 📂 **Filtros por Categoria** dinâmicos
- 🔍 **Busca por texto** (título/descrição)
- 📅 **Filtros por data** (vencimento, criação)
- ⚡ **Ações rápidas** (marcar como concluída, iniciar)
- 📊 **Estatísticas** de produtividade

## 🎨 **Design e UX**

### **Layout Moderno:**
- **Bootstrap 5** para responsividade
- **Font Awesome 6** para ícones
- **Google Fonts (Inter)** para tipografia
- **Cores consistentes** para status e prioridades
- **Animações suaves** de transição

### **Menu Expansível:**
- **Submenu para Tarefas** com todas as opções
- **Submenu para Pessoas** organizado
- **Auto-colapso** de outros menus
- **Navegação intuitiva** com breadcrumbs

### **Componentes Reutilizáveis:**
- **Cards informativos** padronizados
- **Formulários** com validação em tempo real
- **Modais de confirmação** elegantes
- **Loading states** em todas as operações
- **Feedback visual** para ações

## 🛠️ **Tecnologias Utilizadas**

- **.NET 9** + **Blazor WebAssembly**
- **Bootstrap 5** para layout responsivo
- **Font Awesome 6** para ícones
- **HttpClient** para comunicação com API
- **System.Text.Json** para serialização
- **JWT Authentication** para segurança

## 📱 **Responsividade**

- ✅ **Desktop** - Layout completo com sidebar
- ✅ **Tablet** - Adaptação de colunas e espaçamentos
- ✅ **Mobile** - Menu colapsável e cards empilhados
- ✅ **Touch-friendly** - Botões e links otimizados

## 🚀 **Como Executar**

### **Pré-requisitos:**
- .NET 9 SDK instalado
- API IbnelveApi rodando em `https://localhost:7202`

### **Passos:**
1. **Extrair** o projeto do ZIP
2. **Navegar** para o diretório do projeto
3. **Restaurar** dependências:
   ```bash
   dotnet restore
   ```
4. **Executar** o projeto:
   ```bash
   dotnet run
   ```
5. **Acessar** no navegador: `http://localhost:5000`

### **Login Padrão:**
- **Email:** admin1@ibnelveapi.com
- **Senha:** Admin123!

## 📊 **Estrutura do Projeto**

```
IbnelveApi.BlazorApp/
├── Models/                 # DTOs e modelos
│   ├── ApiResponse.cs
│   ├── AuthModels.cs
│   ├── PessoaModels.cs
│   └── TarefaModels.cs
├── Services/               # Serviços HTTP
│   ├── AuthService.cs
│   ├── PessoaService.cs
│   └── TarefaService.cs
├── Pages/                  # Páginas Razor
│   ├── Home.razor          # Dashboard
│   ├── Login.razor         # Autenticação
│   ├── Pessoas.razor       # Lista de pessoas
│   ├── NovaPessoa.razor    # Criar pessoa
│   ├── EditarPessoa.razor  # Editar pessoa
│   ├── VisualizarPessoa.razor # Ver pessoa
│   ├── Tarefas.razor       # Lista de tarefas
│   ├── NovaTarefa.razor    # Criar tarefa
│   ├── EditarTarefa.razor  # Editar tarefa
│   ├── VisualizarTarefa.razor # Ver tarefa
│   ├── TarefasVencidas.razor # Tarefas vencidas
│   ├── TarefasConcluidas.razor # Tarefas concluídas
│   ├── TarefasEmAndamento.razor # Tarefas ativas
│   └── TarefasPendentes.razor # Tarefas pendentes
├── Layout/                 # Layout e navegação
│   ├── MainLayout.razor    # Layout principal
│   ├── NavMenu.razor       # Menu lateral
│   └── NavMenu.razor.css   # Estilos do menu
└── wwwroot/               # Arquivos estáticos
    └── index.html         # HTML principal
```

## 🎯 **Funcionalidades Destacadas**

### **Dashboard Inteligente:**
- Estatísticas em tempo real
- Alertas para tarefas vencidas
- Ações rápidas contextuais
- Resumo de produtividade

### **Gestão de Tarefas Avançada:**
- Sistema completo de status
- Prioridades visuais com cores
- Filtros múltiplos combinados
- Busca inteligente
- Estatísticas de performance

### **Interface Intuitiva:**
- Menu expansível organizado
- Breadcrumbs em todas as páginas
- Feedback visual imediato
- Confirmações para ações críticas

### **Formulários Inteligentes:**
- Validação em tempo real
- Formatação automática (CPF, telefone)
- Preview de dados
- Sugestões contextuais

## 🔧 **Configurações**

### **API Base URL:**
Configurada para `https://localhost:7202` no `Program.cs`

### **Autenticação:**
JWT Bearer token armazenado no localStorage

### **Timeouts:**
- HttpClient: 30 segundos
- Operações longas: 60 segundos

## 📈 **Performance**

- **Lazy Loading** de componentes
- **Paginação** em listas grandes
- **Debounce** em campos de busca
- **Cache** de dados frequentes
- **Otimização** de re-renders

## 🎨 **Temas e Cores**

### **Cores por Status:**
- 🟢 **Concluída:** Verde (success)
- 🔵 **Em Andamento:** Azul (info)
- 🟡 **Pendente:** Amarelo (warning)
- 🔴 **Cancelada:** Vermelho (danger)

### **Cores por Prioridade:**
- 🟢 **Baixa:** Cinza (secondary)
- 🟡 **Média:** Azul (primary)
- 🟠 **Alta:** Amarelo (warning)
- 🔴 **Crítica:** Vermelho (danger)

## 🚀 **Próximos Passos**

### **Melhorias Futuras:**
- [ ] Notificações push
- [ ] Modo escuro
- [ ] Relatórios em PDF
- [ ] Gráficos de produtividade
- [ ] Integração com calendário
- [ ] Comentários em tarefas
- [ ] Anexos de arquivos
- [ ] Colaboração em equipe

### **Otimizações:**
- [ ] Service Worker para offline
- [ ] Compressão de assets
- [ ] Lazy loading de imagens
- [ ] Virtual scrolling
- [ ] Caching avançado

## 📞 **Suporte**

Para dúvidas ou problemas:
1. Verificar se a API está rodando
2. Conferir configurações de CORS
3. Validar tokens JWT
4. Checar logs do navegador

## 🎉 **Conclusão**

Este frontend Blazor WebAssembly oferece uma experiência completa e moderna para gestão de pessoas e tarefas, com interface intuitiva, funcionalidades avançadas e design responsivo. Está pronto para produção e pode ser facilmente estendido com novas funcionalidades.

---

**Desenvolvido com ❤️ usando Blazor WebAssembly e .NET 9**

