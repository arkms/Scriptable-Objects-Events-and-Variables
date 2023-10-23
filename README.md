# Scriptable Objects Events and Variables (SOEV)

Basic scripts for an architecture with scriptable objects for Unity. Based on video from [Unite Austin 2017](https://www.youtube.com/watch?v=raQ3iHhE_Kk) and using Zack Bloundele project as starting point.

The 2 big differences in this version are that the variables do not have events directly and that they can be used as native variables.

## Installation

Using the Unity package manager using add package from git URL.

```bash
https://github.com/arkms/Scriptable-Objects-Events-and-Variables.git
```
Or just download project and put the project inside 'Assets' folder.

## Usage

First watch this [Video](https://www.youtube.com/watch?v=raQ3iHhE_Kk).


Now in your script add using 'ScriptableObjectVariable' for varaibles and/or 'ScriptableObjectEvent' for Events.

```csharp
using ScriptableObjectVariable;
using ScriptableObjectEvent;
```

Declare your variable

```csharp
public SOBool isGameRunningSo;
```

Unlike other alternatives, this version allows you to use the variables as a native variable, this mean you do this:

```csharp
// Othe alternatives -------------------------
if(isGameRunningSo.Value)
{   // True }

// or

bool oppositveValue = !isGameRunningSo.Value;

// With SOEV(this) version  ------------------------
if(isGameRunningSo)
{ // True }

// or

bool oppositeValue = !isGameRunningSo;

```

And if in a script you want to do an action when a variable has a change, you must create an event for it. You can check the scripts inside the 'Scripts' folder for examples how to use it.

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/) 2029 - ARKMs.
