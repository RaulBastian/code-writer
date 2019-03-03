using CodeWriter.MemberWriters;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeWriter.TypeWriters
{
    /// <summary>
    /// Helper base class used to write types (class, structs, interfaces...).
    /// </summary>
    public abstract class TypeWriterBase : IDisposable
    {
        private StringWriter writer = null;
        private List<MemberWriterBase> members = new List<MemberWriterBase>();

        public TypeWriterBase(StringWriter writer)
        {
            this.writer = writer;
        }

        /// <summary>
        /// The name of the type, this would be the name of the class, interface, struct etc..
        /// </summary>
        protected abstract string Name { get; }

        /// <summary>
        /// Defines the access modifier, how accesible is this type? public, private, internal etc
        /// </summary>
        protected abstract AccessModifiers Modifier { get; }

        /// <summary>
        /// Defines what type of writer this is: class, interface etc
        /// </summary>
        protected abstract Types Type { get; }

        /// <summary>
        /// Holds an internal collection of member writer instances: ConstructorWriters, MethodWriters, PropertyWriters.
        /// 
        /// They will be used internally to render the output
        /// </summary>
        internal List<MemberWriterBase> Members { get { return members; } }

        /// <summary>
        /// Starts writing ...
        /// </summary>
        /// <returns></returns>
        public abstract string StartWrite();

        /// <summary>
        /// Ends writing...
        /// </summary>
        /// <returns></returns>
        public abstract string EndWrite();

        /// <summary>
        /// This is where all the writing happens
        /// </summary>
        public void Dispose()
        {
            writer.WriteLine(StartWrite());

            foreach (var member in Members)
            {
                member.Write(writer);
            }

            writer.WriteLine(EndWrite());

            writer.Dispose();
        }
    }
}