# Eco Carona

Eco Carona é uma aplicação de caronas projetada para conectar motoristas e passageiros, promovendo um transporte sustentável por meio de viagens compartilhadas. O projeto visa facilitar deslocamentos ecológicos, reduzir a pegada de carbono e fomentar uma comunidade colaborativa para mobilidade. Este README fornece uma visão geral do projeto, suas tecnologias e como os componentes de BackEnd e FrontEnd trabalham juntos.

## Visão Geral do Projeto

O Eco Carona permite que os usuários:
- **Cadastrem-se e autentiquem-se**: Criem contas e façam login de forma segura.
- **Ofereçam ou solicitem caronas**: Motoristas podem anunciar caronas disponíveis, e passageiros podem buscar e participar de caronas.
- **Comuniquem-se**: Usuários podem interagir via chat na aplicação para coordenar caronas.
- **Gerenciem perfis**: Atualizem informações pessoais e preferências.
- **Acompanhem caronas**: Visualizem detalhes de viagens, como trajetos, horários e custos compartilhados.

O projeto é dividido em dois repositórios principais:
- [BackEnd](https://github.com/DiegoSabala/eco-carona/tree/main/BackEnd)
- [FrontEnd](https://github.com/DiegoSabala/eco-carona/tree/main/FrontEnd)

## Tecnologias Utilizadas

### BackEnd
O BackEnd do Eco Carona é responsável pela lógica de negócios, gerenciamento de dados e integração com o FrontEnd. As principais tecnologias incluem:

- **C# .NET**: Framework para desenvolvimento do servidor, utilizando ASP.NET Core para criar uma API RESTful robusta e escalável.
- **Entity Framework Core**: ORM (Object-Relational Mapping) para interação com o banco de dados, facilitando o mapeamento de objetos C# para tabelas relacionais.
- **PostgreSQL**: Banco de dados relacional utilizado para armazenar informações de usuários, caronas e mensagens, garantindo consistência e performance.
- **JWT (JSON Web Tokens)**: Utilizado para autenticação segura, protegendo endpoints da API.
- **Docker**: Para conteinerização, garantindo consistência entre ambientes de desenvolvimento e produção.
- **xUnit**: Framework de testes para validação do código com testes unitários e de integração.

O BackEnd inclui um script SQL em PostgreSQL para inicializar o banco de dados com dados pré-definidos, como tabelas de usuários, caronas e configurações iniciais. O script está localizado no repositório do BackEnd e pode ser executado para popular o banco durante a configuração inicial.

O BackEnd fornece endpoints para:
- Gerenciamento de usuários (cadastro, login, atualização de perfil).
- Criação, busca e gerenciamento de caronas.
- Gerenciamento de mensagens entre usuários.
- Cálculo de rotas e divisão de custos (se aplicável).

### FrontEnd
O FrontEnd do Eco Carona é a interface que os usuários utilizam para interagir com a aplicação. As principais tecnologias incluem:

- **React**: Biblioteca JavaScript para construção de interfaces de usuário dinâmicas e componentizadas.
- **TypeScript**: Superset do JavaScript que adiciona tipagem estática, melhorando a manutenção e escalabilidade do código.
- **Axios**: Biblioteca para realizar requisições HTTP ao BackEnd de forma simples e eficiente.
- **Tailwind CSS**: Framework de estilização utilitário para criar interfaces modernas e responsivas.
- **React Router**: Para navegação entre páginas na aplicação, como home, perfil e lista de caronas.
- **Vite**: Ferramenta de build rápida para desenvolvimento e empacotamento do FrontEnd.

O FrontEnd oferece:
- Uma interface intuitiva para cadastro e login.
- Páginas para busca, criação e gerenciamento de caronas.
- Um sistema de chat em tempo real (se implementado).
- Design responsivo, acessível em dispositivos móveis e desktops.

## Funcionamento do Projeto

1. **Autenticação**:
   - O usuário se cadastra ou faz login pelo FrontEnd, que envia uma requisição ao BackEnd.
   - O BackEnd valida as credenciais, gera um JWT e o retorna ao FrontEnd para autenticação em requisições futuras.

2. **Gerenciamento de Caronas**:
   - Motoristas criam caronas informando origem, destino, horário e número de vagas.
   - Passageiros buscam caronas disponíveis com filtros (como localização ou horário).
   - O BackEnd armazena os dados no PostgreSQL e retorna as caronas correspondentes ao FrontEnd para exibição.

3. **Comunicação**:
   - Usuários podem trocar mensagens para coordenar detalhes da carona.
   - O FrontEnd exibe o chat, enquanto o BackEnd gerencia o armazenamento e a entrega das mensagens.

4. **Perfil e Configurações**:
   - Usuários podem atualizar informações pessoais e preferências.
   - O BackEnd valida e armazena as alterações, enquanto o FrontEnd reflete as mudanças na interface.

## Como Executar o Projeto

### Pré-requisitos
- **.NET SDK** (versão 6.0 ou superior)
- **PostgreSQL** (versão 13 ou superior)
- **Node.js** (versão 16 ou superior)
- **Docker** (opcional, para conteinerização)
- **NPM** ou **Yarn** para gerenciamento de pacotes

### BackEnd
1. Clone o repositório do BackEnd:
   ```bash
   git clone https://github.com/DiegoSabala/eco-carona.git
   cd eco-carona/BackEnd
   ```
2. Instale as dependências:
   ```bash
   dotnet restore
   ```
3. Configure as variáveis de ambiente (crie um arquivo `appsettings.json` ou use variáveis de ambiente):
   - `ConnectionStrings:DefaultConnection`: String de conexão com o PostgreSQL (ex.: `Host=localhost;Database=ecocarona;Username=postgres;Password=senha`)
   - `Jwt:Key`: Chave secreta para JWT
   - `Jwt:Issuer` e `Jwt:Audience`: Configurações do emissor e audiência do JWT
4. Execute o script SQL para inicializar o banco de dados:
   - Localize o script no repositório (ex.: `scripts/setup.sql`).
   - Execute no PostgreSQL usando uma ferramenta como `psql`:
     ```bash
     psql -U postgres -d ecocarona -f scripts/setup.sql
     ```
5. Inicie o servidor:
   ```bash
   dotnet run
   ```

### FrontEnd
1. Clone o repositório do FrontEnd:
   ```bash
   cd eco-carona/FrontEnd
   ```
2. Instale as dependências:
   ```bash
   npm install
   ```
3. Configure as variáveis de ambiente (se necessário, como a URL do BackEnd, ex.: `VITE_API_URL=http://localhost:5000`).
4. Inicie o projeto:
   ```bash
   npm run dev
   ```
5. Acesse a aplicação em `http://localhost:5173` (ou a porta configurada pelo Vite).

## Contribuição
Contribuições são bem-vindas! Para contribuir:
1. Faça um fork do repositório.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-funcionalidade`).
3. Commit suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).
4. Envie para o repositório remoto (`git push origin feature/nova-funcionalidade`).
5. Abra um Pull Request.

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).