### Data Base

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
  clientId    INT IDENTITY NOT NULL, 
  clientName  VARCHAR(100) NOT NULL, 
  clientEmail VARCHAR(255) NULL, 
  clientTel   BIGINT NULL, 
  fkState     TINYINT NOT NULL )
GO

CREATE TABLE Logg (
  logId     BIGINT IDENTITY NOT NULL, 
  logDetail VARCHAR(255) NOT NULL, 
  logDate   DATETIME NOT NULL, 
  fkUser    SMALLINT NOT NULL )
GO

CREATE TABLE Code (
  codeId BIGINT IDENTITY NOT NULL,
  code VARCHAR(100) )
GO

CREATE TABLE Product (
  productId     BIGINT IDENTITY NOT NULL, 
  productDetail VARCHAR(500) NOT NULL, 
  cant          INT NOT NULL, 
  price         DECIMAL(10, 2) NOT NULL, 
  fkCode        BIGINT NOT NULL,
  fkState       TINYINT NOT NULL )
GO

CREATE TABLE Sale (
  saleId       BIGINT IDENTITY NOT NULL, 
  saleDetail   VARCHAR(1500) NOT NULL, 
  saleDate     DATETIME NOT NULL,
  saleSubTotal DECIMAL(10, 2) NOT NULL,
  saleDiscount DECIMAL(10, 2) NOT NULL,
  saleTax      DECIMAL(10, 2) NOT NULL,
  saleTotal    DECIMAL(10, 2) NOT NULL, 
  fkUser       SMALLINT NOT NULL, 
  fkClient     INT NOT NULL,
  fkState      TINYINT NOT NULL )
GO

CREATE TABLE State (
  stateId   TINYINT IDENTITY NOT NULL, 
  stateName CHAR(50) NOT NULL UNIQUE )
GO

CREATE TABLE [User] (
  userId    SMALLINT IDENTITY NOT NULL, 
  userName  VARCHAR(100) NOT NULL, 
  userEmail VARCHAR(255) NULL, 
  password  VARCHAR(255) NOT NULL, 
  fkState   TINYINT NOT NULL, 
  fkRol     TINYINT NOT NULL )
GO

CREATE TABLE Rol (
  rolId   tinyint IDENTITY NOT NULL, 
  rolName char(50) NOT NULL UNIQUE )
GO



-- PRIMARY KEYs

ALTER TABLE Client ADD PRIMARY KEY (clientId)
GO

ALTER TABLE Logg ADD PRIMARY KEY (logId)
GO

ALTER TABLE Code ADD PRIMARY KEY (codeId)
GO

ALTER TABLE Product ADD PRIMARY KEY (productId)
GO

ALTER TABLE Sale ADD PRIMARY KEY (saleId)
GO

ALTER TABLE State ADD PRIMARY KEY (stateId)
GO

ALTER TABLE [User] ADD PRIMARY KEY (userId)
GO

ALTER TABLE Rol ADD PRIMARY KEY (rolId)
GO



-- INDEXs

CREATE INDEX Code_codeId 
  ON Code (codeId)
GO

CREATE INDEX Rol_rolId 
  ON Rol (rolId)
GO

CREATE INDEX Client_clientId 
  ON Client (clientId)
GO

CREATE INDEX Log_logId 
  ON Logg (logId)
GO

CREATE INDEX Product_productId 
  ON Product (productId)
GO


CREATE INDEX Sale_saleId 
  ON Sale (saleId)
GO

CREATE INDEX State_stateId 
  ON State (stateId)
GO

CREATE INDEX User_userId 
  ON [User] (userId)
GO



-- FOREIGN KEYs


ALTER TABLE Sale ADD CONSTRAINT SA_CL FOREIGN KEY (fkClient) REFERENCES Client (clientId);

ALTER TABLE Sale ADD CONSTRAINT SA_US FOREIGN KEY (fkUser) REFERENCES [User] (userId);

ALTER TABLE Sale ADD CONSTRAINT SA_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE Logg ADD CONSTRAINT LO_US FOREIGN KEY (fkUser) REFERENCES [User] (userId);

