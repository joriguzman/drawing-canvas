# Drawing Canvas
A console-based drawing app. Coding challenge for Credit Suisse.

Unit tests are in drawing-canvas-tests folder.

### Usage
Go to drawing-canvas folder then run `dotnet run drawing-canvas-tests.csproj`

### Supported commands

```
Command         Description
C w h           Should create a new canvas of width w and height h.
L x1 y1 x2 y2   Should create a new line from (x1,y1) to (x2,y2). Currently only
                horizontal or vertical lines are supported. Horizontal and vertical lines
                will be drawn using the 'x' character.
R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner is (x1,y1) and
                lower right corner is (x2,y2). Horizontal and vertical lines will be drawn
                using the 'x' character.
B x y c         Should fill the entire area connected to (x,y) with "colour" c. The
                behavior of this is the same as that of the "bucket fill" tool in paint
                programs.
Q               Should quit the program.
```

### Examples
```
Enter command: C 20 4
----------------------
|                    |
|                    |
|                    |
|                    |
----------------------

Enter command: L 1 2 6 2
----------------------
|                    |
|xxxxxx              |
|                    |
|                    |
----------------------

Enter command: L 6 3 6 4
----------------------
|                    |
|xxxxxx              |
|     x              |
|     x              |
----------------------

Enter command: R 14 1 18 3
----------------------
|             xxxxx  |
|xxxxxx       x   x  |
|     x       xxxxx  |
|     x              |
----------------------

Enter command: B 10 3 o
----------------------
|oooooooooooooxxxxxoo|
|xxxxxxooooooox   xoo|
|     xoooooooxxxxxoo|
|     xoooooooooooooo|
----------------------
```
