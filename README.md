# 🛒 Sistema de Supermercado - Windows Forms

Sistema desktop de gerenciamento de supermercado desenvolvido em C# utilizando Windows Forms e MySQL.

O projeto foi desenvolvido com foco no gerenciamento de produtos, controle de estoque, realização de vendas e emissão de nota simples, aplicando os principais conceitos estudados na disciplina.

---

# 👥 Integrantes

| RA | Nome |
|---|---|
| 923204573 | Carlos Eduardo de Oliveira |
| 922203257 | Joanice Matos dos Reis |
| 922203115 | Gabriel de Lima Sovrani |
| 922203138 | Gabriel Menses |
| 925208551 | Samuel Santinelli Mantovani |
| 922102276 | André Victor Bezerra Carabolante |

---

# 📌 Funcionalidades

## 📦 Gerenciamento de Produtos (CRUD)

- Cadastro de produtos
- Atualização de produtos
- Exclusão de produtos
- Consulta/Listagem de produtos
- Controle de estoque
- Cadastro com imagem do produto

## 🛒 Compras e Vendas

- Seleção de produtos
- Inserção de múltiplos itens no carrinho
- Controle de quantidade
- Cálculo automático de subtotal
- Cálculo automático do valor total
- Finalização da compra

## 🧾 Emissão de Nota

- Emissão de nota simples da venda
- Exibição dos produtos comprados
- Quantidade e valor unitário
- Valor total da compra
- Data da compra

## 📚 Histórico

- Histórico de vendas realizadas

---

# 🛠️ Tecnologias Utilizadas

- C#
- Windows Forms
- .NET Framework 4.7.2
- MySQL
- MySQL Workbench
- Visual Studio

---

# 🗄️ Banco de Dados

O banco utilizado no projeto é:

```sql
sistema_supermercado
```

O script de criação do banco e tabelas está disponível no arquivo:

```txt
sistema_supermercado.sql
```

---

# ⚙️ Configuração do Banco de Dados

## 1. Abrir o MySQL Workbench

Abra o MySQL Workbench ou outro gerenciador MySQL de sua preferência.

---

## 2. Criar o banco de dados

Execute o comando:

```sql
CREATE DATABASE sistema_supermercado;
```

---

## 3. Importar o script SQL

Importe o arquivo:

```txt
sistema_supermercado.sql
```

---

## 4. Configurar a conexão

A conexão com o banco de dados está localizada no arquivo:

```txt
App.config
```

Exemplo:

```xml
connectionString="Server=localhost;Database=sistema_supermercado;Uid=root;Pwd=123456;"
```

Caso necessário, altere:
- usuário (`Uid`)
- senha (`Pwd`)

de acordo com a configuração do seu MySQL local.

---

# ▶️ Como Executar o Projeto

## 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/sistema-supermercado-winforms.git
```

---

## 2. Abrir o projeto

Abra o arquivo:

```txt
SistemaSupermercado.sln
```

no Visual Studio.

---

## 3. Restaurar dependências

Aguarde o Visual Studio restaurar os pacotes automaticamente.

Caso necessário:

```txt
Build > Restore NuGet Packages
```

---

## 4. Executar o projeto

Pressione:

```txt
F5
```

ou clique em:

```txt
Start
```

---

# 🖼️ Funcionalidade Extra

O projeto possui suporte para:

- Upload de imagem dos produtos
- Exibição visual das imagens cadastradas

---

# 📚 Conteúdos Aplicados da Disciplina

- Estrutura de programas em C#
- Declaração de variáveis
- Estruturas condicionais
- Estruturas de repetição
- Funções e métodos
- Vetores/Listas
- Manipulação de Windows Forms
- Integração com banco de dados
- Operações CRUD
- Programação Orientada a Objetos

---

# ✅ Status do Projeto

✔️ CRUD implementado  
✔️ Integração com banco de dados  
✔️ Controle de estoque  
✔️ Carrinho de compras  
✔️ Emissão de nota simples  
✔️ Histórico de vendas  
✔️ Upload de imagens  

---

# 📄 Observações

Projeto desenvolvido para fins acadêmicos na disciplina de Desenvolvimento Desktop com C# e Windows Forms.

---

# 📄 Licença

Projeto de uso acadêmico.
