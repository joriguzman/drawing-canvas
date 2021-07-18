using drawing_canvas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

namespace drawing_canvas_tests
{
    [TestClass]
    public class CanvasTests
    {
        [TestMethod]
        public void RenderOutput_WithNoContent_ShouldRenderEmptyContentWithBorders()
        {
            Canvas canvas = new Canvas(20, 4);

            var expected =
@"----------------------
|                    |
|                    |
|                    |
|                    |
----------------------";

            canvas.RenderOutput().Should().Be(expected);
        }

        [TestMethod]
        public void CreateCanvas_InvalidDimensions_ShouldThrowException()
        {
            Action action = () => new Canvas(4, 0);

            action.Should().Throw<Exception>().WithMessage("Invalid dimensions");
        }

        [TestMethod]
        public void RenderOutput_WithMultipleDrawings_ShouldRenderDrawings()
        {
            Canvas canvas = new Canvas(20, 4);

            canvas.Draw(new Line(1, 2, 6, 2));
            canvas.Draw(new Line(6, 3, 6, 4));
            canvas.Draw(new Rectangle(14, 1, 18, 3));
            canvas.Draw(new BucketFill(10, 3, "o"));

            var expected =
@"----------------------
|oooooooooooooxxxxxoo|
|xxxxxxooooooox   xoo|
|     xoooooooxxxxxoo|
|     xoooooooooooooo|
----------------------";

            canvas.RenderOutput().Should().Be(expected);
        }
    }
}
