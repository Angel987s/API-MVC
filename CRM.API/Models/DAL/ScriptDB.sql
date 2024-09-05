﻿-- Crear la base de datos CRMDB
CREATE DATABASE CRMDB
GO

-- Utilizar la base de datos CRMDB
USE CRMDB
GO
drop table Customers
select * from Customers
-- Crear la tabla Customers (anteriormente Clients)
CREATE TABLE Customers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Address VARCHAR(255)
)
GO
