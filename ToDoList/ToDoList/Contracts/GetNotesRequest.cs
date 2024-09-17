namespace ToDoList.Requests
{
    public record GetNotesRequest(string? Search, string? SortItem, string? SortOrder);
}
