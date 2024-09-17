namespace ToDoList.Contracts
{
    public record NoteDto(Guid Id, string? Name, string? Description, DateTime Created);
}