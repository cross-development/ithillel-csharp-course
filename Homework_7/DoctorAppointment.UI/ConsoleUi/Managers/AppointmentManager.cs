using ConsoleTables;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Application.Interfaces;
using DoctorAppointment.UI.ConsoleUi.Helpers;
using DoctorAppointment.UI.ConsoleUi.Interfaces;

namespace DoctorAppointment.UI.ConsoleUi.Managers;

/// <summary>
/// Manages console UI operations related to appointments,
/// providing CRUD functionality via the <see cref="IAppointmentService"/>,
/// <see cref="IAppointmentService"/>, and <see cref="IPatientService"/>.
/// Implements <see cref="IAppointmentManager"/>.
/// </summary>
public sealed class AppointmentManager(IAppointmentService appointmentService,
    IDoctorService doctorService, IPatientService patientService) : IAppointmentManager
{
    /// <summary>
    /// Runs the console menu for appointment operations.
    /// </summary>
    public void Run()
    {
        var back = false;

        while (!back)
        {
            Console.WriteLine("--- Appointments ---");
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
    /// Displays a list of all appointments.
    /// </summary>
    private void ListAll()
    {
        var appointments = appointmentService.GetAll().ToList();

        if (appointments.Count == 0)
        {
            Console.WriteLine("No appointments yet.\n");
            return;
        }

        ShowAppointmentInfo(appointments);
    }

    /// <summary>
    /// Prompts for an appointment ID and displays appointment details.
    /// </summary>
    private void GetById()
    {
        var id = ConsoleHelper.ReadInt("Enter Appointment ID: ");

        var appointment = appointmentService.GetById(id);

        if (appointment is null)
        {
            Console.WriteLine("Appointment not found.\n");
            return;
        }

        ShowAppointmentInfo([appointment]);
    }

    /// <summary>
    /// Creates a new appointment by collecting data from the console.
    /// </summary>
    private void Create()
    {
        var pid = ConsoleHelper.ReadInt("Enter Patient ID: ");

        var existingPatient = patientService.GetById(pid);

        if (existingPatient is null)
        {
            Console.WriteLine("Patient not found.\n");
            return;
        }

        var did = ConsoleHelper.ReadInt("Enter Doctor ID: ");

        var existingDoctor = doctorService.GetById(did);

        if (existingDoctor is null)
        {
            Console.WriteLine("Doctor not found.\n");
            return;
        }

        var appointment = PopulateAppointment();

        appointment.Patient = existingPatient;
        appointment.Doctor = existingDoctor;

        appointmentService.Create(appointment);

        Console.WriteLine("Appointment created successfully!\n");
    }

    /// <summary>
    /// Updates an existing appointment's data.
    /// </summary>
    private void Update()
    {
        var id = ConsoleHelper.ReadInt("Enter Appointment ID: ");

        var existingAppointment = appointmentService.GetById(id);

        if (existingAppointment is null)
        {
            Console.WriteLine("Appointment not found.\n");
            return;
        }

        var pid = ConsoleHelper.ReadInt("Enter Patient ID: ", existingAppointment.Patient?.Id);

        var existingPatient = patientService.GetById(pid);

        if (existingPatient is null)
        {
            Console.WriteLine("Patient not found.\n");
            return;
        }

        var did = ConsoleHelper.ReadInt("Enter Doctor ID: ", existingAppointment.Doctor?.Id);

        var existingDoctor = doctorService.GetById(did);

        if (existingDoctor is null)
        {
            Console.WriteLine("Doctor not found.\n");
            return;
        }

        var updatedAppointment = PopulateAppointment(existingAppointment);

        updatedAppointment.Patient = existingPatient;
        updatedAppointment.Doctor = existingDoctor;

        appointmentService.Update(id, updatedAppointment);

        Console.WriteLine("Appointment updated successfully!\n");
    }

    /// <summary>
    /// Deletes an appointment by the specified ID.
    /// </summary>
    private void Delete()
    {
        var id = ConsoleHelper.ReadInt("Enter Appointment ID: ");

        var isDeleted = appointmentService.Delete(id);

        if (!isDeleted)
        {
            Console.WriteLine("Not found.\n");
            return;
        }

        Console.WriteLine("Appointment deleted successfully!\n");
    }

    /// <summary>
    /// Collects appointment data from the console or updates an existing appointment.
    /// Ensures the end time is after the start time.
    /// </summary>
    /// <param name="existing">An existing appointment to update or null to create a new one.</param>
    /// <returns>A <see cref="Appointment"/> object with populated fields.</returns>
    private static Appointment PopulateAppointment(Appointment? existing = null)
    {
        var appointment = existing ?? new Appointment();

        Console.WriteLine("Enter appointment details:");

        DateTime fromDate, toDate;

        do
        {
            fromDate = ConsoleHelper.ReadDateTime("Start (yyyy-MM-dd HH:mm): ", existing?.DateTimeFrom);
            toDate = ConsoleHelper.ReadDateTime("End (yyyy-MM-dd HH:mm): ", existing?.DateTimeTo);

            if (toDate <= fromDate)
            {
                Console.WriteLine("Error: End time must be after Start time. Please re-enter.");
            }
        }
        while (toDate <= fromDate);

        appointment.DateTimeFrom = fromDate;
        appointment.DateTimeTo = toDate;
        appointment.Description = ConsoleHelper.ReadString("Description (opt)", existing?.Description, true);

        return appointment;
    }

    /// <summary>
    /// Displays appointment information in a console table.
    /// </summary>
    /// <param name="appointments">The list of appointments to display.</param>
    private static void ShowAppointmentInfo(List<Appointment> appointments)
    {
        var table = new ConsoleTable("ID", "Patient", "Doctor", "Start time", "End time",
            "Description", "Created at", "Updated at");

        appointments.ForEach(appointment =>
        {
            var patientName = appointment.Patient is null
                ? "N/A"
                : $"{appointment.Patient.Name} {appointment.Patient.Surname}";

            var doctorName = appointment.Doctor is null
                ? "N/A"
                : $"{appointment.Doctor.Name} {appointment.Doctor.Surname}";

            table.AddRow(
                appointment.Id,
                patientName,
                doctorName,
                appointment.DateTimeFrom,
                appointment.DateTimeTo,
                string.IsNullOrWhiteSpace(appointment.Description) ? "N/A" : appointment.Description,
                appointment.CreatedAt,
                appointment.UpdatedAt <= appointment.CreatedAt ? "N/A" : appointment.UpdatedAt
            );
        });

        table.Write();
    }
}