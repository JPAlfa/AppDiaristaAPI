CREATE TABLE Endereco (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Logradouro varchar(500) NOT NULL,
	Numero int,
	Cidade varchar(150) NOT NULL,
	Estado varchar(50) NOT NULL,
	Complemento varchar(200),
	Cep varchar(8) NOT NULL
);

CREATE TABLE Contratante (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email varchar(100) NOT NULL,
	Senha char(64) NOT NULL,
	Nome varchar(100) NOT NULL,
	Cpf varchar(11) NOT NULL,
	IdEndereco INT FOREIGN KEY REFERENCES Endereco(Id) NOT NULL,
	DataNascimento DateTime NOT NULL,
	Telefone varchar(15) NOT NULL
);

CREATE TABLE Diarista (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
	Senha CHAR(64) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Cpf VARCHAR(11) NOT NULL,
	IdEndereco INT FOREIGN KEY REFERENCES Endereco(Id) NOT NULL,
	DataNascimento DATETIME NOT NULL,
	Telefone VARCHAR(15) NOT NULL,
	PrecoDiaria FLOAT,
	Nota FLOAT
);

CREATE TABLE Servico (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdContratante INT FOREIGN KEY REFERENCES Contratante(Id) NOT NULL,
	IdDiarista INT FOREIGN KEY REFERENCES Diarista(Id) NOT NULL,
	Preco FLOAT NOT NULL,
	DataServico DATETIME NOT NULL,
	Confirmado BIT NOT NULL DEFAULT 0,
	Realizado BIT NOT NULL DEFAULT 0,
	Nota INT
);
