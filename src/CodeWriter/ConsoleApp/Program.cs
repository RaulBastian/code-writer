using CodeWriter;
using CodeWriter.TypeWriters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            using (var classWriter = new ClassWriter("PersonViewModel", sb))
            {
                classWriter.SetBaseClass("BindableBase");
                classWriter.ImplementInterface("INotifyPropertyChanged");
                classWriter.WriteMethod("Method1");
                classWriter.WriteMethod("Method2");
                classWriter.WriteMethod("Method3", AccessModifiers.@private,typeof(int));
            }

            string def = sb.ToString();
        }
    }
}
