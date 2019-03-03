using System.Text;

namespace CodeWriter.MemberWriters
{
    /// <summary>
    /// Writes a constructor
    /// </summary>
    internal class ConstructorWriter : MemberWriterBase
    {
        private string className;
        private AccessModifiers modifiers;

        public ConstructorWriter(string className, AccessModifiers modifiers = AccessModifiers.@public)
        {
            this.className = className;
            this.modifiers = modifiers;
        }

        protected override MemberType Type { get { return MemberType.constructor; } }

        protected override string Name { get { return !string.IsNullOrEmpty(className) ? className : "[CONSTRUCTOR!]"; } }

        protected override AccessModifiers Modifier { get { return AccessModifiers.@public; } }

        public override string BodyAsString { get; set; }

        protected override string EndWrite()
        {
            var sb = new StringBuilder();

            if(!string.IsNullOrEmpty(BodyAsString))
            {
                sb.AppendLine(BodyAsString);
            }

            sb.AppendLine(Constantes.CLOSING_CURLY_BRACE);

            return sb.ToString();
        }

        protected override string StartWrite()
        {
            return $"{Modifier.ToString()} {Name}(){Constantes.OPENING_CURLY_BRACE}";
        }
    }
}