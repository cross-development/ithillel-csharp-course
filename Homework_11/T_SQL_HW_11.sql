-- =============================================
-- БАЗА ДАНИХ БАРБЕРШОПУ
-- =============================================

-- =============================================
-- СТВОРЕННЯ БАЗИ ДАНИХ ТА БАЗОВОЇ СТРУКТУРИ
-- =============================================

-- Створюємо нову базу даних для барбершопу
CREATE DATABASE BarbershopDB;
GO

-- Переключаємося на створену базу даних для подальшої роботи
USE BarbershopDB;
GO

-- =============================================
-- СТВОРЕННЯ ТАБЛИЦЬ
-- =============================================

-- Таблиця барберів - зберігає всю інформацію про працівників
CREATE TABLE Barbers (
    barber_id INT IDENTITY(1,1) PRIMARY KEY,    -- Унікальний ідентифікатор барбера (автоінкремент)
    full_name NVARCHAR(100) NOT NULL,           -- ПІБ барбера (обов'язкове поле)
    gender NVARCHAR(10) NOT NULL CHECK (gender IN ('Male', 'Female')), -- Стать з обмеженням значень
    phone NVARCHAR(20) NOT NULL,                -- Контактний телефон
    email NVARCHAR(100) NOT NULL UNIQUE,        -- Email (унікальний для кожного барбера)
    birth_date DATE NOT NULL,                   -- Дата народження
    hire_date DATE NOT NULL,                    -- Дата прийняття на роботу
    position NVARCHAR(20) NOT NULL CHECK (position IN ('Chief Barber', 'Senior Barber', 'Junior Barber')), -- Позиція з обмеженням
    created_at DATETIME DEFAULT GETDATE()       -- Дата створення запису (автоматично)
);

-- Таблиця послуг - каталог всіх послуг, що надаються в барбершопі
CREATE TABLE Services (
    service_id INT IDENTITY(1,1) PRIMARY KEY,   -- Унікальний ідентифікатор послуги
    service_name NVARCHAR(100) NOT NULL,        -- Назва послуги
    description NVARCHAR(255),                  -- Опис послуги (необов'язкове поле)
    created_at DATETIME DEFAULT GETDATE()       -- Дата додавання послуги
);

-- Таблиця послуг барберів - зв'язує барберів з послугами, які вони надають, включаючи ціни та тривалість
CREATE TABLE BarberServices (
    barber_service_id INT IDENTITY(1,1) PRIMARY KEY, -- Унікальний ідентифікатор запису
    barber_id INT NOT NULL,                     -- Посилання на барбера
    service_id INT NOT NULL,                    -- Посилання на послугу
    price DECIMAL(10,2) NOT NULL,               -- Ціна послуги у даного барбера
    duration_minutes INT NOT NULL,              -- Тривалість послуги в хвилинах
    FOREIGN KEY (barber_id) REFERENCES Barbers(barber_id), -- Зв'язок з таблицею барберів
    FOREIGN KEY (service_id) REFERENCES Services(service_id), -- Зв'язок з таблицею послуг
    UNIQUE(barber_id, service_id)               -- Унікальність пари барбер-послуга
);

-- Таблиця клієнтів - зберігає дані про відвідувачів барбершопу
CREATE TABLE Clients (
    client_id INT IDENTITY(1,1) PRIMARY KEY,    -- Унікальний ідентифікатор клієнта
    full_name NVARCHAR(100) NOT NULL,           -- ПІБ клієнта
    phone NVARCHAR(20) NOT NULL,                -- Контактний телефон
    email NVARCHAR(100),                        -- Email (необов'язкове поле)
    created_at DATETIME DEFAULT GETDATE()       -- Дата реєстрації клієнта
);

-- Таблиця розкладу барберів - визначає доступність барберів за датами та часом
CREATE TABLE BarberSchedule (
    schedule_id INT IDENTITY(1,1) PRIMARY KEY,  -- Унікальний ідентифікатор запису розкладу
    barber_id INT NOT NULL,                     -- Посилання на барбера
    work_date DATE NOT NULL,                    -- Дата роботи
    start_time TIME NOT NULL,                   -- Час початку роботи
    end_time TIME NOT NULL,                     -- Час закінчення роботи
    is_available BIT DEFAULT 1,                 -- Доступність (1 - доступний, 0 - зайнятий)
    FOREIGN KEY (barber_id) REFERENCES Barbers(barber_id) -- Зв'язок з таблицею барберів
);

-- Таблиця записів - зберігає інформацію про заброньовані візити
CREATE TABLE Appointments (
    appointment_id INT IDENTITY(1,1) PRIMARY KEY, -- Унікальний ідентифікатор запису
    client_id INT NOT NULL,                     -- Посилання на клієнта
    barber_id INT NOT NULL,                     -- Посилання на барбера
    appointment_date DATE NOT NULL,             -- Дата запису
    appointment_time TIME NOT NULL,             -- Час запису
    status NVARCHAR(20) DEFAULT 'Scheduled' CHECK (status IN ('Scheduled', 'Completed', 'Cancelled')), -- Статус запису
    created_at DATETIME DEFAULT GETDATE(),      -- Дата створення запису
    FOREIGN KEY (client_id) REFERENCES Clients(client_id), -- Зв'язок з таблицею клієнтів
    FOREIGN KEY (barber_id) REFERENCES Barbers(barber_id)  -- Зв'язок з таблицею барберів
);

-- Таблиця архіву відвідувань - зберігає історію завершених візитів з оцінками та відгуками
CREATE TABLE VisitHistory (
    visit_id INT IDENTITY(1,1) PRIMARY KEY,     -- Унікальний ідентифікатор відвідування
    client_id INT NOT NULL,                     -- Посилання на клієнта
    barber_id INT NOT NULL,                     -- Посилання на барбера
    visit_date DATE NOT NULL,                   -- Дата відвідування
    total_cost DECIMAL(10,2) NOT NULL,          -- Загальна вартість послуг
    rating INT CHECK (rating BETWEEN 1 AND 5), -- Оцінка: 1=Дуже погано, 2=Погано, 3=Нормально, 4=Добре, 5=Чудово
    feedback NVARCHAR(500),                     -- Текстовий відгук клієнта
    created_at DATETIME DEFAULT GETDATE(),      -- Дата створення запису
    FOREIGN KEY (client_id) REFERENCES Clients(client_id), -- Зв'язок з таблицею клієнтів
    FOREIGN KEY (barber_id) REFERENCES Barbers(barber_id)  -- Зв'язок з таблицею барберів
);

-- Таблиця послуг відвідування - деталізує які послуги були надані під час кожного візиту
CREATE TABLE VisitServices (
    visit_service_id INT IDENTITY(1,1) PRIMARY KEY, -- Унікальний ідентифікатор запису
    visit_id INT NOT NULL,                      -- Посилання на відвідування
    service_id INT NOT NULL,                    -- Посилання на послугу
    price DECIMAL(10,2) NOT NULL,               -- Ціна послуги під час цього відвідування
    FOREIGN KEY (visit_id) REFERENCES VisitHistory(visit_id), -- Зв'язок з таблицею відвідувань
    FOREIGN KEY (service_id) REFERENCES Services(service_id)  -- Зв'язок з таблицею послуг
);

-- =============================================
-- ДОДАВАННЯ ТЕСТОВИХ ДАНИХ
-- =============================================

-- Додаємо базові послуги барбершопу
INSERT INTO Services (service_name, description) VALUES
('Traditional Beard Shave', 'Класичне гоління бороди небезпечною бритвою'),
('Haircut', 'Професійна стрижка волосся'),
('Beard Trim', 'Підрівнювання та стайлінг бороди'),
('Mustache Styling', 'Догляд та стайлінг вусів'),
('Hair Wash', 'Миття та кондиціонування волосся');

-- Додаємо барберів з різними позиціями
INSERT INTO Barbers (full_name, gender, phone, email, birth_date, hire_date, position) VALUES
('John Smith', 'Male', '+380501234567', 'john.smith@barbershop.com', '1985-03-15', '2020-01-15', 'Chief Barber'),
('Michael Johnson', 'Male', '+380502345678', 'michael.johnson@barbershop.com', '1990-07-20', '2021-03-10', 'Senior Barber'),
('David Brown', 'Male', '+380503456789', 'david.brown@barbershop.com', '1988-11-05', '2021-06-01', 'Senior Barber'),
('Robert Wilson', 'Male', '+380504567890', 'robert.wilson@barbershop.com', '1995-09-12', '2022-02-01', 'Junior Barber'),
('James Davis', 'Male', '+380505678901', 'james.davis@barbershop.com', '1996-12-08', '2022-08-15', 'Junior Barber');

-- Призначаємо послуги барберам з індивідуальними цінами та тривалістю
INSERT INTO BarberServices (barber_id, service_id, price, duration_minutes) VALUES
(1, 1, 250.00, 30), (1, 2, 200.00, 45), (1, 3, 150.00, 20), -- Чиф-барбер має найвищі ціни
(2, 1, 230.00, 30), (2, 2, 180.00, 45), (2, 4, 100.00, 15), -- Синьйор-барбер
(3, 1, 230.00, 30), (3, 2, 180.00, 45), (3, 3, 150.00, 20), -- Синьйор-барбер
(4, 2, 160.00, 45), (4, 3, 130.00, 20), (4, 5, 80.00, 15),  -- Джуніор-барбер
(5, 2, 160.00, 45), (5, 4, 90.00, 15), (5, 5, 80.00, 15);   -- Джуніор-барбер

-- Додаємо клієнтів
INSERT INTO Clients (full_name, phone, email) VALUES
('Alex Petrov', '+380671234567', 'alex.petrov@email.com'),
('Sergey Ivanov', '+380672345678', 'sergey.ivanov@email.com'),
('Anton Kovalenko', '+380673456789', 'anton.kovalenko@email.com'),
('Dmitry Shevchenko', '+380674567890', 'dmitry.shevchenko@email.com'),
('Pavel Bondarenko', '+380675678901', 'pavel.bondarenko@email.com');

-- Додаємо історію відвідувань для демонстрації постійних клієнтів
INSERT INTO VisitHistory (client_id, barber_id, visit_date, total_cost, rating, feedback) VALUES
(1, 1, '2024-01-15', 450.00, 5, 'Відмінний сервіс, дуже професійно'),
(1, 2, '2024-02-20', 410.00, 4, 'Гарна робота, прийду ще'),
(1, 1, '2024-03-25', 450.00, 5, 'Завжди найкраща якість'),
(2, 3, '2024-01-10', 380.00, 4, 'Чудовий досвід'),
(2, 1, '2024-02-15', 450.00, 5, 'Ідеально як завжди'),
(3, 2, '2024-01-20', 330.00, 3, 'Звичайний сервіс'),
(4, 4, '2024-02-01', 290.00, 4, 'Добре для джуніор-барбера'),
(5, 5, '2024-02-10', 250.00, 3, 'Нормальний сервіс');

-- =============================================
-- КОРИСТУВАЦЬКІ ФУНКЦІЇ (USER-DEFINED FUNCTIONS)
-- =============================================

-- Функція для створення персоналізованого привітання
-- Приймає ім'я як параметр і повертає рядок у форматі "Hello, ІМ'Я!"
CREATE FUNCTION dbo.GetGreeting(@name NVARCHAR(50))
RETURNS NVARCHAR(100)
AS
BEGIN
    RETURN 'Hello, ' + @name + '!'
END;
GO

-- Функція для отримання поточної кількості хвилин
-- Витягує хвилини з поточного часу системи
CREATE FUNCTION dbo.GetCurrentMinutes()
RETURNS INT
AS
BEGIN
    RETURN DATEPART(MINUTE, GETDATE())
END;
GO

-- Функція для отримання поточного року
-- Витягує рік з поточної дати системи
CREATE FUNCTION dbo.GetCurrentYear()
RETURNS INT
AS
BEGIN
    RETURN YEAR(GETDATE())
END;
GO

-- Функція для перевірки парності поточного року
-- Визначає чи є поточний рік парним або непарним
CREATE FUNCTION dbo.IsYearEvenOrOdd()
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @year INT = YEAR(GETDATE())
    IF @year % 2 = 0
        RETURN 'Even'      -- Парний рік
    ELSE
        RETURN 'Odd'       -- Непарний рік
END;
GO

-- Функція для перевірки чи є число простим
-- Простим вважається число, яке ділиться лише на 1 і на себе
CREATE FUNCTION dbo.IsPrime(@number INT)
RETURNS NVARCHAR(3)
AS
BEGIN
    -- Числа менше або рівні 1 не є простими
    IF @number <= 1
        RETURN 'no'
    
    -- 2 - єдине парне просте число
    IF @number = 2
        RETURN 'yes'
    
    -- Всі інші парні числа не є простими
    IF @number % 2 = 0
        RETURN 'no'
    
    -- Перевіряємо дільники до квадратного кореня числа
    DECLARE @i INT = 3
    WHILE @i * @i <= @number
    BEGIN
        IF @number % @i = 0
            RETURN 'no'
        SET @i = @i + 2  -- Перевіряємо лише непарні числа
    END
    
    RETURN 'yes'
END;
GO

-- Функція для знаходження суми мінімального та максимального значень з п'яти чисел
-- Приймає 5 параметрів, знаходить найменше та найбільше, повертає їх суму
CREATE FUNCTION dbo.SumMinMax(@num1 INT, @num2 INT, @num3 INT, @num4 INT, @num5 INT)
RETURNS INT
AS
BEGIN
    DECLARE @min INT, @max INT
    
    -- Ініціалізуємо мінімум і максимум першим числом
    SET @min = @num1
    SET @max = @num1
    
    -- Порівнюємо з кожним наступним числом
    IF @num2 < @min SET @min = @num2
    IF @num2 > @max SET @max = @num2
    
    IF @num3 < @min SET @min = @num3
    IF @num3 > @max SET @max = @num3
    
    IF @num4 < @min SET @min = @num4
    IF @num4 > @max SET @max = @num4
    
    IF @num5 < @min SET @min = @num5
    IF @num5 > @max SET @max = @num5
    
    RETURN @min + @max
END;
GO

-- Функція для відображення парних або непарних чисел у заданому діапазоні
-- Приймає початок, кінець діапазону та тип чисел для відображення
CREATE FUNCTION dbo.GetEvenOddInRange(@start INT, @end INT, @type NVARCHAR(10))
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @result NVARCHAR(MAX) = ''
    DECLARE @current INT = @start
    
    -- Перебираємо всі числа в діапазоні
    WHILE @current <= @end
    BEGIN
        -- Перевіряємо чи відповідає число заданому типу
        IF (@type = 'even' AND @current % 2 = 0) OR (@type = 'odd' AND @current % 2 = 1)
        BEGIN
            SET @result = @result + CAST(@current AS NVARCHAR(10)) + ' '
        END
        SET @current = @current + 1
    END
    
    -- Прибираємо зайвий пробіл в кінці
    RETURN RTRIM(@result)
END;
GO

-- =============================================
-- ЗБЕРЕЖЕНІ ПРОЦЕДУРИ (STORED PROCEDURES)
-- =============================================

-- Процедура для виведення привітання "Hello, world!"
CREATE PROCEDURE sp_HelloWorld
AS
BEGIN
    PRINT 'Hello, world!'
END;
GO

-- Процедура для отримання поточного часу у форматі ГГ:ХХ:СС
CREATE PROCEDURE sp_CurrentTime
AS
BEGIN
    SELECT CONVERT(NVARCHAR(20), GETDATE(), 108) AS CurrentTime
END;
GO

-- Процедура для отримання поточної дати у форматі РРРР-ММ-ДД
CREATE PROCEDURE sp_CurrentDate
AS
BEGIN
    SELECT CONVERT(NVARCHAR(20), GETDATE(), 23) AS CurrentDate
END;
GO

-- Процедура для обчислення суми трьох чисел
CREATE PROCEDURE sp_SumThreeNumbers
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    SELECT @num1 + @num2 + @num3 AS Sum
END;
GO

-- Процедура для обчислення середнього арифметичного трьох чисел
CREATE PROCEDURE sp_AverageThreeNumbers
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    SELECT (@num1 + @num2 + @num3) / 3.0 AS Average
END;
GO

-- Процедура для знаходження максимального значення з трьох чисел
CREATE PROCEDURE sp_MaxThreeNumbers
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    DECLARE @max INT
    SET @max = @num1
    IF @num2 > @max SET @max = @num2
    IF @num3 > @max SET @max = @num3
    SELECT @max AS Maximum
END;
GO

-- Процедура для знаходження мінімального значення з трьох чисел
CREATE PROCEDURE sp_MinThreeNumbers
    @num1 INT,
    @num2 INT,
    @num3 INT
AS
BEGIN
    DECLARE @min INT
    SET @min = @num1
    IF @num2 < @min SET @min = @num2
    IF @num3 < @min SET @min = @num3
    SELECT @min AS Minimum
END;
GO

-- Процедура для створення лінії з заданого символу
-- Приймає довжину лінії та символ для побудови
CREATE PROCEDURE sp_DrawLine
    @length INT,
    @symbol NCHAR(1)
AS
BEGIN
    DECLARE @line NVARCHAR(MAX) = ''
    DECLARE @i INT = 1
    
    -- Будуємо лінію символ за символом
    WHILE @i <= @length
    BEGIN
        SET @line = @line + @symbol
        SET @i = @i + 1
    END
    
    PRINT @line
END;
GO

-- Процедура для обчислення факторіалу числа
-- Факторіал n! = 1 * 2 * 3 * ... * n
CREATE PROCEDURE sp_Factorial
    @number INT
AS
BEGIN
    DECLARE @result BIGINT = 1
    DECLARE @i INT = 1
    
    -- Перемножуємо всі числа від 1 до заданого
    WHILE @i <= @number
    BEGIN
        SET @result = @result * @i
        SET @i = @i + 1
    END
    
    SELECT @result AS Factorial
END;
GO

-- Процедура для зведення числа у ступінь
-- Обчислює base^exponent
CREATE PROCEDURE sp_Power
    @base INT,
    @exponent INT
AS
BEGIN
    DECLARE @result BIGINT = 1
    DECLARE @i INT = 1
    
    -- Перемножуємо базу саму на себе exponent разів
    WHILE @i <= @exponent
    BEGIN
        SET @result = @result * @base
        SET @i = @i + 1
    END
    
    SELECT @result AS Power
END;
GO

-- =============================================
-- ПРОЦЕДУРИ ДЛЯ БІЗНЕС-ЛОГІКИ БАРБЕРШОПУ
-- =============================================

-- Процедура для отримання ПІБ всіх барберів салону
CREATE PROCEDURE sp_GetAllBarbersNames
AS
BEGIN
    SELECT full_name 
    FROM Barbers 
    ORDER BY full_name
END;
GO

-- Процедура для отримання інформації про всіх синьйор-барберів
CREATE PROCEDURE sp_GetSeniorBarbers
AS
BEGIN
    SELECT * 
    FROM Barbers 
    WHERE position = 'Senior Barber' 
    ORDER BY full_name
END;
GO

-- Процедура для отримання барберів, які можуть надати послугу традиційного гоління бороди
CREATE PROCEDURE sp_GetBarbersForTraditionalShave
AS
BEGIN
    SELECT DISTINCT b.* 
    FROM Barbers b
    INNER JOIN BarberServices bs ON b.barber_id = bs.barber_id
    INNER JOIN Services s ON bs.service_id = s.service_id
    WHERE s.service_name = 'Traditional Beard Shave'
    ORDER BY b.full_name
END;
GO

-- Процедура для отримання барберів, які можуть надати конкретну послугу
-- Назва послуги передається як параметр
CREATE PROCEDURE sp_GetBarbersForService
    @serviceName NVARCHAR(100)
AS
BEGIN
    SELECT DISTINCT b.* 
    FROM Barbers b
    INNER JOIN BarberServices bs ON b.barber_id = bs.barber_id
    INNER JOIN Services s ON bs.service_id = s.service_id
    WHERE s.service_name = @serviceName
    ORDER BY b.full_name
END;
GO

-- Процедура для отримання барберів, які працюють понад зазначену кількість років
CREATE PROCEDURE sp_GetBarbersByExperience
    @years INT
AS
BEGIN
    SELECT * 
    FROM Barbers 
    WHERE DATEDIFF(YEAR, hire_date, GETDATE()) > @years
    ORDER BY hire_date
END;
GO

-- Процедура для отримання кількості синьйор-барберів та джуніор-барберів
CREATE PROCEDURE sp_GetBarberCounts
AS
BEGIN
    SELECT 
        SUM(CASE WHEN position = 'Senior Barber' THEN 1 ELSE 0 END) AS SeniorBarbers,
        SUM(CASE WHEN position = 'Junior Barber' THEN 1 ELSE 0 END) AS JuniorBarbers
    FROM Barbers
END;
GO

-- Процедура для отримання постійних клієнтів
-- Постійний клієнт - той, хто відвідав салон задану кількість разів
CREATE PROCEDURE sp_GetRegularClients
    @minVisits INT
AS
BEGIN
    SELECT c.*, COUNT(vh.visit_id) AS VisitCount
    FROM Clients c
    INNER JOIN VisitHistory vh ON c.client_id = vh.client_id
    GROUP BY c.client_id, c.full_name, c.phone, c.email, c.created_at
    HAVING COUNT(vh.visit_id) >= @minVisits
    ORDER BY VisitCount DESC
END;
GO

-- =============================================
-- ТРИГЕРИ ДЛЯ ЗАБЕЗПЕЧЕННЯ БІЗНЕС-ПРАВИЛ
-- =============================================

-- Тригер для заборони видалення чиф-барбера, якщо не додано другий чиф-барбер
-- Спрацьовує при спробі видалення записів з таблиці барберів
CREATE TRIGGER trg_PreventChiefBarberDeletion
ON Barbers
FOR DELETE
AS
BEGIN
    -- Перевіряємо, чи намагаються видалити чиф-барбера
    IF EXISTS (SELECT 1 FROM deleted WHERE position = 'Chief Barber')
    BEGIN
        DECLARE @chiefCount INT
        -- Рахуємо кількість чиф-барберів, що залишилися
        SELECT @chiefCount = COUNT(*) FROM Barbers WHERE position = 'Chief Barber'
        
        -- Якщо залишається менше або рівно одного чиф-барбера, забороняємо видалення
        IF @chiefCount <= 1
        BEGIN
            RAISERROR('Не можна видалити єдиного чиф-барбера. Спочатку призначте іншого чиф-барбера.', 16, 1)
            ROLLBACK TRANSACTION
            RETURN
        END
    END
END;
GO

-- Тригер для заборони додавання барберів молодше 21 року
-- Спрацьовує при вставці нових записів або оновленні існуючих в таблиці барберів
CREATE TRIGGER trg_PreventYoungBarbers
ON Barbers
FOR INSERT, UPDATE
AS
BEGIN
    -- Перевіряємо, чи є серед нових/оновлених записів барбери молодше 21 року
    IF EXISTS (SELECT 1 FROM inserted WHERE DATEDIFF(YEAR, birth_date, GETDATE()) < 21)
    BEGIN
        RAISERROR('Не можна додавати барберів молодше 21 року.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END;
GO

-- =============================================
-- ТЕСТУВАННЯ ФУНКЦІОНАЛЬНОСТІ
-- =============================================

-- Тестування користувацьких функцій
PRINT '=== Тестування користувацьких функцій ==='
-- Перевірка функції привітання
SELECT dbo.GetGreeting('Nick') AS Greeting
-- Перевірка функції отримання поточних хвилин
SELECT dbo.GetCurrentMinutes() AS CurrentMinutes
-- Перевірка функції отримання поточного року
SELECT dbo.GetCurrentYear() AS CurrentYear
-- Перевірка функції визначення парності року
SELECT dbo.IsYearEvenOrOdd() AS YearType
-- Перевірка функції для визначення простого числа
SELECT dbo.IsPrime(17) AS IsPrime17
-- Перевірка функції суми мінімального та максимального значень
SELECT dbo.SumMinMax(1, 5, 3, 9, 2) AS SumMinMax
-- Перевірка функції отримання парних чисел в діапазоні
SELECT dbo.GetEvenOddInRange(1, 10, 'even') AS EvenNumbers
GO

-- Тестування збережених процедур
PRINT '=== Тестування збережених процедур ==='
EXEC sp_HelloWorld                      -- Виведення привітання
EXEC sp_CurrentTime                     -- Поточний час
EXEC sp_CurrentDate                     -- Поточна дата
EXEC sp_SumThreeNumbers 5, 10, 15       -- Сума трьох чисел
EXEC sp_AverageThreeNumbers 10, 20, 30  -- Середнє арифметичне
EXEC sp_MaxThreeNumbers 15, 8, 25       -- Максимальне значення
EXEC sp_MinThreeNumbers 15, 8, 25       -- Мінімальне значення
EXEC sp_DrawLine 5, '#'                 -- Малювання лінії
EXEC sp_Factorial 5                     -- Факторіал
EXEC sp_Power 2, 3                      -- Зведення в ступінь
GO

-- Тестування процедур бізнес-логіки
PRINT '=== Тестування процедур бізнес-логіки ==='
EXEC sp_GetAllBarbersNames              -- Всі імена барберів
EXEC sp_GetSeniorBarbers                -- Синьйор-барбери
EXEC sp_GetBarbersForTraditionalShave   -- Барбери для традиційного гоління
EXEC sp_GetBarbersForService 'Haircut'  -- Барбери для конкретної послуги
EXEC sp_GetBarbersByExperience 2		-- Барбери, які працюють понад зазначену кількість років
EXEC sp_GetBarberCounts					-- Синьйор-барбери та джуніор-барбери
EXEC sp_GetRegularClients 2				-- Постійні клієнти
GO

PRINT '=== База даних успішно створена з усіма необхідними функціями ==='