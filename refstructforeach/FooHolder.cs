using System;

public ref struct TwoFooHolder
{
    Foo _one;
    Foo _two;

    public TwoFooHolder(Foo one, Foo two)
    {
        _one = one;
        _two = two;
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    public ref struct Enumerator
    {
        private TwoFooHolder _holder;
        private int _index;

        public Enumerator(TwoFooHolder holder)
        {
            _holder = holder;
            _index = -1;
        }

        public Foo Current => (_index == 0) ? _holder._one : _holder._two;

        public bool MoveNext()
        {
            _index++;
            return _index < 2;
        }
    }
}