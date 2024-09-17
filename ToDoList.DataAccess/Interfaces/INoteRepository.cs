using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Interfaces
{
    public interface INoteRepository
    {
        public Task CreateAsync(Note note, CancellationToken cancellationToken = default);
        public Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
        public Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
    }
}