ALTER TABLE Product ADD CONSTRAINT PR_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE Client ADD CONSTRAINT CL_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE [User] ADD CONSTRAINT US_ST FOREIGN KEY (fkState) REFERENCES State (stateId);

ALTER TABLE [User] ADD CONSTRAINT US_RO FOREIGN KEY (fkRol) REFERENCES Rol (rolId);

ALTER TABLE Product ADD CONSTRAINT PR_CO FOREIGN KEY (fkCode) REFERENCES Code (codeId);



-- SOME INSERTS

INSERT INTO [dbo].[State] ( stateName ) VALUES ( 'Active' )
GO

INSERT INTO [dbo].[State] ( stateName ) VALUES ( 'Inactive' )
GO

INSERT INTO [dbo].[Rol] ( rolName ) VALUES ( 'Administrador' )
GO

INSERT INTO [dbo].[Rol] ( rolName ) VALUES ( 'Usuario' )
GO

INSERT INTO [User] 
( userName, userEmail, password, fkState, fkRol )
VALUES
( 'abdul', '', 'HCNhE36R7pQLCD0B2cbVqQ==', 1, 1)
GO


INSERT INTO [User] 
( userName, userEmail, password, fkState, fkRol )
VALUES
( 'robert', '', 'LHvf2IwkzNuocVwT+QeJzg==', 1, 2)
GO


-- PROCEDURES

-- USER PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[AddUser] 
	@userName varchar(100),
	@userEmail varchar(255),
	@password varchar(255),
	@fkState tinyint,
	@fkRol tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[User] 
		( userName, userEmail, password, fkState, fkRol ) 
	VALUES 
		( @userName, @userEmail, @password, @fkState, @fkRol )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[UpdateUser] 
	@userId int,
	@userName varchar(100),
	@userEmail varchar(255),
	@fkRol tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[User] 
	SET userName = @userName, userEmail = @userEmail, fkRol = @fkRol
		 WHERE userId = @userId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[DeleteUser] 
	@userId int,
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[User] 
	SET fkState = @fkState WHERE userId = @userId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[UpdatePassword] 
	@userId int,
	@password varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[User] 
	SET password = @password
		 WHERE userId = @userId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[UsersList] 
	@actives bit,
	@filter varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;
	
	IF @filter = '' OR @filter = NULL
		BEGIN
			SELECT userId, userName, userEmail, rolName
			FROM [dbo].[User] INNER JOIN [dbo].[Rol] ON fkRol = rolId
			WHERE fkState = @actives 
		END
	ELSE
		BEGIN
			SET @filter = '%' + @filter + '%'

			SELECT userId, userName, userEmail, rolName
			FROM [dbo].[User] INNER JOIN [dbo].[Rol] ON fkRol = rolId
			WHERE fkState = @actives  
				  AND
				  userName LIKE @filter OR 
				  userEmail LIKE @filter 
		END
END
GO


CREATE OR ALTER PROCEDURE [dbo].[LoginUser] 
	@userName varchar(100),
	@password varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT userId, userName FROM [dbo].[User] 
	WHERE userName = @userName AND password = @password
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ConsultUserName] 
	@userName varchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT userId FROM [dbo].[User] 
	WHERE userName = @userName 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ConsultUserEmail] 
	@userEmail varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT userId FROM [dbo].[User] 
	WHERE userEmail = @userEmail 
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


CREATE OR ALTER PROCEDURE [dbo].[UpdateClient] 
	@clientId int,
	@clientName varchar(100),
	@clientEmail varchar(255),
	@clientTel bigint
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[Client] 
	SET clientName = @clientName, clientEmail = @clientEmail, 
		 clientTel = @clientTel WHERE clientId = @clientId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[DeleteClient] 
	@clientId int,
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[Client] 
	SET fkState = @fkState WHERE clientId = @clientId 
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


CREATE OR ALTER PROCEDURE [dbo].[ConsultClientEmail] 
	@clientEmail varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT clientId FROM [dbo].[Client] 
	WHERE clientEmail = @clientEmail 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ConsultClientTel] 
	@clientTel varchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT clientId FROM [dbo].[Client] 
	WHERE clientTel = @clientTel 
