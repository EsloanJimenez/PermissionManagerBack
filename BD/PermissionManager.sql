CREATE DATABASE PermissionManagger;

USE PermissionManagger;

CREATE TABLE PermissionType(
	PermissionTypeId INT IDENTITY(1,1) PRIMARY KEY,
	Description VARCHAR(50) NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModifyDate DATETIME,
	DeletedDate DATETIME,
	Deleted BIT DEFAULT 0
);

INSERT INTO PermissionType (Description) VALUES ('Enfermedad'), ('Diligencias'), ('Otros');

CREATE TABLE Permission(
	PermissionId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	PermissionTypeId INT NOT NULL,
	PermissionDate DATETIME NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	ModifyDate DATETIME,
	DeletedDate DATETIME,
	Deleted BIT DEFAULT 0
	FOREIGN KEY (PermissionTypeId) REFERENCES PermissionType(PermissionTypeId)
);