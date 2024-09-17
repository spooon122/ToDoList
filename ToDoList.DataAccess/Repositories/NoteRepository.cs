using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Interfaces;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataAccess.Repositories
{
    internal class NoteRepository(AppDbContext db) : INoteRepository
    {
        public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
        {
            note.Created = DateTime.UtcNow;
            await db.Notes.AddAsync(note, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<Note?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await db.Notes.FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
        {
            note.Updated = DateTime.UtcNow;
            db.Notes.Update(note);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
        {
            await db.Notes.Where(n => n.Id == note.Id).ExecuteDeleteAsync(cancellationToken);
            await db.SaveChangesAsync();
        }
    }
}
