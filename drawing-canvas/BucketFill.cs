using System;

namespace drawing_canvas
{
    public class BucketFill : IDrawing
    {
        private readonly int x;
        private readonly int y;
        private readonly string color;

        public BucketFill(int x, int y, string color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public void DrawOn(Canvas canvas)
        {
            Fill(canvas, x - 1, y - 1, canvas.Content[y - 1, x - 1], color);
        }

        // Recursively call to change color on all directions until boundary or another drawing is hit
        private void Fill(Canvas canvas, int x, int y, string previousColor, string newColor)
        {
            if (x < 0 || y < 0 || x >= canvas.Width || y >= canvas.Height || // Canvas boundary
                previousColor != canvas.Content[y, x]) // Another drawing is hit
            {
                return;
            }

            canvas.SetCell(y, x, newColor);
            Fill(canvas, x + 1, y, previousColor, newColor);
            Fill(canvas, x - 1, y, previousColor, newColor);
            Fill(canvas, x, y + 1, previousColor, newColor);
            Fill(canvas, x, y - 1, previousColor, newColor);
        }

        public void ValidateOn(Canvas canvas)
        {
            if (x < 1 || y < 1 || x > canvas.Width || y > canvas.Height)
            {
                throw new Exception("Draw inside the canvas");
            }

            if (color.Length != 1)
            {
                throw new Exception("Color should be a single character");
            }
        }
    }
}
