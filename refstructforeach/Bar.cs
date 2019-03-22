using System;
using System.Collections;

public ref struct Bar
{
    private Span<int> _data;
    private int _index;

    public Bar(Span<int> data)
    {
        _data = data;
        _index = -1;
    }

    public object Current => _data[_index];
    public Span<int>.Enumerator GetEnumerator()
    {
        return _data.GetEnumerator();
    }
}