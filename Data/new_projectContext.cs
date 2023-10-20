using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using new_project.Models;

namespace new_project.Data;

public partial class new_projectContext : DbContext
{
    public new_projectContext(DbContextOptions<new_projectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("userData");

            entity.HasIndex(e => e.UserId, "IX_userData_userID").IsUnique();

            entity.HasIndex(e => e.UserName, "IX_userData_UserName").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
