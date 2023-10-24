using System;

namespace DotNetTodo;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome to .NET Todo App!");
		List<TodoItem> todos = new();
		// REPL
		while (true)
		{
			//TODO Clear Screen
			Console.WriteLine("Todos:");
			if (todos.Count == 0)
			{
				Console.WriteLine("No todos...");
			}
			else
			{
				foreach (var t in todos)
				{
					Console.WriteLine($" - {t.Description} - [{(t.IsComplete ? 'x' : ' ')}]");
				}
			}

			Console.WriteLine("");
			Console.Write("|> ");
			var input = Console.ReadLine();
		}
	}
}