﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.DataAccessLayer;

#nullable disable

namespace ToDoApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(TodoappContext))]
    [Migration("20230307141058_secondMigration")]
    partial class secondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoApp.DataAccessLayer.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit")
                        .HasColumnName("is_complete");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("date")
                        .HasColumnName("last_modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__todoItem__3213E83F8102F018");

                    b.ToTable("todoItems", (string)null);
                });

            modelBuilder.Entity("ToDoApp.DataAccessLayer.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataNascita");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Indirizzo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("indirizzo");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__User");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
