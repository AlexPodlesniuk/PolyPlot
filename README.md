App requirements: .NET 8.0

Run tests: 
```
cd PolyPlot
dotnet test
```

Run app:
```
cd PolyPlot.App
dotnet run
```

# Solution structure

Current solution is based on 3 main modules:
1. Widgets: contains all the widgets that can be used to build the plot
2. Drawing: contains all abstractions and specific implementations for drawing the plot (e.g. console, file, etc.)
3. App: deployable application that uses the widgets and drawing modules

### Widgets

The main responsibilities for the widgets module are share representation models and main geometrical operations on them.
The designed widget structure is flat with no complex hierarchy, which makes it easy to use and extend.
```
                        +--------+
                        | Widget |
                        +--------+
                           ^   
                           |   
        +---------------+-----------+------------+
        |               |           |            |
        v               v           v            v
+----------+        +------+    +------+    +--------+
| Rectangle|        |Square|    |Circle|    |Ellipse|
+----------+        +------+    +------+    +--------+
      ^
      |
      v
  +---------+
  | TextBox |
  +---------+
```
Despite intuition might suggest that Rectangle and Square (as well as Ellipse and Circle) should be in the same type group, it can easily lead 
design limitation (we won't be able to freely change the type of the widget according to our need) as well as LSP violation if we will start to break
contracts from inheritence relationship.

An opposite decision was made for the TextBox widget, which was defined a special case of the Rectangle widget. On design level, it is agreed that all
Rectangle invariants and contracts will be applicable for a Textbox as well.

Dimensions are represented as different types in order to ensure type safety (Width should not be replaced with Height) 
as well as validating invariants like: "Height should be positive".

### Drawing

Defines abstractions that will be required for specific drawing implementations:
ISurface - represents a surface where the plot will be drawn
IDrawable - represents a specifc for shape rendering logic
IRenderOutput - represents a rendered output that surface will use

### Drawing.Console

Contains specific implementation for drawing the plot in the console. It uses System.Console to draw the plot.
The main responsibilities for this module are to implement renderers for supported shapes and to provide a specific rendering logic for the console.

### App
As a deployable unit, we are using .NET 8 console application. It uses generic host to configure and resolve dependencies.
The main responsibilities are app configuration, logging, startup activities.


#### Future considerations:
1. We will need to define a proper rendering standard. For now we are using IRenderOutput.cs but it is obviously not enough to represent the different output aspects
2. Validation of the input data. For now we are throwing exception on every non valid argument (like negative height or width) that is not really user friendly. We should implement some middleware that will convert exception into user messages or smth like this