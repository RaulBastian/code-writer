# Code Writer
Helper classes used to write code

### To be used like:

            var sb = new StringBuilder();
            using (var cw = new ClassWriter("PersonViewModel", sb))
            {
                cw.SetBaseClass("BindableBase");
                cw.ImplementInterface("INotifyPropertyChanged");
                cw.WriteMethod("Method1");
                cw.WriteMethod("Method2");
                cw.WriteMethod("Method3", AccessModifiers.@private,typeof(int));
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
