using System;
using System.IO;

namespace CodeWriter.MemberWriters
{
    public class MethodWriter : MemberWriterBase
    {
        private Type returnType = null;
        private AccessModifiers? modifier = null;
        private string methodName = "";

        public MethodWriter(string name,StringWriter writer, Type returnType = null, AccessModifiers? modifider = null)
            :base(writer)
        {
            this.methodName = name;
            this.modifier = modifider;
            this.returnType = returnType;
        }

        protected override MemberType Type { get { return MemberType.method; } }

        protected override AccessModifiers Modifier { get { return modifier.HasValue ? modifier.Value : AccessModifiers.@public; } }

        protected override string Name { get { return !string.IsNullOrEmpty(methodName) ? methodName : "[METHOD NAME]"; } }

        protected override string StartWrite()
        {
            string ret = returnType == null ? "void" : returnType.FullName;

            return $"{Modifier.ToString()} {ret} {Name}(){Constantes.OPENING_CURLY_BRACE}";
        }

        protected override string EndWrite()
        {
            return $"{Constantes.CLOSING_CURLY_BRACE}";
        }
    }
}