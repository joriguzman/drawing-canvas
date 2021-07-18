using System;
using System.Drawing;
using System.Linq;

namespace drawing_canvas
{
    partial class Program : Validator
    {
        static Canvas canvas = null;

        static void Main(string[] args)
        {
            PrintHelp();

            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.Write("Enter command: ");
                string input = Console.ReadLine();
                string[] cArgs = input.Trim().Split(' ');

                string error = Validate(cArgs);
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine($"Error: {error}");
                    continue;
                }

                shouldContinue = ExecuteCommand(cArgs);
            }
        }

        private static bool ExecuteCommand(string[] args)
        {
            try
            {
                switch (args[0].ToUpper())
                {
                    case "C":
                        canvas = new Canvas(int.Parse(args[1]), int.Parse(args[2]));
                        Console.WriteLine(canvas.RenderOutput());
                        return true;
                    case "L":
                        CheckIfCanvasExists(canvas);
                        var line = new Line(int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]));
                        canvas.Draw(line);
                        Console.WriteLine(canvas.RenderOutput());
                        return true;
                    case "R":
                        CheckIfCanvasExists(canvas);
                        var rectangle = new Rectangle(int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]));
                        canvas.Draw(rectangle);
                        Console.WriteLine(canvas.RenderOutput());
                        return true;
                    case "B":
                        CheckIfCanvasExists(canvas);
                        var fill = new BucketFill(int.Parse(args[1]), int.Parse(args[2]), args[3].ToString());
                        canvas.Draw(fill);
                        Console.WriteLine(canvas.RenderOutput());
                        return true;
                    case "Q":
                        Console.WriteLine("Quitting...");
                        return false;
                    default:
                        Console.WriteLine("Unsupported command");
                        return true;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return true;
        }

        private static void PrintHelp()
        {
            Console.WriteLine(@"
===== Console-based Drawing =====
Command         Description
C w h           Creates a new canvas of width w and height h.
L x1 y1 x2 y2   Creates a new line from (x1,y1) to (x2,y2). Currently only
                horizontal or vertical lines are supported. Horizontal and vertical lines
                will be drawn using the 'x' character.
R x1 y1 x2 y2   Creates a new rectangle, whose upper left corner is (x1,y1) and
                lower right corner is (x2,y2). Horizontal and vertical lines will be drawn
                using the 'x' character.
B x y c         Fills the entire area connected to (x,y) with ""colour"" c. The
                behavior of this is the same as that of the ""bucket fill"" tool in paint
                programs.
Q               Quit.
");
        }

        private static void CheckIfCanvasExists(Canvas canvas)
        {
            if (canvas == null) throw new Exception("Create canvas first");
        }
    }
}
