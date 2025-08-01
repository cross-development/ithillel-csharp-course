using Microsoft.EntityFrameworkCore;
using Homework_13.Data.Configurations;
using Homework_13.Models;

namespace Homework_13.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new NoteConfigurations());
        modelBuilder.ApplyConfiguration(new ContactConfigurations());
    }
}