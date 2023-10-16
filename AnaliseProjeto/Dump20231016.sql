-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: feiragro
-- ------------------------------------------------------
-- Server version	5.7.42-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20231006152717_CreateIdentitySchema','7.0.10');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','CLIENTE','CLIENTE',NULL),('2','PRODUTOR','PRODUTOR',NULL),('3','DIRETOR','DIRETOR',NULL),('4','ADMINISTRADOR','ADMINISTRADOR',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('13099c29-7b72-4440-b450-ff15ee778a25','1'),('7848cd58-b226-4fe9-8799-6ec3cf7fcb19','1'),('13099c29-7b72-4440-b450-ff15ee778a25','2'),('7848cd58-b226-4fe9-8799-6ec3cf7fcb19','2'),('13099c29-7b72-4440-b450-ff15ee778a25','3'),('7848cd58-b226-4fe9-8799-6ec3cf7fcb19','3'),('13099c29-7b72-4440-b450-ff15ee778a25','4');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('13099c29-7b72-4440-b450-ff15ee778a25','profeta.garoto@gmail.com','PROFETA.GAROTO@GMAIL.COM','profeta.garoto@gmail.com','PROFETA.GAROTO@GMAIL.COM',0,'AQAAAAEAACcQAAAAEFEB923LyJJLIOpcbRGcdIrv7aqXnh67uJnMTxTAVGCht87RGW/BDwaGlVzVX3MVBA==','2YMH6YRJEXVYAJH6GIA4RMPZXJ5ACDTH','1ec2923e-0056-4d0d-8eb7-25b80c0c5846',NULL,0,0,NULL,1,0),('7848cd58-b226-4fe9-8799-6ec3cf7fcb19','galvoninha@gmail.com','GALVONINHA@GMAIL.COM','galvoninha@gmail.com','GALVONINHA@GMAIL.COM',0,'AQAAAAEAACcQAAAAEBCrOAOYxRKN/dnVCG/ULDz4a3XY1yiVXXiPqNqnmWwKg7u1/3zp4z536l4rHMm5yQ==','L3QAODI5JSRLKS4KAUS4ZN26FKVLIVN7','f7204a20-0e8b-4cd9-a414-60faf0ea03c7',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `associacao`
--

DROP TABLE IF EXISTS `associacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `associacao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `cnpj` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `cep` varchar(8) NOT NULL,
  `uf` varchar(2) NOT NULL,
  `municipio` varchar(20) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `numero` varchar(10) NOT NULL DEFAULT '0',
  `complemento` varchar(80) DEFAULT NULL,
  `telefone` varchar(14) NOT NULL,
  `status` enum('ATIVO','DESATIVO') NOT NULL DEFAULT 'ATIVO',
  `data` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_nome` (`nome`),
  KEY `idx_cnpj` (`cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `associacao`
--

LOCK TABLES `associacao` WRITE;
/*!40000 ALTER TABLE `associacao` DISABLE KEYS */;
INSERT INTO `associacao` VALUES (2,'DragaoAzul','76364829549475','dragaoazul@gmail.com','95264626','st','string','string','string','37107',NULL,'stringstrings','ATIVO','2023-10-15 22:39:29'),(7,'Galvoninha','11111111111111','nadiannegalvao@gmail.com','22222222','SE','Areia Branca','Maruim','Jaconias','0',NULL,'+5579996291292','ATIVO','2023-09-18 19:52:43'),(8,'Vere Associacoes','11111111111111','profeta.garoto@gmail.com','22222222','SE','Areia Branca','Maruim','Jaconias','222','Fica logo ali','+5579996291292','ATIVO','2023-09-18 19:53:33'),(9,'NovaAss','11111111111111','profeta.garoto@gmail.com','49580000','SE','Areia Branca','Maruim','Jaconias','222',NULL,'+5579996291292','ATIVO','2023-10-13 12:53:43'),(10,'Emdagro','11111111111111','qweqeqweqee@gmail.com','49580000','SE','Areia Branca','Maruim','Jaconias','222',NULL,'+5579996291292','ATIVO','2023-10-16 07:19:09'),(11,'Associacao Teste','87023374671971','teste@gmail.com','65768971','st','string','string','string','1332898172','string','stringstrings','ATIVO','2023-10-16 07:21:02'),(12,'Editando o id 12','87910194083410','g1212@gmail.com','62881097','st','string','string','string','5','string','stringstrings','ATIVO','2023-10-16 07:31:56');
/*!40000 ALTER TABLE `associacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feira`
--

DROP TABLE IF EXISTS `feira`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `feira` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPontoAssociacao` int(11) NOT NULL,
  `IdAssociacao` int(11) NOT NULL,
  `dataInicio` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dataFim` datetime DEFAULT NULL,
  `status` enum('FECHADA','CANCELADA','ABERTA') NOT NULL DEFAULT 'ABERTA',
  PRIMARY KEY (`id`),
  KEY `fk_Feira_Associacao1_idx` (`IdAssociacao`),
  KEY `fk_Feira_PontoAssociacao1_idx` (`IdPontoAssociacao`),
  CONSTRAINT `fk_Feira_Associacao1` FOREIGN KEY (`IdAssociacao`) REFERENCES `associacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Feira_PontoAssociacao1` FOREIGN KEY (`IdPontoAssociacao`) REFERENCES `pontoassociacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feira`
--

LOCK TABLES `feira` WRITE;
/*!40000 ALTER TABLE `feira` DISABLE KEYS */;
INSERT INTO `feira` VALUES (3,1,7,'2023-09-12 11:02:00','2023-09-26 11:02:00','FECHADA');
/*!40000 ALTER TABLE `feira` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `cpf` varchar(11) NOT NULL,
  `dataNascimento` date NOT NULL,
  `telefone` varchar(14) NOT NULL,
  `tipoPessoa` enum('ADM','DIRETOR','PRODUTOR','CLIENTE') NOT NULL DEFAULT 'CLIENTE',
  `email` varchar(50) NOT NULL,
  `IdAssociacao` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Pessoa_Associacao1_idx` (`IdAssociacao`),
  CONSTRAINT `fk_Pessoa_Associacao1` FOREIGN KEY (`IdAssociacao`) REFERENCES `associacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (2,'VereVere KellyKelly','11122233344','1996-11-10','5579999999999','ADM','ververe@gmail.com',NULL);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pontoassociacao`
--

DROP TABLE IF EXISTS `pontoassociacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pontoassociacao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `IdAssociacao` int(11) NOT NULL,
  `cep` varchar(8) NOT NULL,
  `uf` varchar(2) NOT NULL,
  `municipio` varchar(20) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `numero` int(11) NOT NULL DEFAULT '0',
  `complemento` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_municipio` (`municipio`),
  KEY `idx_bairro` (`bairro`),
  KEY `fk_PontoAssociacao_Associacao1_idx` (`IdAssociacao`),
  CONSTRAINT `fk_PontoAssociacao_Associacao1` FOREIGN KEY (`IdAssociacao`) REFERENCES `associacao` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pontoassociacao`
--

LOCK TABLES `pontoassociacao` WRITE;
/*!40000 ALTER TABLE `pontoassociacao` DISABLE KEYS */;
INSERT INTO `pontoassociacao` VALUES (1,7,'22222222','SE','AQUI ALI','RUA ALI','BAIRO LA',150,'aqui do lado');
/*!40000 ALTER TABLE `pontoassociacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS `produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `IdTipoProduto` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `imagem` blob,
  PRIMARY KEY (`id`),
  KEY `idx_nome` (`nome`),
  KEY `fk_Produto_TipoProduto1_idx` (`IdTipoProduto`),
  CONSTRAINT `fk_Produto_TipoProduto1` FOREIGN KEY (`IdTipoProduto`) REFERENCES `tipoproduto` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto`
--

LOCK TABLES `produto` WRITE;
/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto` VALUES (1,1,'Manga','');
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produtofeira`
--

DROP TABLE IF EXISTS `produtofeira`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produtofeira` (
  `IdProduto` int(11) NOT NULL,
  `IdFeira` int(11) NOT NULL,
  `quantidadeDisponivel` int(11) NOT NULL,
  `quantidadeVendida` int(11) NOT NULL,
  `quantidadeAjuste` int(11) NOT NULL,
  `unidadeMedida` enum('KG','LITRO','MOLHO','GRAMA','CACHO','UNIDADE') NOT NULL,
  `valor` decimal(6,2) NOT NULL,
  `justificativaReserva` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`IdFeira`,`IdProduto`),
  KEY `fk_ProdutoFeira_Produto1_idx` (`IdProduto`),
  KEY `fk_ProdutoFeira_Feira1_idx` (`IdFeira`),
  CONSTRAINT `fk_ProdutoFeira_Feira1` FOREIGN KEY (`IdFeira`) REFERENCES `feira` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProdutoFeira_Produto1` FOREIGN KEY (`IdProduto`) REFERENCES `produto` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produtofeira`
--

LOCK TABLES `produtofeira` WRITE;
/*!40000 ALTER TABLE `produtofeira` DISABLE KEYS */;
/*!40000 ALTER TABLE `produtofeira` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produtovenda`
--

DROP TABLE IF EXISTS `produtovenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produtovenda` (
  `IdFeira` int(11) NOT NULL,
  `IdProduto` int(11) NOT NULL,
  `IdVenda` int(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  PRIMARY KEY (`IdFeira`,`IdProduto`,`IdVenda`),
  KEY `fk_ProdutoFeira_has_Venda_Venda1_idx` (`IdVenda`),
  KEY `fk_ProdutoFeira_has_Venda_ProdutoFeira1_idx` (`IdFeira`,`IdProduto`),
  CONSTRAINT `fk_ProdutoFeira_has_Venda_ProdutoFeira1` FOREIGN KEY (`IdFeira`, `IdProduto`) REFERENCES `produtofeira` (`IdFeira`, `IdProduto`),
  CONSTRAINT `fk_ProdutoFeira_has_Venda_Venda1` FOREIGN KEY (`IdVenda`) REFERENCES `venda` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produtovenda`
--

LOCK TABLES `produtovenda` WRITE;
/*!40000 ALTER TABLE `produtovenda` DISABLE KEYS */;
/*!40000 ALTER TABLE `produtovenda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `IdPessoa` int(11) NOT NULL,
  `data` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` enum('PENDENTE','CANCELADO','ACEITADO') NOT NULL DEFAULT 'PENDENTE',
  PRIMARY KEY (`id`),
  KEY `fk_Reserva_Pessoa1_idx` (`IdPessoa`),
  CONSTRAINT `fk_Reserva_Pessoa1` FOREIGN KEY (`IdPessoa`) REFERENCES `pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservaprodutofeira`
--

DROP TABLE IF EXISTS `reservaprodutofeira`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservaprodutofeira` (
  `IdReserva` int(11) NOT NULL,
  `IdFeira` int(11) NOT NULL,
  `IdProduto` int(11) NOT NULL,
  `quantidade` decimal(10,2) NOT NULL,
  PRIMARY KEY (`IdReserva`,`IdFeira`,`IdProduto`),
  KEY `fk_Reserva_has_ProdutoFeira_ProdutoFeira1_idx` (`IdFeira`,`IdProduto`),
  KEY `fk_Reserva_has_ProdutoFeira_Reserva1_idx` (`IdReserva`),
  CONSTRAINT `fk_Reserva_has_ProdutoFeira_ProdutoFeira1` FOREIGN KEY (`IdFeira`, `IdProduto`) REFERENCES `produtofeira` (`IdFeira`, `IdProduto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Reserva_has_ProdutoFeira_Reserva1` FOREIGN KEY (`IdReserva`) REFERENCES `reserva` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservaprodutofeira`
--

LOCK TABLES `reservaprodutofeira` WRITE;
/*!40000 ALTER TABLE `reservaprodutofeira` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservaprodutofeira` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoproduto`
--

DROP TABLE IF EXISTS `tipoproduto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoproduto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nome_UNIQUE` (`nome`),
  KEY `idx_nome` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoproduto`
--

LOCK TABLES `tipoproduto` WRITE;
/*!40000 ALTER TABLE `tipoproduto` DISABLE KEYS */;
INSERT INTO `tipoproduto` VALUES (1,'Fruta'),(4,'Molho de Pimenta'),(3,'Raíz'),(2,'Verduras');
/*!40000 ALTER TABLE `tipoproduto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `IdCliente` int(11) NOT NULL,
  `IdProdutor` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Venda_Pessoa1_idx` (`IdCliente`),
  KEY `fk_Venda_Pessoa2_idx` (`IdProdutor`),
  CONSTRAINT `fk_Venda_Pessoa1` FOREIGN KEY (`IdCliente`) REFERENCES `pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Venda_Pessoa2` FOREIGN KEY (`IdProdutor`) REFERENCES `pessoa` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda`
--

LOCK TABLES `venda` WRITE;
/*!40000 ALTER TABLE `venda` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-16 16:21:43
