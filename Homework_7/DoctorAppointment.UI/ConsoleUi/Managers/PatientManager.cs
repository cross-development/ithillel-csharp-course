using ConsoleTables;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.UI.ConsoleUi.Helpers;
using DoctorAppointment.UI.ConsoleUi.Interfaces;

namespace DoctorAppointment.UI.ConsoleUi.Managers;

/// <summary>
/// Manages console UI operations related to patient,
/// providing CRUD functionality via the <see cref="IPatientService"/>.
/// Implements <see cref="IPatientManager"/>.
/// </summary>
public sealed class PatientManager(IPatientService patientService) : IPatientManager
{
    /// <summary>
    /// Runs the console menu for patient operations.
    /// </summary>
    public void Run()
    {
        var back = false;

        while (!back)
        {
            Console.WriteLine("--- Patients ---");
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
    /// Displays a list of all patients.
    /// </summary>
    private void ListAll()
    {
        var patients = patientService.GetAll().ToList();

        if (patients.Count == 0)
        {
            Console.WriteLine("No patients yet.\n");
            return;
        }

        ShowPatientInfo(patients);
    }

    /// <summary>
    /// Prompts for a patient ID and displays patient details.
    /// </summary>
    private void GetById()
    {
        var id = ConsoleHelper.ReadInt("Enter Patient ID: ");

        var patient = patientService.GetById(id);

        if (patient is null)
        {
            Console.WriteLine("Patient not found.\n");
            return;
        }

        ShowPatientInfo([patient]);
    }

    /// <summary>
    /// Creates a new patient by collecting data from the console.
    /// </summary>
    private void Create()
    {
        var patient = PopulatePatient();

        patientService.Create(patient);

        Console.WriteLine("Patient created successfully.\n");
    }

    /// <summary>
    /// Updates an existing patient's data.
    /// </summary>
    private void Update()
    {
        var id = ConsoleHelper.ReadInt("Enter Patient ID: ");

        var existingPatient = patientService.GetById(id);

        if (existingPatient is null)
        {
            Console.WriteLine("Patient not found.\n");
            return;
        }

        var updatedPatient = PopulatePatient(existingPatient);

        patientService.Update(id, updatedPatient);

        Console.WriteLine("Patient updated successfully!\n");
    }

    /// <summary>
    /// Deletes a patient by the specified ID.
    /// </summary>
    private void Delete()
    {
        var id = ConsoleHelper.ReadInt("Enter Patient ID: ");

        var isDeleted = patientService.Delete(id);

        if (!isDeleted)
        {
            Console.WriteLine("Not found.\n");
            return;
        }

        Console.WriteLine("Patient deleted successfully!\n");
    }

    /// <summary>
    /// Collects patient data from the console or updates an existing patient.
    /// </summary>
    /// <param name="existing">An existing patient to update or null to create a new one.</param>
    /// <returns>A <see cref="Patient"/> object with populated fields.</returns>
    private static Patient PopulatePatient(Patient? existing = null)
    {
        var patient = existing ?? new Patient();

        Console.WriteLine("Enter patient details:");

        patient.Name = ConsoleHelper.ReadString("Name", existing?.Name);
        patient.Surname = ConsoleHelper.ReadString("Surname", existing?.Surname);
        patient.Phone = ConsoleHelper.ReadString("Phone (opt)", existing?.Phone, true);
        patient.Email = ConsoleHelper.ReadString("Email (opt)", existing?.Email, true);
        patient.IllnessType = ConsoleHelper.ReadEnum("Illness Type", existing?.IllnessType);
        patient.AdditionalInfo = ConsoleHelper.ReadString("Additional Info (opt)", existing?.AdditionalInfo, true);
        patient.Address = ConsoleHelper.ReadString("Address (opt)", existing?.Address, true);

        return patient;
    }

    /// <summary>
    /// Displays patient information in a console table.
    /// </summary>
    /// <param name="patients">The list of patients to display.</param>
    private static void ShowPatientInfo(List<Patient> patients)
    {
        var table = new ConsoleTable("ID", "Name", "Surname", "Illness type", "Additional info",
            "Address", "Email", "Phone", "Created at", "Updated at");

        patients.ForEach(patient =>
        {
            table.AddRow(
                patient.Id,
                patient.Name,
                patient.Surname,
                patient.IllnessType,
                string.IsNullOrWhiteSpace(patient.AdditionalInfo) ? "N/A" : patient.AdditionalInfo,
                string.IsNullOrWhiteSpace(patient.Address) ? "N/A" : patient.Address,
                string.IsNullOrWhiteSpace(patient.Email) ? "N/A" : patient.Email,
                string.IsNullOrWhiteSpace(patient.Phone) ? "N/A" : patient.Phone,
                patient.CreatedAt,
                patient.UpdatedAt <= patient.CreatedAt ? "N/A" : patient.UpdatedAt
            );
        });

        table.Write();
    }
}