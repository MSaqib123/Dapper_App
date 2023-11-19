create database dapper_db
use dapper_db
select * from Person
create table dbo.Person(
	Id int	primary key identity,
	Name nvarchar(100) not null,
	Email nvarchar(100) not null,
	[Address] nvarchar(200) not null
)


-- Inserting records into the dbo.Person table
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('John Smith', 'john@example.com', '123 Main St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Jane Doe', 'jane@example.com', '456 Elm St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Michael Lee', 'michael@example.com', '789 Oak St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Emily Johnson', 'emily@example.com', '101 Pine St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('David Brown', 'david@example.com', '202 Maple St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Sarah Wilson', 'sarah@example.com', '303 Cedar St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Daniel Miller', 'daniel@example.com', '404 Birch St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Linda Davis', 'linda@example.com', '505 Spruce St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Brian Wilson', 'brian@example.com', '606 Pineapple St, City, Country');
INSERT INTO dbo.Person (Name, Email, Address) VALUES ('Melissa Anderson', 'melissa@example.com', '707 Orange St, City, Country');

CREATE PROCEDURE spInsertPerson
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(200)
AS
BEGIN
    INSERT INTO dbo.Person (Name, Email, Address)
    VALUES (@Name, @Email, @Address);
END

CREATE PROCEDURE spUpdatePerson
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(200)
AS
BEGIN
    UPDATE dbo.Person
    SET Name = @Name,
        Email = @Email,
        Address = @Address
    WHERE Id = @Id;
END

select * from Person
CREATE PROCEDURE spDeletePerson
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Person
    WHERE Id = @Id;
END

CREATE PROCEDURE spGetAllPersons
AS
BEGIN
    SELECT * FROM dbo.Person;
END


CREATE PROCEDURE spGetPersonById
    @Id INT
AS
BEGIN
    SELECT * FROM dbo.Person
    WHERE Id = @Id;
END

