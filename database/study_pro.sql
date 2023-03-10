USE master
GO
--drop database if it exists
IF DB_ID('StudyPro') IS NOT NULL
BEGIN
	ALTER DATABASE StudyPro SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE StudyPro
END
GO

CREATE DATABASE StudyPro
GO
PRINT 'StudyPro database created'

USE StudyPro
GO
PRINT ''
PRINT '---------------'
PRINT 'Creating tables'
PRINT '---------------'
PRINT ''

CREATE TABLE dbo.Users
(
	UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserName NVARCHAR(200) NOT NULL,
	HashedPassword NVARCHAR(2000) NOT NULL,
	Salt NVARCHAR(2000) NOT NULL
)

CREATE TABLE dbo.Card
(
	CardID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	CategoryID INT NOT NULL,
	Term NVARCHAR(50) NOT NULL,
	Level INT NOT NULL,
	Definition NVARCHAR(MAX) NOT NULL,
	Question NVARCHAR(MAX) NULL,
	ImagePath NVARCHAR(MAX) NULL
)

CREATE TABLE dbo.Category
(
	CategoryID INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	Category NVARCHAR(50) NOT NULL
)


GO
PRINT 'Users table created.'


PRINT ''
PRINT '--------------------'
PRINT 'Populating tables'
PRINT '--------------------'
PRINT ''
GO

-- all passwords are password
SET IDENTITY_INSERT Users ON
GO
INSERT INTO Users (UserId, UserName, HashedPassword, Salt)
VALUES (1, 'autumn', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (2, 'christoph', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (3, 'cody', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (4, 'manuel', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
     , (5, 'gregor', N'��r���rp�ӽ!$ץ��TG�σ��3P#fuR',N'^l}.��h�P��}�B�/�t��;�m��')
GO
SET IDENTITY_INSERT Users OFF
GO

PRINT 'Inserting Data'
INSERT INTO Card (Term, CategoryID, Level, Definition)
VALUES	('What is C#', 1, 1, 'A programming language for writing Microsoft .NET applications. Uses OOPs: Encapsulation, Abstraction, Encapsulation, Polymorphism, Inheritance'),
		('What is an Object?', 1, 1, 'An instance of a class. All members of the class can be accessed through the object'),
		('Difference between break and continue statements', 1, 1, 'Break: jumps out of a loop  Continue: jump over one iteration of a loop'),
		('What are Property Accessors?', 1, 1, 'The get and set portion of a property'),
		('What is Inheritance', 2, 2, 'Gives the ability to define a class in terms of another class, which makes it easier to reuse code. IS-A relationship A dog IS-A mammal'),
		('What is Object-Oriented Programming (OOP)', 2, 2, 'A technique to develop logical modules. An object is created to represdent a class. Therefore, an object encapsulates all the features of the class. Gives the ability to develop modular programs.'),
		('Define a Temp Table', 3, 1, 'A temporary storage structure to store data and manipulate it before it reaches its destination format'),
		('What is a view?', 3, 1, 'A virtual table that is made by joining "real" tables'),
		('What is a PIMARY KEY', 3, 1, 'A unique identifier for a row within a database table. Every table should have a primary key'),
		('What is ASP.NET MVC', 4, 1, 'A lightweight web application Framework. MVC seperates the application into three components: Model, View, and Conroller'),
		('What is Layout in MVC?', 4, 1, 'Used to set the common look across multiple pages.'),
		('Explain Equality', 5, 1, '(===) Strict Comparison: equal value and type. (==) Abstact Comparison: equal to'),
		('What is Scope', 5, 1, 'Each function has its own scope. Only code inside of that function can access that functions scoped variables'),
		('What is the typeof operator?', 5, 1, 'It can examine a value and return its type'),
		('What is the object type?', 5, 1, 'It refers to a compuond value where you can set the properties'),
		('Explain an array in JavaScript', 5, 1, 'An object that holds values of any type in numerically indexed positions'),
		('What is Managed code?', 1, 2, 'Code which is developed in the .NET framework'),
		('Boxing', 1, 2, 'The process of moving a variable from the stack to the heap.'),
		('Unboxing', 1, 2, 'The process of moving a variable from the heap to the stack.'),
		('Generics', 1, 2,'Allows you to write a class or method that can work with any data type.'),
		('Value Type', 1, 2, 'Holds the value of a variable in the stack'),
		('Reference Type', 1, 2, 'Holds the memory address of a variables value. Points to the heap.'),
		('Exception Handling Format', 1, 2, 'Try - contains a block of code that is to be checked. Catch - program that catches an exception if the try block fails. Finally - block of code that is executed regardless of the outcome of the try block.'),
		('Namespace', 1, 2, 'Virtual folder directory to organize classes and folders'),
		('Public VS Internal class', 1, 2, 'Public - accessable throughout the entire application. Internal - accessable only in that namespace.'),
		('Nullable Type', 1, 2, 'Variable can be null or have a value. Is stored on the heap.'),
		('Finally Purpose', 1, 2, 'It is excecuted no matter what, so it can be used to close the connection to the database.'),
		('Ways to pass parameters into a method', 1, 2, 'Value parameters - passes the value into the function. Reference parameters - passes a referenced variable into a function and changes its value. Output parameters - Helps in returning more than value.'),
		('Encapsulation', 2, 2, ''),
		('Polymorphism', 2, 2, ''),
		('Abstraction', 2, 2, ''),
		('What is a Class?', 2, 2, 'Describes the attributes of an object. Can contain functions and properties.'),
		('Virtual', 2, 2, 'Makes it possible to override'),
		('Constructor', 2, 2, 'A special method in a class that is call automatically.'),
		('Foreign Key', 3, 2, 'Points to a primary key in another table. creates a link between tables.'),
		('Default', 3, 2, 'Allows a preset value to be added to that column if a value isnt given'),
		('Razor Pages', 4, 2, 'Makes coding page focused.'),
		('Explaing MVC', 4, 2, 'Model - a representation of the applications data. Controller - Handles the request from the user and deligates resposibilty to the corrisponding view. View - The presentation of the data.'),
		('Null VS Undefined', 5, 2, 'Null - currently unavailable. Undefined - hasnt been initialized'),
		('Value Types', 5, 2, '* string * number * boolean * null & undefined * object * symbol * Defined by let, const, or var'),
		('let', 5, 1, 'Variable declaration variable')

INSERT INTO Category (Category)
VALUES	('C#'),
		('OOP'),
		('SQL'),
		('ASP.NET MVC'),
		('Java Script')

ALTER TABLE [Card]
ADD CONSTRAINT FK_Card_Category
FOREIGN KEY (CategoryID)
REFERENCES Category(CategoryID)

