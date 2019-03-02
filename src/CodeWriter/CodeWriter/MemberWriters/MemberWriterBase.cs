using System.IO;

namespace CodeWriter.MemberWriters
{
    public abstract class MemberWriterBase: WriterBase
    {
        public MemberWriterBase(StringWriter writer) : base(writer) { }

        protected abstract MemberType Type { get; }

        protected abstract string StartWrite();

        protected abstract string EndWrite();

        public void Write()
        {
            Writer.WriteLine(StartWrite());
            Writer.WriteLine(EndWrite());
        }
    }
}