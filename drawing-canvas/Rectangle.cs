using System;

namespace drawing_canvas
{
    public class Rectangle : IDrawing
    {
        private readonly int x1;
        private readonly int y1;
        private readonly int x2;
        private readonly int y2;
        private readonly string color;

        public Rectangle(int x1, int y1, int x2, int y2, string color = "x")
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.color = color;
        }

        public void DrawOn(Canvas canvas)
        {
            canvas.Draw(new Line(x1, y1, x2, y1, color)); // Top/Bottom line
            canvas.Draw(new Line(x1, y1, x1, y2, color)); // Left/Right line
            canvas.Draw(new Line(x2, y1, x2, y2, color)); // Left/Right line
            canvas.Draw(new Line(x1, y2, x2, y2)); // Top/Bottom line
        }

        public void ValidateOn(Canvas canvas)
        {
            if (x1 == x2 || y1 == y2)
            {
                throw new Exception("Points should not be a straight line");
            }
        }
    }
}
