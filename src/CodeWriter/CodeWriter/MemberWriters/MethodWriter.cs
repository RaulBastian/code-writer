using System;
using System.IO;
using System.Text;

namespace CodeWriter.MemberWriters
{
    /// <summary>
    /// Writes a method
    /// </summary>
    internal class MethodWriter : MemberWriterBase
    {
        private Type returnType = null;
        private AccessModifiers? modifier = null;
        private string methodName = "";

        public MethodWriter(string name, Type returnType = null, AccessModifiers? modifider = null)
        {
            this.methodName = name;
            this.modifier = modifider;
            this.returnType = returnType;
        }

        public override string BodyAsString { get; set; }

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
            var sb = new StringBuilder();

            if(!string.IsNullOrEmpty(BodyAsString))
            {
                sb.Append(BodyAsString);
            }

            sb.AppendLine($"{Constantes.CLOSING_CURLY_BRACE}");

            return sb.ToString();
        }
    }
}