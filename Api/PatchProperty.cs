namespace Api;

public class PatchProperty<T>
{
    public T? Value { get; }

    public PatchProperty(T? value)
        => Value = value;
}