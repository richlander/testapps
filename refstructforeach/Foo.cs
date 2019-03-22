using System;
using System.Collections;

public ref struct Foo
{
    private Span<int> _data;

    public Foo(Span<int> data)
    {
        _data = data;
    }

    // Could have just made this return "Foo" instead of creating a new type
    // No one wants the IEnumerator methods on the main type, so a nested type is better
    // This is the pattern used by Span<T> as well. 
    // Avoids these boiler-plate methods showing up in intellisense
    public Enumerator GetEnumerator()
    {
        return new Enumerator(_data);
    }

    public ref struct Enumerator
    {
        private Span<int> _data;
        private int _index;

        public Enumerator(Span<int> data)
        {
            _data = data;
            _index = -1;
        }

        public object Current => _data[_index];

        public bool MoveNext()
        {
            _index++;
            return _index < _data.Length;
        }
    }
}
