
using System.IO;

namespace CodeWriter
{
    internal abstract class WriterBase
    {
        protected abstract string Name { get; }

        protected abstract AccessModifiers Modifier { get; }
    }
}