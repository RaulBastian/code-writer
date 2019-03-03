using CodeWriter.MemberWriters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeWriter.TypeWriters
{
    /// <summary>
    ///  Helper class used to write classes.
    /// </summary>
    public class ClassWriter : TypeWriterBase
    {
        private AccessModifiers? modifier = null;
        private string className = "";
        private string baseClass = "";

        private IList<string> interfaces = null;
        private IList<string> raw_entries = null;

        /// <summary>
        /// String builder constructor
        /// </summary>
        /// <param name="className"></param>
        /// <param name="builder"></param>
        /// <param name="modifier"></param>
        public ClassWriter(string className, StringBuilder builder, AccessModifiers? modifier = null)
         : this(className, new StringWriter(builder), modifier)
        {

        }

        /// <summary>
        /// String writer constructor
        /// </summary>
        /// <param name="className"></param>
        /// <param name="writer"></param>
        /// <param name="modifier"></param>
        public ClassWriter(string className, StringWriter writer, AccessModifiers? modifier = null)
            : base(writer)
        {
            this.className = className;
            this.modifier = modifier;
            this.interfaces = new List<string>();
            this.raw_entries = new List<string>();
        }

        /// <summary>
        /// Implements an interface
        /// </summary>
        /// <param name="name"></param>
        public void ImplementInterface(string name)
        {
            this.interfaces.Add(name);
        }

        public void ImplementInterface<T>()
        {
            if(!typeof(T).IsInterface)
            {
                throw new ArgumentException("Interface");
            }

            this.interfaces.Add(typeof(T).FullName);
        }

        /// <summary>
        /// Sets the base class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetBaseClass<T>()
        {
            this.baseClass = typeof(T).FullName;
        }

        /// <summary>
        /// Sets the base class
        /// </summary>
        /// <param name="name"></param>
        public void SetBaseClass(string name)
        {
            this.baseClass = name;
        }

        public void WriteRaw(string content)
        {
            raw_entries.Add(content);
        }

        /// <summary>
        /// Writes a constructor with the option to provide a body
        /// </summary>
        /// <param name="info"></param>
        public void WriteConstructor(ConstructorWriterInfo info)
        {
            Members.Add(new ConstructorWriter(this.Name, info.Modifier)
            {
               BodyAsString = info.BodyAsString
            });
        }

        /// <summary>
        /// Writes an empty constructor
        /// </summary>
        /// <param name="modifider"></param>
        public void WriteConstructor(AccessModifiers modifider = AccessModifiers.@public)
        {
            Members.Add(new ConstructorWriter(this.Name, modifider));
        }

        /// <summary>
        /// Writes a method with the option to provide a body
        /// </summary>
        /// <param name="info"></param>
        public void WriteMethod(MethodWriterInfo info)
        {
            Members.Add(new MethodWriter(info.Name, info.ReturnType, info.Modifier)
            {
                BodyAsString = info.BodyAsString
            });
        }

        /// <summary>
        /// Writes an empty method
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="modifider"></param>
        /// <param name="returnType"></param>
        public void WriteMethod(string methodName, AccessModifiers modifider = AccessModifiers.@public, Type returnType = null)
        {
            Members.Add(new MethodWriter(methodName, returnType, modifider));
        }

        private string WriteInheritanceAndInterfaces()
        {
            string result = "";

            if (!string.IsNullOrEmpty(baseClass))
            {
                result = ":" + baseClass;
            }

            if (this.interfaces.Any())
            {
                if (string.IsNullOrEmpty(result))
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
            var sb = new StringBuilder();

            sb.AppendLine($"{Modifier.ToString()} {Type.ToString()} {Name}{WriteInheritanceAndInterfaces()}{Constantes.OPENING_CURLY_BRACE}");

            if (raw_entries.Any())
            {
                sb.AppendLine();

                foreach (var content in raw_entries)
                {
                    sb.AppendLine(content);
                }
            }

            return sb.ToString();
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