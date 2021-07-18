using drawing_canvas;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace drawing_canvas_tests
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void DrawLine_Y1AndY2AreSame_ShouldDrawHorizontalLine()
        {
            Canvas canvas = new Canvas(20, 4);
            Line line = new Line(1, 2, 6, 2);

            canvas.Draw(line);

            var expected = new string[,]
            {
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {"x", "x", "x", "x", "x", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void DrawLine_X1AndX2AreSame_ShouldDrawVerticalLine()
        {
            Canvas canvas = new Canvas(20, 4);
            Line line = new Line(3, 4, 3, 1);

            canvas.Draw(line);

            var expected = new string[,]
            {
                {" ", " ", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
                {" ", " ", "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void DrawLine_X1IsGreaterThanX2_ShouldDrawHorizontalLine()
        {
            Canvas canvas = new Canvas(4, 4);
            Line line = new Line(4, 2, 2, 2);

            canvas.Draw(line);

            var expected = new string[,]
            {
                {" ", " ", " ", " "},
                {" ", "x", "x", "x"},
                {" ", " ", " ", " "},
                {" ", " ", " ", " "},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void DrawLine_Y1IsGreaterThanY2_ShouldDrawVerticalLine()
        {
            Canvas canvas = new Canvas(4, 4);
            Line line = new Line(2, 4, 2, 2);

            canvas.Draw(line);

            var expected = new string[,]
            {
                {" ", " ", " ", " "},
                {" ", "x", " ", " "},
                {" ", "x", " ", " "},
                {" ", "x", " ", " "},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void DrawLine_DiagonalLine_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            Line line = new Line(1, 2, 3, 4);

            Action action = () => canvas.Draw(line);

            action.Should().Throw<Exception>().WithMessage("Vertical or horizontal lines only");
        }

        [TestMethod]
        public void DrawLine_XIsOutsideCanvas_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            Line line = new Line(10, 1, 21, 4);

            Action action = () => canvas.Draw(line);

            action.Should().Throw<Exception>().WithMessage("Draw inside the canvas");
        }

        [TestMethod]
        public void DrawLine_YIsOutsideCanvas_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            Line line = new Line(10, 1, 15, 5);

            Action action = () => canvas.Draw(line);

            action.Should().Throw<Exception>().WithMessage("Draw inside the canvas");
        }
    }
}
