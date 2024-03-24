using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kainatkhaliq.Models;

public partial class KainatkhaliqContext: DbContext
{
    public KainatkhaliqContext()
    {
    }

    public KainatkhaliqContext(DbContextOptions<KainatkhaliqContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SH7T7AL;Initial Catalog=KAINATKHALIQ;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07451F5D9E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Contact)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CONTACT");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Semester)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SEMESTER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
