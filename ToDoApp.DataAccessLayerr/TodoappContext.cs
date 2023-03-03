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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
