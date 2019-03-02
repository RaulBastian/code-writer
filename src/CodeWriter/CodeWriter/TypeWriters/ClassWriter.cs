using CodeWriter.MemberWriters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeWriter.TypeWriters
{
    public class ClassWriter : TypeWriterBase
    {
        private AccessModifiers? modifier = null;
        private string className = "";
        private string baseClass = "";

        private IList<string> interfaces = null;


        public ClassWriter(string className, StringBuilder builder, AccessModifiers? modifier = null)
         : this(className, new StringWriter(builder), modifier)
        {

        }

        public ClassWriter(string className, StringWriter writer, AccessModifiers? modifier = null)
            : base(writer)
        {
            this.className = className;
            this.modifier = modifier;
            this.interfaces = new List<string>();
        }

        public void ImplementInterface(string name)
        {
            this.interfaces.Add(name);
        }

        public void SetBaseClass(string name)
        {
            this.baseClass = name;
        }

        public void WriteMethod(string methodName, AccessModifiers modifider = AccessModifiers.@public, Type returnType = null)
        {
            Members.Add(new MethodWriter(methodName,Writer,returnType, modifider));
        }

        private string WriteInheritanceAndInterfaces()
        {
            string result = "";

            if(!string.IsNullOrEmpty(baseClass))
            {
                result = ":" + baseClass;
            }

            if (this.interfaces.Any())
            {
                if(string.IsNullOrEmpty(result))
                {
                    result = ":";
                }
                else
                {
                    result = result + ",";
                }

                result = result + string.Join(",", interfaces);
            }

            return result;
        }

        public override string StartWrite()
        {
            return $"{Modifier.ToString()} {Type.ToString()} {Name}{WriteInheritanceAndInterfaces()}{Constantes.OPENING_CURLY_BRACE}";
        }

        public override string EndWrite()
        {
            return $"{Constantes.CLOSING_CURLY_BRACE}";
        }

        protected override Types Type { get { return Types.@class; } }

        protected override AccessModifiers Modifier { get { return modifier.HasValue ? modifier.Value : AccessModifiers.@public; } }

        protected override string Name { get { return !string.IsNullOrEmpty(className) ? className : "[CLASSNAME]"; } }
    }
}