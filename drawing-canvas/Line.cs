using System;

namespace drawing_canvas
{
    public class Line : IDrawing
    {
        private readonly int x1;
        private readonly int y1;
        private readonly int x2;
        private readonly int y2;
        private readonly string color;

        public Line(int x1, int y1, int x2, int y2, string color = "x")
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.color = color;
        }

        public void ValidateOn(Canvas canvas)
        {
            if (x1 < 1 || x2 < 1 || y1 < 1 || y2 < 1 ||
                x1 > canvas.Width || x2 > canvas.Width || y1 > canvas.Height || y2 > canvas.Height)
            {
                throw new Exception("Draw inside the canvas");
            }

            if (x1 != x2 && y1 != y2)
            {
                throw new Exception("Vertical or horizontal lines only");
            }
        }

        public void DrawOn(Canvas canvas)
        {
            if (y1 == y2) // Horizontal
            {
                int start = Math.Min(x1, x2) - 1;
                int end = Math.Max(x1, x2) - 1;
                for (int i = start; i <= end; i++)
                {
                    canvas.SetCell(y1 - 1, i, color);
                }
            }
            else if (x1 == x2) // Vertical
            {
                int start = Math.Min(y1, y2) - 1;
                int end = Math.Max(y1, y2) - 1;
                for (int i = start; i <= end; i++)
                {
                    canvas.SetCell(i, x1 - 1, color);
                }
            }
        }
    }
}
