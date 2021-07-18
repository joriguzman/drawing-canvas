using drawing_canvas;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace drawing_canvas_tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void DrawRectangle_LeftToRightPoints_ShouldDrawRectangle()
        {
            Canvas canvas = new Canvas(20, 4);
            Rectangle rectangle = new Rectangle(14, 1, 18, 3);

            canvas.Draw(rectangle);

            var expected = new string[,]
            {
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "x", " ", " ", " ", "x", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void DrawRectangle_RightToLeftPoints_ShouldDrawRectangle()
        {
            Canvas canvas = new Canvas(20, 4);
            Rectangle rectangle = new Rectangle(7, 4, 5, 2);

            canvas.Draw(rectangle);

            var expected = new string[,]
            {
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", "x", "x", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", "x", " ", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", "x", "x", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void DrawRectangle_OutsideCanvas_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            Rectangle rectangle = new Rectangle(1, 1, 21, 4);

            Action action = () => canvas.Draw(rectangle);

            action.Should().Throw<Exception>().WithMessage("Draw inside the canvas");
        }

        [TestMethod]
        public void DrawRectangle_StraightPoints_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            Rectangle rectangle = new Rectangle(1, 1, 3, 1);

            Action action = () => canvas.Draw(rectangle);

            action.Should().Throw<Exception>().WithMessage("Points should not be a straight line");
        }
    }
}
