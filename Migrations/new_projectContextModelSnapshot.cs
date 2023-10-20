﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using new_project.Data;

#nullable disable

namespace new_projectAPI.Migrations
{
    [DbContext(typeof(new_projectContext))]
    partial class new_projectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("new_project.Models.UserDatum", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("userID");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "UserName" }, "IX_userData_UserName")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "IX_userData_userID")
                        .IsUnique();

                    b.ToTable("userData", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}