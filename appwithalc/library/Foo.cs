using System;
using interfaces;

namespace library
{
    public class Foo : IFoo
    {
        public string GetFoo() => "Hello";
    }
}
