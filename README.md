# 🚀 API de Gestão de Funcionários

Seja bem-vindo(a) à **API de Gestão de Funcionários**! 🎉  
Aqui você pode consultar, atualizar e gerenciar informações dos funcionários de maneira simples e intuitiva! 🛠️

## 🌟 Funcionalidades

### 🔎 Consultas (GET)

- **📄 Listar todos os funcionários:**  
  `GET /`  
  Retorna uma lista completa de funcionários.

- **🆔 Buscar funcionário por ID:**  
  `GET /{id}`  
  Encontre informações detalhadas de um funcionário pelo ID.

- **🔤 Buscar por nome:**  
  `GET /search/nome`  
  Filtre funcionários pelo nome.

- **👶 Buscar por idade:**  
  `GET /search/idade`  
  Localize funcionários com base na idade.

- **📊 Filtrar por faixa etária:**  
  `GET /search/idades`  
  Obtenha funcionários dentro de um intervalo de idades.

- **🏢 Filtrar por setor:**  
  `GET /search/setor`  
  Veja todos os funcionários de um setor específico.

- **💰 Buscar por salário:**  
  `GET /search/salarios`  
  Filtre funcionários com base no salário.

- **🛠️ Buscar por cargos:**  
  `GET /search/cargos`  
  Retorna funcionários com um cargo específico.

- **🌍 Filtrar por localização (bairro, cidade ou estado):**  
  - `GET /search/bairro`  
  - `GET /search/cidade`  
  - `GET /search/estado`  

- **🚌 Buscar por transporte:**  
  `GET /search/transporte`  
  Filtre pelo meio de transporte utilizado pelos funcionários.

- **✅ Buscar ativos:**  
  `GET /search/ativo`  
  Retorna apenas os funcionários ativos.

- **🔗 Combinação de setor e cargo:**  
  `GET /search/setor-cargo`  
  Veja funcionários filtrados por setor e cargo.

- **📊 Estatísticas por setor:**  
  - `GET /quantidade-por-setor/{setor}` → Total de funcionários.  
  - `GET /salario-medio-por-setor/{setor}` → Salário médio.  
  - `GET /idade-media-por-setor/{setor}` → Idade média.


### ✏️ Atualizações (PUT)

- **⚙️ Atualizar todos os atributos de um funcionário:**  
  `PUT /{id}`  
  Atualize qualquer detalhe de um funcionário (nome, idade, salário, etc.).

- **🖋️ Atualizar o nome de um funcionário:**  
  `PUT /atualiza-nome/{id}/{nome}`  
  Altere o nome de um funcionário pelo ID.


### ❌ Exclusões (DELETE)

- **🗑️ Deletar funcionário:**  
  `DELETE /{id}`  
  Remova um funcionário do sistema.

---

