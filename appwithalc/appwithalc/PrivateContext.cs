using System.Runtime.Loader;

namespace appwithalc
{
    public class PrivateContext : AssemblyLoadContext
    {
        public PrivateContext(string name) : base(name, false)
        {
        }
    }
}