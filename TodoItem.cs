namespace DotNetTodo;

public record struct TodoItem(string Description, bool IsComplete = false)
{
	private static int _todoCount = 0;
	public readonly int Id => _todoCount++;
}