namespace ToDoList.Api.Contracts
{
    public record UpdateRequest(Guid id, string name, string desc);
}
