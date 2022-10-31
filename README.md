# Ocean Finite Machine

![](https://i.imgur.com/foM5qZO.png)

A code-only, simple and easy to use Finite State Machine for your Unity Projects.

## Adding to your project
Open the package manager, click the plus sign and choose "Add package from git URL".
Use the link below.
```
https://github.com/Macawls/OceanFsm.git
```

## Example Scene
You can find the example scene under ~/Samples. 
Copy it into your projects' assets folder to try it out! :)

## Getting Started
There are two things you need, a state machine and states.

### Creating a State Machine
Create a new script, inherit from OceanMachine and pass in the type.

```csharp
public class ExampleMachine : OceanMachine<ExampleMachine>
```

### Adding States

Add states and supply any dependencies you might have.

```csharp
private void Start()
{
    AddState(new FirstExampleState(this);
    AddState(new SecondExampleState(this));

    TransitionToState<FirstState>();
}
```

### Creating a State

Create a new script, inherit from OceanState and pass in the type.
The following handlers are optional

* IEnterHandler
* IExitHandler
* IUpdateHandler
* IFixedUpdateHandler

```csharp
public class FirstExampleState : OceanState<CubeMachine>, IEnterHandler, IUpdateHandler, IExitHandler
{
    public FirstState(CubeMachine machine) : base(machine)
    {
    }

    public void OnEnter()
    {
        Debug.Log("Entered First State");
    }
    
    public void OnUpdate()
    {
        Debug.Log("Updating First State");
    }

    public void OnExit()
    {
        Debug.Log("Exited First State");
    }   
 }
```

### Transitioning Between States

You can transition between states by calling Machine.TransitionToState from within the State.

```csharp
public void OnUpdate(float deltaTime)
{
    _timeElapsed += deltaTime;

    if (_timeElapsed > 2f)
    {
        Machine.TransitionToState<SecondState>();
    }
}
```