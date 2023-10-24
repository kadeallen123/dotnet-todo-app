using System;

namespace DotNetTodo;

/// <summary>
/// Manages a collection of todo items and provides functionality to create, read, update, and delete them.
/// </summary>
public class TodoManager
{
	private Dictionary<int, TodoItem> _data;
	
	/// <summary>
	/// Gets or sets the dictionary of todo items.
	/// </summary>
	public Dictionary<int, TodoItem> Todos
	{
		get { return _data; }
		set { _data = value; }
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="TodoManager"/> class.
	/// </summary>
	public TodoManager()
	{
		_data = new();
	}

	/// <summary>
	/// Prints all the todo items.
	/// </summary>
	public void PrintTodos()
	{
		if (Todos.Count == 0)
		{
			Console.WriteLine("No todos...");
		}
		else
		{
			foreach (int i in Enumerable.Range(0, Todos.Count))
			{
				var todo = Todos[i];
				Console.WriteLine($"  {i}. {todo.Description} [{(todo.IsComplete ? 'x' : ' ')}]");
			}
		}
	}

	/// <summary>
	/// Adds a new todo
	/// </summary>
	/// <param name="description">The description of the todo.</param>
	/// <param name="isComplete">A flag indicating whether the todo is complete (optional, default is false)</param>
	public void AddTodo(string description, bool isComplete = false)
	{
		var newTodo = new TodoItem(description, isComplete);
		if (_data.ContainsValue(newTodo))
		{
			// Todo already exists
			return;
		}
		Todos.Add(newTodo.Id, newTodo);
	}

	/// <summary>
	/// Gets a todo item by its ID.
	/// </summary>
	/// <param name="id">The ID of the todo item to retrieve.</param>
	/// <returns>A <see cref="TodoItem"/> wrapped in an <see cref="Optional"/> type.</returns>
	public Optional<TodoItem> GetTodo(int id)
	{
		if (!_data.ContainsKey(id))
		{
			return Optional<TodoItem>.None;
		}

		var todo = _data[id];
		return Optional<TodoItem>.Some(todo);
	}

	/// <summary>
	/// Toggles the completion state of a todo item identified by its ID.
	/// </summary>
	/// <param name="id">The Id of the todo item to update.</param>
	public void UpdateTodoState(int id)
	{
		if (!_data.ContainsKey(id))
		{
			// Todo id doesn't exist
			return;
		}

		var todo = _data[id];
		todo.IsComplete = !todo.IsComplete;
	}

	/// <summary>
	/// Edits the description of a todo item identified by its ID.
	/// </summary>
	/// <param name="id">The ID of the todo item to edit.</param>
	/// <param name="description">The new description for the todo item.</param>
	public void EditTodo(int id, string description)
	{
		if (!_data.ContainsKey(id))
		{
			// Todo doesn't exist
			return;
		}

		var todo = _data[id];
		todo.Description = description;
	}

	/// <summary>
	/// Deletes a todo item identified by its ID.
	/// </summary>
	/// <param name="id">The ID of the todo item to delete.</param>
	public void DeleteTodo(int id)
	{
		if (!_data.ContainsKey(id))
		{
			// Todo doesn't exist
		}

		_data.Remove(id);
	}

}