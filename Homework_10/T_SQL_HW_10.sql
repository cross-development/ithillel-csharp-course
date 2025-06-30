﻿-- Створення бази даних HospitalDB.
-- [CREATE DATABASE] – Створює нову базу даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE DATABASE HospitalDB;
GO

-- Використання створеної бази даних.
-- [USE] – Вказує, що для наступних команд слід використовувати базу даних.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
USE HospitalDB;
GO

-- Створення таблиці Departments.
-- [CREATE TABLE] – Створює таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE TABLE Departments (
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Financing MONEY NOT NULL CHECK (Financing >= 0) DEFAULT 0,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
);
GO

-- Створення таблиці Diseases.
-- [CREATE TABLE] – Створює таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE TABLE Diseases (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
	Severity INT NOT NULL CHECK (Severity >= 1) DEFAULT 1,
);
GO

-- Створення таблиці Doctors.
-- [CREATE TABLE] – Створює таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE TABLE Doctors (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(max) NOT NULL CHECK (Name <> ''),
	Surname NVARCHAR(max) NOT NULL CHECK (Surname <> ''),
	Phone CHAR(10) NULL,
	Salary MONEY NOT NULL CHECK (Salary > 0),
);
GO

-- Створення таблиці Examinations.
-- [CREATE TABLE] – Створює таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE TABLE Examinations (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
	DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
	StartTime TIME NOT NULL CHECK (StartTime >= '08:00' AND StartTime <= '18:00'), 
	EndTime TIME NOT NULL,
	CHECK (EndTime > StartTime),
);
GO

-- Створення таблиці Wards.
-- [CREATE TABLE] – Створює таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
CREATE TABLE Wards (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
	Floor INT NOT NULL CHECK (Floor >= 1),
	Name NVARCHAR(20) NOT NULL UNIQUE CHECK (Name <> ''),
);
GO

-- Додавання кількох записів до таблиці Departments.
-- [INSERT INTO] – Вставляє дані в таблицю.
-- [VALUES] - Вказує, що далі будуть іти значення, які потрібно вставити в таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
INSERT INTO Departments (Building, Financing, Name)
VALUES	(1, 10000, 'Cardiology'),
		(3, 14000, 'Neurology'),
		(5, 25000, 'Oncology'),
		(3, 13000, 'Pediatrics'),
		(5, 27000, 'Gastroenterology'),
		(2, 5000, 'Orthopedics'),
		(4, 30000, 'Urology');
GO

-- Додавання кількох записів до таблиці Diseases.
-- [INSERT INTO] – Вставляє дані в таблицю.
-- [VALUES] - Вказує, що далі будуть іти значення, які потрібно вставити в таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
INSERT INTO Diseases (Name, Severity)
VALUES	('Flu', 1),
		('Pneumonia', 3),
		('Cancer', 5),
		('Diabetes', 2),
		('Hypertension', 2),
		('Arthritis', 3),
		('Tuberculosis', 4);
GO

-- Додавання кількох записів до таблиці Doctors.
-- [INSERT INTO] – Вставляє дані в таблицю.
-- [VALUES] - Вказує, що далі будуть іти значення, які потрібно вставити в таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
INSERT INTO Doctors (Name, Surname, Phone, Salary)
VALUES	('John', 'Smith', '0501234567', 1600),
		('Alice', 'Johnson', '0677654321', 1700),
		('Robert', 'Brown', NULL, 1400),
		('Nancy', 'Davis', '0931112223', 2000),
		('Michael', 'Miller', '0509990001', 1500),
		('Nina', 'Nelson', '0970001112', 1550);
GO

-- Додавання кількох записів до таблиці Examinations.
-- [INSERT INTO] – Вставляє дані в таблицю.
-- [VALUES] - Вказує, що далі будуть іти значення, які потрібно вставити в таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
INSERT INTO Examinations (Name, DayOfWeek, StartTime, EndTime)
VALUES	('Ultrasound', 1, '12:00', '13:00'),
		('MRI', 2, '14:00', '15:30'),
		('CT Scan', 3, '11:00', '12:30'),
		('Blood Test', 4, '09:00', '10:00'),
		('X-Ray', 5, '10:00', '11:00'),
		('Endoscopy', 2, '12:30', '13:30'),
		('ECG', 1, '08:30', '09:30');
GO

