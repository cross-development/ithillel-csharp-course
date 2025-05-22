namespace Task_1;

/// <summary>
/// Represents an employee with a name and salary, including overloaded operators for comparison and salary manipulation.
/// </summary>
public class Employee
{
    private decimal _salary;

    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the salary of the employee. Throws an exception if the value is negative.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when a negative salary is assigned.</exception>
    public decimal Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative.");
            }

            _salary = value;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> class with the specified name and salary.
    /// </summary>
    /// <param name="name">The employee's name.</param>
    /// <param name="salary">The employee's salary.</param>
    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }

    /// <summary>
    /// Adds a specified amount to an employee's salary.
    /// </summary>
    /// <param name="employee">The employee whose salary to increase.</param>
    /// <param name="amount">The amount to add.</param>
    /// <returns>A new <see cref="Employee"/> instance with the updated salary.</returns>
    public static Employee operator +(Employee employee, decimal amount)
    {
        return new Employee(employee.Name, employee.Salary + amount);
    }

    /// <summary>
    /// Subtracts a specified amount from an employee's salary.
    /// </summary>
    /// <param name="employee">The employee whose salary to decrease.</param>
    /// <param name="amount">The amount to subtract.</param>
    /// <returns>A new <see cref="Employee"/> instance with the updated salary.</returns>
    public static Employee operator -(Employee employee, decimal amount)
    {
        return new Employee(employee.Name, employee.Salary - amount);
    }

    /// <summary>
    /// Compares two employees for salary equality.
    /// </summary>
    /// <param name="employee1">The first employee.</param>
    /// <param name="employee2">The second employee.</param>
    /// <returns><c>true</c> if salaries are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Employee employee1, Employee employee2)
    {
        if (ReferenceEquals(employee1, employee2))
        {
            return true;
        }

        if (ReferenceEquals(employee1, null) || ReferenceEquals(employee2, null))
        {
            return false;
        }

        return employee1.Salary == employee2.Salary;
    }

    /// <summary>
    /// Compares two employees for salary inequality.
    /// </summary>
    /// <param name="employee1">The first employee.</param>
    /// <param name="employee2">The second employee.</param>
    /// <returns><c>true</c> if salaries are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Employee employee1, Employee employee2)
    {
        return !(employee1 == employee2);
    }

    /// <summary>
    /// Determines whether the salary of the first employee is greater than that of the second.
    /// </summary>
    /// <param name="employee1">The first employee.</param>
    /// <param name="employee2">The second employee.</param>
    /// <returns><c>true</c> if employee1's salary is greater; otherwise, <c>false</c>.</returns>
    public static bool operator >(Employee employee1, Employee employee2)
    {
        return employee1.Salary > employee2.Salary;
    }

    /// <summary>
    /// Determines whether the salary of the first employee is less than that of the second.
    /// </summary>
    /// <param name="employee1">The first employee.</param>
    /// <param name="employee2">The second employee.</param>
    /// <returns><c>true</c> if employee1's salary is less; otherwise, <c>false</c>.</returns>
    public static bool operator <(Employee employee1, Employee employee2)
    {
        return employee1.Salary < employee2.Salary;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current employee based on salary.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns><c>true</c> if the object is an employee with the same salary; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is Employee employee)
        {
            return this == employee;
        }

        return false;
    }

    /// <summary>
    /// Returns the hash code for the employee, based on the salary.
    /// </summary>
    /// <returns>The hash code of the salary.</returns>
    public override int GetHashCode()
    {
        return Salary.GetHashCode();
    }

    /// <summary>
    /// Returns a string representation of the employee.
    /// </summary>
    /// <returns>A string containing the name and formatted salary.</returns>
    public override string ToString()
    {
        return $"Employee: {Name}, Salary: {Salary:C}";
    }
}