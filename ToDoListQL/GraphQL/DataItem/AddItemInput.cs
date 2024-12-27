namespace ToDoListQL.GraphQL.DataItem
{
    public record AddItemInput(string title, string description, bool isDone, int listId);

}
