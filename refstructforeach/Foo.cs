using System;
using System.Collections;

public ref struct Foo
{
    private Span<int> _data;

    public Foo(Span<int> data)
    {
        _data = data;
    }

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