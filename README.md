# Code Writer
Helper classes used to write code

### To be used like:

            var sb = new StringBuilder();
            using (var classWriter = new ClassWriter("PersonViewModel", sb))
            {
                classWriter.SetBaseClass("BindableBase");
                classWriter.ImplementInterface("INotifyPropertyChanged");
                classWriter.WriteMethod("Method1");
                classWriter.WriteMethod("Method2");
                classWriter.WriteMethod("Method3", AccessModifiers.@private,typeof(int));
            }

            string  generated_class = sb.ToString();
            
### Which generates:         
```
public class PersonViewModel:BindableBase,INotifyPropertyChanged{

public void Method1(){
}


public void Method2(){
}


private System.Int32 Method3(){
}

}
```
