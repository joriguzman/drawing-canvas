using System.Linq;

namespace drawing_canvas
{
    public class Validator
    {
        public static string Validate(string[] args)
        {
            string type = args[0].ToUpper();

            if (type == "C")
            {
                if (args.Length != 3)
                {
                    return "Invalid number of arguments";
                }
                if (HasNonNumber(args[1], args[2]))
                {
                    return "Argument not a number";
                }
            }
            else if (type == "L" || type == "R")
            {
                if (args.Length != 5)
                {
                    return "Invalid number of arguments";
                }
                if (HasNonNumber(args[1], args[2], args[3], args[4]))
                {
                    return "Argument not a number";
                }
            }
            else if (type == "B")
            {
                if (args.Length != 4)
                {
                    return "Invalid number of arguments";
                }
                if (HasNonNumber(args[1], args[2]))
                {
                    return "Argument not a number";
                }
            }
            return null;
        }

        private static bool HasNonNumber(params string[] args)
        {
            return args.Any(arg => !int.TryParse(arg, out int result));
        }
    }
}