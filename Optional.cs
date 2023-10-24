namespace DotNetTodo;

/// <summary>
/// Represents an optional type of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the optional value.</typeparam>
public struct Optional<T>
{
	private readonly T? _value;
	private readonly bool _hasValue;

	/// <summary>
	/// Initializes a new instance of the <see cref="Optional{T}"/> class with no value.
	/// </summary>
	public Optional()
	{
		_hasValue = false;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Optional{T}"/> class with the given value.
	/// </summary>
	/// <param name="value">The value to wrap.</param>
	private Optional(T value)
	{
		_value = value;
		_hasValue = true;
	}

	/// <summary>
	/// Represents an empty optional value.
	/// </summary>
	public static Optional<T> None => new Optional<T>();

	/// <summary>
	/// Creates an optional type wrapping a given value.
	/// </summary>
	/// <param name="value">The value to wrap as optional.</param>
	/// <returns>An optional value containing the specified value.</returns>
	public static Optional<T> Some(T value) => new Optional<T>(value);

	/// <summary>
	/// A boolean value indicating whether this optional value has a value.
	/// </summary>
	public bool HashValue => _hasValue;

	/// <summary>
	/// Gets the value contained in the optional value.
	/// </summary>
	/// <exception cref="InvalidOperationException">Thrown if the optional value has no value.</exception>
	public T Value
	{
		get
		{
			if (!_hasValue)
			{
				throw new InvalidOperationException("Optional does not have a value.");
			}
			return _value;
		}
	}

	/// <summary>
	/// Maps the current optional value to another optional value with a different type using the specified function.
	/// </summary>
	/// <typeparam name="TResult">The type of the result of the mapping function.</typeparam>
	/// <param name="func">The mapping function.</param>
	/// <returns>An optional value of type <typeparamref name="TResult"/>.</returns>
	public Optional<TResult> Map<TResult>(Func<T, TResult> func)
	{
		if (!_hasValue)
		{
			return Optional<TResult>.None;
		}

		return Optional<TResult>.Some(func(_value));
	}
}