using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Api.Contracts;
using ToDoList.BusinessLogic.Interfaces;
using ToDoList.Contracts;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Models;
using ToDoList.Requests;

namespace ToDoList.Endpoints
{
    public static class NoteEndpoints
    {
        public static void NotesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("notes");

            group.MapPost("/create", async ([FromServices] INoteService noteService, CreateNoteRequest request, CancellationToken cancellationToken = default) =>
            {
                await noteService.CreateAsync(request.Name, request.Description, cancellationToken);
                return Results.Ok();
            });

            group.MapGet("/get", async (AppDbContext db, [AsParameters] GetNotesRequest request, CancellationToken cancellationToken = default) =>
            {
                var notes = db.Notes
                    .Where(n => !string.IsNullOrEmpty(request.Search) && 
                                n.Name.ToLower().Contains(request.Search.ToLower()));
                Expression<Func<Note, object>> selectorKey = request.SortItem?.ToLower().ToLower() switch
                {
                    "date" => note => note.Name,
                    "name" => note => note.Name,
                    "description" => note => note.Description,
                    _ => note => note.Id
                };

                notes = request.SortOrder == "desc"
                ? notes.OrderByDescending(selectorKey)
                : notes.OrderBy(selectorKey);


                var noteDtos = await notes
                    .Select(n => new NoteDto (n.Id, n.Name, n.Description, n.Created))
                    .ToListAsync(cancellationToken);

                return Results.Ok(noteDtos);
            });

            group.MapPut("/update", async ([FromServices] INoteService noteService, AppDbContext db, UpdateRequest request, CancellationToken cancellation = default) =>
            {
                await noteService.UpdateAsync(request.id, request.name, request.desc);

                return Results.Ok(noteService.GetByIdAsync(request.id, cancellation));
            });

            group.MapDelete("/delete", async (INoteService noteService, AppDbContext db, Guid id, CancellationToken cancellation = default) =>
            {
                await noteService.DeleteAsync(id, cancellation);

                return Results.Ok();
            });

        }
    }
}
