using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BusinessLogic.Interfaces
{
    public interface INoteService
    {
        Task CreateAsync(string name, string description, CancellationToken cancellationToken = default);
        Task GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, string newName, string newDescription, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
