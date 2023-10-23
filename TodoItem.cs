namespace DotNetTodo;

public record struct TodoItem(string Description, bool IsComplete = false);