using System;
using System.Text;

namespace drawing_canvas
{
    public class Canvas
    {
        public string[,] Content { get; private set; }

        public int Height => Content.GetLength(0);

        public int Width => Content.GetLength(1);

        // Height = rows, Width = columns
        public Canvas(int width, int height)
        {
            if (width < 1 || height < 1)
            {
                throw new Exception("Invalid dimensions");
            }

            Content = new string[height, width];
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Content[row, col] = " ";
                }
            }
        }

        public void Draw(IDrawing drawing)
        {
            drawing.ValidateOn(this);
            drawing.DrawOn(this);
        }

        public string RenderOutput()
        {
            string horizontalBorder = new string('-', Width + 2);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(horizontalBorder);

            for (int row = 0; row < Height; row++)
            {
                string line = "|";

                for (int col = 0; col < Width; col++)
                {
                    line += Content[row, col];
                }

                line += "|";
                builder.AppendLine(line);
            }

            builder.Append(horizontalBorder);
            return builder.ToString();
        }

        public void SetCell(int row, int col, string color)
        {
            Content[row, col] = color;
        }
    }
}
