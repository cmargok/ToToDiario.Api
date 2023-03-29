using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToToDiario.API.Domain.Entities;

namespace ToToDiario.API.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Nota> Nota { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasOne(d => d.Estado).WithMany(p => p.Notas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nota_Estado");

            entity.HasOne(d => d.User).WithMany(p => p.Notas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nota_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
