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

The current solution is based on three main modules:

1. **Widgets**: Contains all the widgets that can be used to build the plot.
2. **Drawing**: Contains all abstractions and specific implementations for drawing the plot (e.g., console, file, etc.).
3. **App**: A deployable application that utilizes the Widgets and Drawing modules.
```
        +-------------+
        |     App     |
        +-------------+         Application configuration, logging, and startup activities
               |
               v
-------------------------------------
     +---------------------+
     |      Drawing        |
     +---------------------+
               |
    +----------+-----------+
    |                      |        Drawing contracts and specific implementations
    v                      v
+-------+             +--------+
|Console|             |  File  |
+-------+             +--------+
               |
               v
-------------------------------------
        +-------------+
        |   Widgets   |
        +-------------+
               |
    +----------+----------+----------+        Widget models and main geometrical operations
    |          |          |          |
    v          v          v          v
+-------+  +-------+  +--------+  +--------+
| Square|  |Rectangle| | Circle |  |Ellipse |
+-------+  +-------+  +--------+  +--------+
                |
                v
           +---------+
           | TextBox |
           +---------+
```

### Widgets

The primary responsibility of the Widgets module is to share representation models and main geometrical operations on them. The designed widget structure is flat, with no complex hierarchy, making it easy to use and extend.
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
Despite what intuition might suggest, Rectangle and Square (as well as Ellipse and Circle) are not grouped together. This approach avoids design limitations (preventing free changes to the widget type as needed) and potential Liskov Substitution Principle (LSP) violations from inheritance relationships.

Conversely, the TextBox widget is defined as a special case of the Rectangle widget. At the design level, it is agreed that all Rectangle invariants and contracts are applicable to a TextBox as well.

Dimensions are represented as different types to ensure type safety (e.g., preventing Width from being replaced with Height) and to validate invariants, such as "Height must be positive."

### Drawing

Defines abstractions required for specific drawing implementations:

`ISurface`: Represents a surface where the plot will be drawn.

`IDrawable`: Represents specific logic for shape rendering.

`IRenderOutput`: Represents the rendered output that the surface will use.

### Drawing.Console

Contains the specific implementation for drawing the plot in the console, using System.Console. The main responsibilities of this module are to implement renderers for supported shapes and provide specific rendering logic for the console.

Drawing.* provides one of the main extensibility points for the solution. It allows us to add new rendering implementations (e.g., Drawing.File, Drawing.Web, etc.) without changing the core logic of the app.

### App
As a deployable unit, we use a .NET 8 console application. It employs a generic host to configure and resolve dependencies. The main responsibilities include app configuration, logging, and startup activities.

#### Future considerations:
**Type hierarchy**: We might consider using structs instead of classes for the widgets. This could potentially improve performance and reduce the memory footprint.

**Performance Optimization**: We might consider using structs instead of classes for the widgets. This could potentially improve performance and reduce the memory footprint.

**Rendering Standard**: We need to define a proper rendering standard. Currently, we use IRenderOutput.cs, but it is obviously not sufficient to represent the different output aspects.

**Input Validation**: Currently, we throw an exception for every invalid argument (like negative height or width), which is not user-friendly. Implementing some middleware that converts exceptions into user messages or something similar should be considered.