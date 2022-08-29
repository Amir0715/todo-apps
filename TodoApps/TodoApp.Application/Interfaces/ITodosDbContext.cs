using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace TodoApp.Application.Interfaces;

public interface ITodosDbContext
{
    DbSet<Todo> Todos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}