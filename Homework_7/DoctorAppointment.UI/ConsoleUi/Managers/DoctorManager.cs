using ConsoleTables;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.UI.ConsoleUi.Helpers;
using DoctorAppointment.UI.ConsoleUi.Interfaces;

namespace DoctorAppointment.UI.ConsoleUi.Managers;

/// <summary>
/// Manages console UI operations related to doctors,
/// providing CRUD functionality via the <see cref="IDoctorService"/>.
/// Implements <see cref="IDoctorManager"/>.
/// </summary>
public sealed class DoctorManager(IDoctorService doctorService) : IDoctorManager
{
    /// <summary>
    /// Starts the interactive console menu loop for doctor operations.
    /// </summary>
    public void Run()
    {
        var back = false;

        while (!back)
        {
            Console.WriteLine("--- Doctors ---");
            Console.WriteLine("1. List All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Create");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back");

            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": ListAll(); break;
                case "2": GetById(); break;
                case "3": Create(); break;
                case "4": Update(); break;
                case "5": Delete(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Invalid option.\n"); break;
            }
        }
    }

    /// <summary>
    /// Lists all doctors and displays them in a table format.
    /// </summary>
    private void ListAll()
    {
        var doctors = doctorService.GetAll().ToList();

        if (doctors.Count == 0)
        {
            Console.WriteLine("No doctors yet.\n");
            return;
        }

        ShowDoctorInfo(doctors);
    }

    /// <summary>
    /// Retrieves and displays a doctor by their ID.
    /// </summary>
    private void GetById()
    {
        var id = ConsoleHelper.ReadInt("Enter Doctor ID: ");

        var doctor = doctorService.GetById(id);

        if (doctor is null)
        {
            Console.WriteLine("Doctor not found.\n");
            return;
        }

        ShowDoctorInfo([doctor]);
    }

    /// <summary>
    /// Collects input and creates a new doctor.
    /// </summary>
    private void Create()
    {
        var doctor = PopulateDoctor();

        doctorService.Create(doctor);

        Console.WriteLine("Doctor created successfully!\n");
    }

    /// <summary>
    /// Updates an existing doctor by ID after collecting new input.
    /// </summary>
    private void Update()
    {
        var id = ConsoleHelper.ReadInt("Enter Doctor ID: ");

        var existingDoctor = doctorService.GetById(id);

        if (existingDoctor is null)
        {
            Console.WriteLine("Not found.\n");
            return;
        }

        var updatedDoctor = PopulateDoctor(existingDoctor);

        doctorService.Update(id, updatedDoctor);

        Console.WriteLine("Doctor updated successfully!\n");
    }

    /// <summary>
    /// Deletes a doctor by ID.
    /// </summary>
    private void Delete()
    {
        var id = ConsoleHelper.ReadInt("Enter Doctor ID: ");

        var isDeleted = doctorService.Delete(id);

        if (!isDeleted)
        {
            Console.WriteLine("Not found.\n");
            return;
        }

        Console.WriteLine("Doctor deleted successfully!\n");
    }

    /// <summary>
    /// Prompts the user to enter doctor details.
    /// If an existing doctor is passed, uses its current values as defaults.
    /// </summary>
    /// <param name="existing">Existing doctor to update, or null to create a new one.</param>
    /// <returns>A populated <see cref="Doctor"/> instance.</returns>
    private static Doctor PopulateDoctor(Doctor? existing = null)
    {
        var doctor = existing ?? new Doctor();

        Console.WriteLine("Enter doctor details:");

        doctor.Name = ConsoleHelper.ReadString("Name", existing?.Name);
        doctor.Surname = ConsoleHelper.ReadString("Surname", existing?.Surname);
        doctor.Phone = ConsoleHelper.ReadString("Phone (opt)", existing?.Phone, true);
        doctor.Email = ConsoleHelper.ReadString("Email (opt)", existing?.Email, true);
        doctor.DoctorType = ConsoleHelper.ReadEnum("Doctor Type", existing?.DoctorType);
        doctor.Experience = (byte)ConsoleHelper.ReadInt("Experience (years): ", existing?.Experience);
        doctor.Salary = ConsoleHelper.ReadDecimal("Salary: ", existing?.Salary);

        return doctor;
    }

    /// <summary>
    /// Displays a list of doctors in a formatted console table.
    /// </summary>
    /// <param name="doctors">The list of doctors to display.</param>
    private static void ShowDoctorInfo(List<Doctor> doctors)
    {
        var table = new ConsoleTable("ID", "Name", "Surname", "Doctor type", "Exp (yrs)",
            "Salary", "Email", "Phone", "Created at", "Updated at");

        doctors.ForEach(doctor =>
        {
            table.AddRow(
                doctor.Id,
                doctor.Name,
                doctor.Surname,
                doctor.DoctorType,
                doctor.Experience,
                doctor.Salary.ToString("N2"),
                string.IsNullOrWhiteSpace(doctor.Email) ? "N/A" : doctor.Email,
                string.IsNullOrWhiteSpace(doctor.Phone) ? "N/A" : doctor.Phone,
                doctor.CreatedAt,
                doctor.UpdatedAt <= doctor.CreatedAt ? "N/A" : doctor.UpdatedAt
            );
        });

        table.Write();
    }
}