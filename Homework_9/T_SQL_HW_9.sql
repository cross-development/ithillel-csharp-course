﻿﻿-- Створення бази даних StudentGradesDB.
-- [CREATE DATABASE] – Створює нову базу даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE DATABASE StudentGradesDB; 
GO								 

-- Використання створеної бази даних.
-- [USE] – Вказує, що для наступних команд слід використовувати базу даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
USE StudentGradesDB; 
GO

-- Створення таблиці StudentGrades.
-- [CREATE TABLE] – Створює таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE TABLE StudentGrades (					
    StudentId INT IDENTITY(1,1) PRIMARY KEY,	-- Унікальний ідентифікатор студента
    FullName NVARCHAR(100) NOT NULL,			-- ПІБ студента
    City NVARCHAR(50),							-- Місто студента
    Country NVARCHAR(50),						-- Країна студента
    Birthdate DATE,								-- Дата народження студента
    Email NVARCHAR(100),						-- Електронна адреса студента
    Phone NVARCHAR(20),							-- Контактний телефон студента
    GroupName NVARCHAR(50),						-- Назва групи студента
    AverageGrade DECIMAL(3, 2),					-- Середня оцінка за рік з усіх предметів
    SubjectMinGrade NVARCHAR(50),				-- Предмет з мінімальною середньою оцінкою
    SubjectMaxGrade NVARCHAR(50)				-- Предмет з максимальною середньою оцінкою
);
GO

-- Додавання кількох записів до таблиці StudentGrades.
-- [INSERT INTO] – Вставляє дані в таблицю.
-- [VALUES] - Вказує, що далі будуть іти значення, які потрібно вставити в таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
INSERT INTO StudentGrades 
(FullName, City, Country, Birthdate, Email, Phone, GroupName, AverageGrade, SubjectMinGrade, SubjectMaxGrade)
VALUES 
('John Doe', 'New York', 'USA', '2000-05-12', 'john.doe@example.com', '555-1234', 'Group A', 3.5, 'Mathematics', 'Physics'),
('Jane Smith', 'Los Angeles', 'USA', '2001-10-24', 'jane.smith@example.com', '555-5678', 'Group B', 4.2, 'History', 'Chemistry'),
('Robert Brown', 'Chicago', 'USA', '2000-03-15', 'robert.brown@example.com', '555-9101', 'Group A', 2.8, 'English', 'Biology'),
('Anna Kowalska', 'Los Angeles', 'USA', '2001-08-10', 'anna.kowalska@example.com', '555-5432', 'Group B', 2.9, 'Biology', 'Physics');
GO

-- Перевірка даних за допомогою вибірки з таблиці StudentGrades.
-- Вибирає всі (*) дані з таблиці StudentGrades.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT * FROM StudentGrades; 
GO							 

-- Відображати ПІБ усіх студентів.
-- Вибирає тільки ПІБ студентів з таблиці StudentGrades.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT FullName FROM StudentGrades;
GO

-- Відображати усіх середніх оцінок.
-- Вибирає лише середню оцінку студентів з таблиці StudentGrades.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT AverageGrade FROM StudentGrades;
GO

-- Показати ПІБ усіх студентів з мінімальною оцінкою, більшою, ніж зазначена.
-- Вибирає ПІБ лише тих студентів, які мають середній бал більше 3.0.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [WHERE] - Фільтрує рядки за умовою.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT FullName FROM StudentGrades
WHERE AverageGrade > 3.0;	 
GO

-- Показати країни студентів. Назви країн мають бути унікальними.
-- Вибирає унікальні країни з таблиці StudentGrades.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [DISTINCT] - Повертає лише унікальні значення.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT DISTINCT Country FROM StudentGrades; 
GO

-- Показати міста студентів. Назви міст мають бути унікальними.
-- Вибирає унікальні міста з таблиці StudentGrades.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [DISTINCT] - Повертає лише унікальні значення.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT DISTINCT City FROM StudentGrades;
GO

-- Показати назви груп. Назви груп мають бути унікальними.
-- Вибирає унікальні групи з таблиці StudentGrades.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [DISTINCT] - Повертає лише унікальні значення.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT DISTINCT GroupName FROM StudentGrades;
GO

-- Показати назви предметів. Назви предметів мають бути унікальними.
-- Вибирає унікальні предмети, які вказані в SubjectMinGrade та SubjectMaxGrade, а потім об'єднує результати в таблицю з колонкою SubjectName.
-- [SELECT] – Виконує запит вибірки всіх даних з таблиці.
-- [DISTINCT] - Повертає лише унікальні значення.
-- [AS] - Дає псевдонім колонці або таблиці.
-- [FROM] - Вказує з якої таблиці робити вибірку даних.
-- [UNION] - Об’єднує результати кількох запитів без дублікатів.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
SELECT DISTINCT SubjectMinGrade AS SubjectName FROM StudentGrades
UNION
SELECT DISTINCT SubjectMaxGrade FROM StudentGrades;
GO
