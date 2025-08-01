using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Homework_13.Models;

namespace Homework_13.Data.Configurations;

public class ContactConfigurations : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(contact => contact.Id);
        builder.Property(contact => contact.Name).IsRequired().HasMaxLength(100);
        builder.Property(contact => contact.Phone).IsRequired();
        builder.Property(contact => contact.AlternatePhone).HasMaxLength(20);
        builder.Property(contact => contact.Email).IsRequired();
        builder.Property(contact => contact.Description).HasMaxLength(500);
    }
}