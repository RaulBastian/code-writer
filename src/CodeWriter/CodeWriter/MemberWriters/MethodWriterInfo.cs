using System;

namespace CodeWriter.MemberWriters
{
    /// <summary>
    /// Info class used to write a method
    /// </summary>
    public class MethodWriterInfo
    {
        public MethodWriterInfo(string name)
        {
            this.Name = name;
        }

        public AccessModifiers Modifier { get; set; }

        public string Name { get; set; }

        public Type ReturnType { get; set; }

        public string BodyAsString { get; set; }
    }
}