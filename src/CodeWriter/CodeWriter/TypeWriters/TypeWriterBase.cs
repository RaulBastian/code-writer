using CodeWriter.MemberWriters;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeWriter.TypeWriters
{

    public abstract class TypeWriterBase : WriterBase, IDisposable
    {
        private List<MemberWriterBase> members = new List<MemberWriterBase>();

        public TypeWriterBase(StringWriter writer) : base(writer)
        {
     
        }

        protected abstract Types Type { get; }

        protected List<MemberWriterBase> Members { get { return members; } }

        public abstract string StartWrite();

        public abstract string EndWrite();

        public void Dispose()
        {
            Writer.WriteLine(StartWrite());

            foreach(var member in Members)
            {
                Writer.WriteLine();
                member.Write();
                Writer.WriteLine();
            }

            Writer.WriteLine(EndWrite());

            Writer.Dispose();
        }
    }
}