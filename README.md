### Data Base

for management my advice is Microsoft SQL Server Management Studio

<p align="center">
<img src="README_FILES/SQL-Server-Microsoft.jpg"
        alt="First"
        style="float: left; margin-right: 50px;" />
</p>

**Microsoft SQL Server**

```SQL
/* 
Robert Chaves Perez (r0b0t95)
2023
*/

CREATE DATABASE InventoryDB
GO

USE InventoryDB
GO

-- TABLES

CREATE TABLE Client (
  clientId    int IDENTITY NOT NULL, 
  clientName  varchar(100) NOT NULL, 
  clientEmail varchar(255) NULL UNIQUE, 
  clientTel   bigint NULL UNIQUE, 
  fkState     tinyint NOT NULL, 
  PRIMARY KEY (clientId));

CREATE TABLE Logg (
  logId     bigint IDENTITY NOT NULL, 
  logDetail varchar(255) NOT NULL, 
  logDate   date NOT NULL, 
  logTime   time NOT NULL, 
  fkUser    smallint NOT NULL, 
  PRIMARY KEY (logId));

CREATE TABLE Product (
  productId     int IDENTITY NOT NULL, 
  code          varchar(100) NOT NULL UNIQUE, 
  productDetail varchar(255) NOT NULL, 
  cant          int NOT NULL, 
  price         float(10) NOT NULL, 
  fkState       tinyint NOT NULL, 
  fkSupplier    int NOT NULL, 
  PRIMARY KEY (productId));

CREATE TABLE Purchase (
  purchaseId     bigint IDENTITY NOT NULL, 
  purchaseDate   date NOT NULL, 
  purchaseTime   time NOT NULL, 
  purchaseDetail varchar(255) NULL, 
  purchaseTotal  float(10) NULL, 
  fkSupplier     int NOT NULL, 
  PRIMARY KEY (purchaseId));

CREATE TABLE Refund (
  refundId   bigint IDENTITY NOT NULL, 
  refundDate date NULL, 
  refundTime time NULL, 
  SalesaleId bigint NOT NULL, 
  PRIMARY KEY (refundId));

CREATE TABLE Sale (
  saleId         bigint IDENTITY NOT NULL, 
  saleDetail     varchar(255) NOT NULL, 
  saleDate       date NOT NULL, 
  saleTime       time NOT NULL, 
  saleTotal      int NOT NULL, 
  fkUser         smallint NOT NULL, 
  ClientclientId int NOT NULL, 
  PRIMARY KEY (saleId));

CREATE TABLE State (
  stateId   tinyint IDENTITY NOT NULL, 
  stateName char(50) NOT NULL UNIQUE, 
  PRIMARY KEY (stateId));

CREATE TABLE Supplier (
  supplierId          int IDENTITY NOT NULL, 
  supplierName        varchar(100) NULL UNIQUE, 
  supplierTel         bigint NULL, 
  supplierEmail       varchar(255) NULL, 
  supplierDescription varchar(255) NULL, 
  fkState             tinyint NOT NULL, 
  PRIMARY KEY (supplierId));

CREATE TABLE [User] (
  userId    smallint IDENTITY NOT NULL, 
  userName  varchar(100) NOT NULL, 
  userEmail varchar(255) NULL UNIQUE, 
  password  varchar(255) NOT NULL, 
  fkState   tinyint NOT NULL, 
  PRIMARY KEY (userId));


CREATE INDEX Client_clientId 
  ON Client (clientId);

CREATE INDEX Log_logId 
  ON Logg (logId);
CREATE INDEX Product_productId 
  ON Product (productId);

CREATE INDEX Purchase_purchaseId 
  ON Purchase (purchaseId);

CREATE INDEX Refund_refundId 
  ON Refund (refundId);
CREATE INDEX Sale_saleId 
  ON Sale (saleId);

CREATE INDEX State_stateId 
  ON State (stateId);

CREATE INDEX Supplier_supplierId 
  ON Supplier (supplierId);

CREATE INDEX User_userId 
  ON [User] (userId);


ALTER TABLE Purchase ADD CONSTRAINT PU_SU FOREIGN KEY (fkSupplier) REFERENCES Supplier (supplierId);

ALTER TABLE Refund ADD CONSTRAINT RE_SA FOREIGN KEY (SalesaleId) REFERENCES Sale (saleId);

ALTER TABLE Sale ADD CONSTRAINT SA_CL FOREIGN KEY (ClientclientId) REFERENCES Client (clientId);

ALTER TABLE Sale ADD CONSTRAINT SA_US FOREIGN KEY (fkUser) REFERENCES [User] (userId);

ALTER TABLE Logg ADD CONSTRAINT LO_US FOREIGN KEY (fkUser) REFERENCES [User] (userId);

ALTER TABLE Product ADD CONSTRAINT PR_SU FOREIGN KEY (fkSupplier) REFERENCES Supplier (supplierId);

ALTER TABLE Product ADD CONSTRAINT PR_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE Supplier ADD CONSTRAINT SU_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE Client ADD CONSTRAINT CL_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE [User] ADD CONSTRAINT US_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

-- SOME INSERTS

INSERT INTO [dbo].[State] ( stateName ) VALUES ( 'Active' )
GO

INSERT INTO [dbo].[State] ( stateName ) VALUES ( 'Inactive' )
GO

-- PROCEDURES

-- USER PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[AddUser] 
	@userName varchar(100),
	@userEmail varchar(255),
	@password varchar(255),
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[User] 
		( userName, userEmail, password, fkState ) 
	VALUES 
		( @userName, @userEmail, @password, @fkState )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[LoginUser] 
	@userName varchar(100),
	@password varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT userId, userName FROM [dbo].[User] WHERE userName = @userName AND password = @password
END
GO


-- CLIENT PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[AddClient] 
	@clientName varchar(100),
	@clientEmail varchar(255),
	@clientTel bigint,
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Client] 
		( clientName, clientEmail, clientTel, fkState ) 
	VALUES 
		( @clientName, @clientEmail, @clientTel, @fkState )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ClientsList] 
	@actives bit,
	@filter varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	IF @filter = '' OR @filter = NULL
		BEGIN
			SELECT clientId, clientName, clientEmail, clientTel
			FROM [dbo].[Client]
			WHERE fkState = @actives
		END
	ELSE
		BEGIN
			SET @filter = '%' + @filter + '%'

			SELECT clientId, clientName, clientEmail, clientTel
			FROM [dbo].[Client]
			WHERE fkState = @actives AND
				  clientName LIKE @filter OR 
				  clientTel LIKE @filter OR
				  clientEmail LIKE @filter
		END
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ClientObject] 
	@id int,
	@actives bit
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT clientId, clientName
	FROM [dbo].[Client]
	WHERE fkState = @actives AND clientId = @id
END
GO


-- SUPPLIER PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[AddSupplier] 
	@supplierName varchar(100),
	@supplierEmail varchar(255),
	@supplierTel bigint,
	@supplierDescription varchar(255),
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Supplier] 
		( supplierName, supplierEmail, supplierTel, supplierDescription, fkState ) 
	VALUES 
		( @supplierName, @supplierEmail, @supplierTel, @supplierDescription,@fkState )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[SuppliersList] 
	@actives bit,
	@filter varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	IF @filter = '' OR @filter = NULL
		BEGIN
			SELECT supplierId, supplierName, supplierTel, supplierEmail, supplierDescription
			FROM [dbo].[Supplier]
			WHERE fkState = @actives
		END
	ELSE
		BEGIN
			SET @filter = '%' + @filter + '%'

			SELECT supplierId, supplierName, supplierTel, supplierEmail, supplierDescription
			FROM [dbo].[Supplier]
			WHERE fkState = @actives AND
				  supplierName LIKE @filter OR 
				  supplierTel LIKE @filter OR
				  supplierEmail LIKE @filter OR 
				  supplierDescription LIKE @filter 
		END
END
GO


-- LOGG PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[AddLogg] 
	@logDetail varchar(255),
	@logDate date,
	@logTime time(7),
	@fkUser smallint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Logg] 
		( logDetail, logDate, logTime, fkUser ) 
	VALUES 
		( @logDetail, @logDate, @logTime, @fkUser )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[LoggsList] 
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT logDetail, logDate, logTime, userName
	FROM Logg INNER  JOIN [dbo].[User] ON fkUser = userId
END
GO



/*
ALTER TABLE Purchase DROP CONSTRAINT FKPurchase520850;
ALTER TABLE Refund DROP CONSTRAINT FKRefund496037;
ALTER TABLE Sale DROP CONSTRAINT FKSale550232;
ALTER TABLE Sale DROP CONSTRAINT FKSale148848;
ALTER TABLE Log DROP CONSTRAINT FKLog641589;
ALTER TABLE Product DROP CONSTRAINT FKProduct310633;
ALTER TABLE Product DROP CONSTRAINT FKProduct138986;
ALTER TABLE Supplier DROP CONSTRAINT FKSupplier989295;
ALTER TABLE Client DROP CONSTRAINT FKClient195508;
ALTER TABLE [User] DROP CONSTRAINT FKUser298032;
DROP TABLE Client;
DROP TABLE Logg;
DROP TABLE Product;
DROP TABLE Purchase;
DROP TABLE Refund;
DROP TABLE Sale;
DROP TABLE State;
DROP TABLE Supplier;
DROP TABLE [User];
*/
```

