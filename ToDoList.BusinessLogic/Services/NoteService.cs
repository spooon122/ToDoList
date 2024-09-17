using ToDoList.BusinessLogic.Interfaces;
using ToDoList.DataAccess.Interfaces;
using ToDoList.DataAccess.Models;

namespace ToDoList.BusinessLogic.Services
{
    internal class NoteService(INoteRepository noteRepository) : INoteService
    {
        public async Task CreateAsync(string name, string description, CancellationToken cancellationToken = default)
        {
            var note = new Note
            {
                Name = name,
                Description = description,
            };
            await noteRepository.CreateAsync(note, cancellationToken);
        }

        public async Task GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await noteRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(Guid id, string newName, string newDescription, CancellationToken cancellationToken = default)
        {
            var result = await noteRepository.GetByIdAsync(id, cancellationToken);

            await noteRepository.UpdateAsync(result!);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await noteRepository.GetByIdAsync(id, cancellationToken);

            await noteRepository.DeleteAsync(result!);
        }
    }
}