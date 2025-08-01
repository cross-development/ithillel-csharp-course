using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Homework_13.Models;

namespace Homework_13.Data.Configurations;

public class NoteConfigurations : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {

        builder.HasKey(note => note.Id);
        builder.Property(note => note.Title).IsRequired().HasMaxLength(200);
        builder.Property(note => note.Text).IsRequired();
        builder.Property(note => note.Tags).HasMaxLength(500);
    }
}