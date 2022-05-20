CREATE DATABASE db_livros;
USE db_livros;

CREATE TABLE tb_usuario (
cd_usuario varchar(25),
nm_usuario char(40),
cd_senha varchar(50),
cd_cpf varchar(15),
dt_nascimento date,
ic_sexo char(1),
cd_email varchar(50),
cd_telefone varchar(20),
constraint pk_usuario
  PRIMARY KEY (cd_usuario)
);

CREATE TABLE tb_endereco (
cd_numeroRes int(6),
ds_complemento varchar(80),
nm_rua char(50),
nm_bairro char(50),
cd_cep varchar(9),
nm_cidade char(50),
sg_estado char(2),
cd_usuario varchar(25),
constraint pk_endereco
  PRIMARY KEY (cd_numeroRes),
constraint fk_endereco_usuario
  foreign key (cd_usuario) references tb_usuario(cd_usuario)
  on update cascade
  on delete cascade
);

CREATE TABLE tb_livro (
cd_livro int(5),
nm_livro varchar(40),
nm_livrosub varchar (30),
nm_autor char(40),
nm_genero char(40),
nm_idioma char(40),
yy_publicacao int(4),
nm_cidadepub char(50),
nm_editora char(50),
qt_paginas int(5),
qt_volume varchar(15),
nm_classificacao varchar(40),
ds_comentario varchar(80),
ds_sinopse varchar(100),
cd_usuario varchar(25),
constraint pk_livro
  PRIMARY KEY (cd_livro),
constraint fk_livro_usuario
  foreign key (cd_usuario) references tb_usuario(cd_usuario)
  on update cascade
  on delete cascade
);

INSERT INTO tb_usuario (cd_usuario, nm_usuario, cd_senha, cd_cpf, dt_nascimento, ic_sexo, cd_email, cd_telefone) 
VALUES ('Jaaj', 'João Victor Gorgonio Lopes', '35913729pipi', '980.115.190-00', '2002-03-04', 'M', 'joao-gorgonio16@outlook.com', '(13) 997380606');

INSERT INTO tb_endereco (cd_numeroRes, ds_complemento, nm_rua, nm_bairro, cd_cep, nm_cidade, sg_estado, cd_usuario) 
VALUES (1217, 'Apartamento 311', 'Rua Jaú', 'Boqueirão', '11701-190', 'Praia Grande', 'SP', 'Jaaj');

INSERT INTO tb_livro(cd_livro, nm_livro, nm_livrosub, nm_autor, nm_genero, nm_idioma, yy_publicacao, nm_cidadepub, nm_editora, qt_paginas, qt_volume, nm_classificacao, ds_comentario, ds_sinopse, cd_usuario)
VALUES (00123, 'H.P Lovecraft','Medo Clássico', 'H.P Lovecraft', 'Ficção', 'Português', 2017, 'Virginía', 'DarkSide', 384, 'Volume 1', '+16','muito bom muito bom','altos monstrinhos', 'Jaaj');