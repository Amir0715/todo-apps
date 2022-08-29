using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;
using TodoApp.Domain;
using TodoApp.Persistence.EntityTypeConfigurations;

namespace TodoApp.Persistence;

public class TodosDbContext: DbContext, ITodosDbContext
{
    public DbSet<Todo> Todos { get; set; }

    public TodosDbContext(DbContextOptions<TodosDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TodoConfiguration());
        base.OnModelCreating(builder);
    }
}