-- Додавання кількох записів до таблиці Wards.
-- [INSERT INTO] – Вставляє дані в таблицю.
-- [VALUES] - Вказує, що далі будуть іти значення, які потрібно вставити в таблицю.
-- [GO] - сигналізує, що все, що йде вище, - це один пакет, який потрібно надіслати серверу на виконання.
INSERT INTO Wards (Building, Floor, Name)
VALUES	(4, 1, 'Ward A'),
		(5, 1, 'Ward B'),
		(2, 2, 'Ward C'),
		(1, 3, 'Ward D'),
		(3, 2, 'Ward E'),
		(4, 2, 'Ward F'),
		(5, 3, 'Ward G');
GO

-- 1. Вивести вміст таблиці палат.
-- Відображає всі записи з таблиці Wards (усі стовпці й рядки).
-- [SELECT *] – вибірка всіх полів таблиці.
-- [FROM Wards] – вибірка з таблиці палат.
SELECT * 
FROM Wards;

-- 2. Вивести прізвища та телефони усіх лікарів.
-- Вибирає лише прізвища та номери телефонів з таблиці Doctors.
-- [SELECT Surname, Phone] – вказано конкретні стовпці.
-- [FROM Doctors] – вибірка з таблиці лікарів.
SELECT Surname, Phone 
FROM Doctors;

-- 3. Вивести усі поверхи без повторень, де розміщуються палати.
-- Показує унікальні значення поверхів з таблиці Wards.
-- [SELECT DISTINCT Floor] – унікальні значення з поля Floor.
SELECT DISTINCT Floor 
FROM Wards;

-- 4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
-- [AS "Name of Disease"] – перейменування стовпця для виводу.
-- [AS "Severity of Disease"] – аналогічно для другого стовпця.
SELECT Name AS "Name of Disease", Severity AS "Severity of Disease" 
FROM Diseases;

-- 5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.
-- Псевдоніми d, e, doc полегшують читання.
-- Виводяться назви відділень, обстежень і прізвища лікарів.
-- Без зв'язків між таблицями - декартовий добуток (усі можливі комбінації).
SELECT d.Name AS "Name of Department", e.Name AS "Name of Examination", doc.Surname AS "Doctor Surname"
FROM Departments AS d, Examinations AS e, Doctors AS doc;
-- або
SELECT d.Name AS "Name of Department"
FROM Departments AS d;

SELECT e.Name AS "Name of Examination"
FROM Examinations AS e;

SELECT d.Surname AS "Doctor Surname"
FROM Doctors AS d;

-- 6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000.
-- Умова WHERE обмежує вибірку двома критеріями.
SELECT Name
FROM Departments
WHERE Building = 5 AND Financing < 30000;

-- 7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000.
-- [BETWEEN] – перевірка, чи значення в заданому діапазоні.
SELECT Name
FROM Departments
WHERE Building = 3 AND Financing BETWEEN 12000 AND 15000;

-- 8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
-- Об’єднано умову по корпусу (OR) і поверху (AND).
SELECT Name
FROM Wards
WHERE (Building = 4 OR Building = 5) AND Floor = 1;

-- 9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 6 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
-- Умови згруповані для логічної точності.
SELECT Name, Building, Financing 
FROM Departments 
WHERE (Building = 3 OR Building = 5) AND (Financing < 11000 OR Financing > 25000);

-- 10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
-- Передбачається, що ставка й надбавка вже враховані в полі Salary.
SELECT Surname
FROM Doctors
WHERE Salary > 1500;

-- 11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку.
-- Надбавка умовно прийнята як 300 (оскільки в таблиці немає такого поля).
SELECT Surname 
FROM Doctors 
WHERE Salary / 2 > 3 * 300;

-- 12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
-- Тут нічого особливого, просто перелічені умови через AND, яким мають відповідати записи.
SELECT DISTINCT Name
FROM Examinations
WHERE DayOfWeek BETWEEN 1 AND 3 AND StartTime >= '12:00' AND EndTime <= '15:00';

-- 13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
-- [IN (...)] – перевірка, чи значення поля входить у список.
SELECT Name, Building 
FROM Departments 
WHERE Building IN (1, 3, 8, 10);

-- 14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
-- [NOT IN (...)] – виключення заданих значень з результату.
SELECT Name 
FROM Diseases 
WHERE Severity NOT IN (1, 2);

-- 15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
-- Використано [NOT IN] для виключення з результату.
SELECT Name 
FROM Departments 
WHERE Building NOT IN (1, 3);

-- 16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
-- Аналог попереднього запиту, але без [NOT].
SELECT Name 
FROM Departments 
WHERE Building IN (1, 3);

-- 17. Вивести прізвища лікарів, що починаються з літери «N».
-- [LIKE 'N%'] – шаблон пошуку прізвищ, які починаються на 'N'.
SELECT Surname 
FROM Doctors 
WHERE Surname LIKE 'N%';