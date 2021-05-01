# FluxUwp
Unidirectional data flow for UWP application. Inherit the core concept from Flux architecture.  
https://facebook.github.io/flux/

## Structure and Dataflow
![flux-simple-f8-diagram-with-client-action-1300w](https://user-images.githubusercontent.com/33407061/116772485-5f89b080-aa8a-11eb-9d70-79f8b8f9ac3d.png)

## Usage
### Action
```c#
public enum Action
{
    Increment,
    Decrement,
}
```

### Mutation
```c#
public enum Mutation
{
    INCREMENT,
    DECREMENT,
}
```

### State
A setter & getter class
```c#
public class State: StateType
{
    private int _counter;
    public int Counter
    {
        get { return _counter; }
        set
        {
            _counter = value;
            base.InvokeNotify(nameof(Counter));
        }
    }
}
```

### Binding
```c#
public MainPage()
{
    this.InitializeComponent();

    /// Binding state with Control
    this.fluxDispatcher.Bind(this);
}
```

```xaml
<TextBlock x:Name="CounterLabel"
           Text="{Binding Path=Counter, Mode=TwoWay}"
           HorizontalAlignment="Center" />
```

## Dependency
[System.Reactive](https://www.nuget.org/packages/System.Reactive)
