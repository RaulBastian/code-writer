using System.IO;

namespace CodeWriter.MemberWriters
{
    /// <summary>
    /// Member writer base class
    /// </summary>
    internal abstract class MemberWriterBase : WriterBase
    {
        public MemberWriterBase() : base() { }

        public abstract string BodyAsString { get; set; }

        protected abstract MemberType Type { get; }

        protected abstract string StartWrite();

        protected abstract string EndWrite();

        public void Write(StringWriter writer)
        {
            writer.WriteLine(StartWrite());
            writer.WriteLine(EndWrite());
        }
    }
}