using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccessLayer.Entities;
namespace ToDoApp.DataAccessLayer;

public partial class TodoappContext : DbContext
{
    public TodoappContext()
    {
    }

    public TodoappContext(DbContextOptions<TodoappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Programma> Programma { get; set; }

    public virtual DbSet<Azienda> Aziendas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__todoItem__3213E83F8102F018");

            entity.ToTable("todoItems");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsComplete).HasColumnName("is_complete");
            entity.Property(e => e.LastModified)
                .HasColumnType("date")
                .HasColumnName("last_modified");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id).HasName("PK__User");

            entity.ToTable("users");
            entity.Property(u => u.Id)
                .HasColumnName("id");
            entity.Property(u => u.Name).IsRequired().HasColumnName("name");
            entity.Property(u => u.Email).IsRequired().HasColumnName("email");
            entity.Property(u => u.DataNascita).HasColumnName("dataNascita");
            entity.Property(u => u.Indirizzo).HasColumnName("indirizzo");
            entity.Property(u => u.Ruolo).IsRequired().HasColumnName("Ruolo");
        });

        modelBuilder.Entity<Azienda>(entity =>
        {
            entity.HasKey(a => a.Id).HasName("PK__Azienda");
            entity.ToTable("azienda");

            entity.Property(a => a.Id).HasColumnName("id");
            entity.Property(a => a.Name).HasColumnName("name");

            modelBuilder.Entity<Programma>()
                .HasOne(u => u.Azienda)
                .WithMany(u => u.Programmi); 

        });

        modelBuilder.Entity<Programma>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Programma");

            entity.Property(e => e.Nome).HasColumnName("Nome");
            entity.Property(e => e.Orario).HasColumnName("Orario");


        }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
