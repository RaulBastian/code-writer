
using System.IO;

namespace CodeWriter
{
    public abstract class WriterBase
    {
        private StringWriter writer = null;

        public WriterBase(StringWriter writer)
        {
            this.writer = writer;
        }

        protected abstract string Name { get; }

        protected abstract AccessModifiers Modifier { get; }

        protected StringWriter Writer
        {
            get { return writer; }
        }
    }
}