END
GO


-- LOGG PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[AddLogg] 
	@logDetail varchar(255),
	@logDate datetime,
	@fkUser smallint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Logg] 
		( logDetail, logDate, fkUser ) 
	VALUES 
		( @logDetail, @logDate, @fkUser )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[LoggsList] 
	@filter varchar(255),
	@fromDate datetime,
	@toDate datetime
AS
BEGIN
	SET NOCOUNT OFF;

	IF @filter = '' OR @filter = NULL
		BEGIN
			SELECT logDetail, logDate, userName
			FROM Logg INNER  JOIN [dbo].[User] ON fkUser = userId
			WHERE logDate BETWEEN @fromDate AND @toDate
		END
	ELSE
		BEGIN
			SET @filter = '%' + @filter + '%'

			SELECT logDetail, logDate, userName
			FROM Logg INNER  JOIN [dbo].[User] ON fkUser = userId
			WHERE logDetail LIKE @filter AND
			logDate BETWEEN @fromDate AND @toDate
		END
END
GO

-- PRODUCT PROCEDURES


CREATE OR ALTER PROCEDURE [dbo].[AddProduct] 
	@productDetail varchar(255),
	@cant int,
	@price decimal(10, 2),
	@fkCode bigint,
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Product]  
	( productDetail, cant, price, fkCode, fkState ) 
	VALUES  
	( @productDetail, @cant, @price, @fkCode, @fkState )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[UpdateProduct] 
	@productId bigint,
	@productDetail varchar(255),
	@cant int,
	@price decimal(10, 2),
	@fkCode bigint
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[Product] 
	SET productDetail = @productDetail, cant = @cant, 
		 price = @price, fkCode = @fkCode 
		 WHERE productId = @productId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[DeleteProduct] 
	@productId bigint,
	@fkState tinyint
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[Product] 
	SET  fkState = @fkState 
		 WHERE productId = @productId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ProductsList] 
	@actives bit,
	@filter varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	IF @filter = '' OR @filter = NULL
		BEGIN
			SELECT productId, productDetail, cant, price, codeId  AS pCodeId, code AS pCode
			FROM [dbo].[Product] INNER JOIN [dbo].[Code]
			ON fkCode = codeId
			WHERE fkState = @actives
		END
	ELSE
		BEGIN
			SET @filter = '%' + @filter + '%'

			SELECT productId, productDetail, cant, price, code
			FROM [dbo].[Product] INNER JOIN [dbo].[Code]
			ON fkCode = codeId
			WHERE fkState = @actives AND
				  productDetail LIKE @filter OR 
				  code LIKE @filter OR
				  price LIKE @filter
		END
END
GO



-- CODE PROCEDURES


CREATE OR ALTER PROCEDURE [dbo].[AddCode] 
	@code varchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	INSERT INTO [dbo].[Code]  ( code ) 
	VALUES  ( @code )
END
GO


CREATE OR ALTER PROCEDURE [dbo].[UpdateCode] 
	@codeId bigint,
	@code varchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	UPDATE [dbo].[Code] 
	SET code = @code WHERE codeId = @codeId 
END
GO


CREATE OR ALTER PROCEDURE [dbo].[CodeList] 
	@filter varchar(255)
AS
BEGIN
	SET NOCOUNT OFF;

	IF @filter = '' OR @filter = NULL
		BEGIN
			SELECT codeId, code FROM Code  
		END
	ELSE
		BEGIN
			SET @filter = '%' + @filter + '%'

			SELECT codeId, code FROM Code
			WHERE code LIKE @filter 
		END
END
GO


CREATE OR ALTER PROCEDURE [dbo].[ConsultCode] 
	@code varchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT codeId FROM [dbo].[Code] 
	WHERE code = @code 
END
GO


-- SALE PROCEDURES


-- ROLE PROCEDURES

CREATE OR ALTER PROCEDURE [dbo].[RoleList] 
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT rolId, rolName FROM Rol  
END
GO


```

