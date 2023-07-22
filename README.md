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
```

