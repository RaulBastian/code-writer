# Code Writer
Helper classes used to write code

### To be used like:
```
 var sb = new StringBuilder();
            using (var cw = new ClassWriter("PersonViewModel", sb))
            {
                //Base class and interfaces
                cw.SetBaseClass("BindableBase");
                cw.ImplementInterface<INotifyPropertyChanged>();

                //Private fields
                cw.WriteRaw("private IList<string> entries = null");
                cw.WriteRaw("private IList<string> entries1 = null");

                //Constructors
                cw.WriteConstructor();
                cw.WriteConstructor(new ConstructorWriterInfo()
                {
                    BodyAsString = (new StringBuilder()
                                         .AppendLine("string s = 'Hello';")
                                   ).ToString()
                });

                //Methods
                cw.WriteMethod("Method1");
                cw.WriteMethod("Method2");
                cw.WriteMethod("Method3", AccessModifiers.@private, typeof(int));
                cw.WriteMethod(new MethodWriterInfo("Method4")
                {
                    BodyAsString = (new StringBuilder()
                                        .AppendLine("int a = 2;")
                                        .AppendLine("int b = 4;")
                                        .AppendLine("int c = a + b;")
                                        .AppendLine("Console.WriteLine(c);")
                                     ).ToString()
                });
            }
```            
### Which generates:         
```
public class PersonViewModel:BindableBase,System.ComponentModel.INotifyPropertyChanged{

private IList<string> entries = null
private IList<string> entries1 = null

public PersonViewModel(){
}

public PersonViewModel(){
string s = 'Hello';

}

public void Method1(){
}

public void Method2(){
}

private System.Int32 Method3(){
}

public void Method4(){
int a = 2;
int b = 4;
int c = a + b;
Console.WriteLine(c);
}

}

```
