using drawing_canvas;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace drawing_canvas_tests
{
    [TestClass]
    public class BucketFillTests
    {
        [TestMethod]
        public void BucketFill_ShouldFillArea()
        {
            Canvas canvas = new Canvas(5, 3);
            canvas.Draw(new Line(2, 2, 3, 2));
            canvas.Draw(new Line(5, 1, 5, 2));

            BucketFill fill = new BucketFill(4, 2, "o");

            canvas.Draw(fill);

            var expected = new string[,]
            {
                {"o", "o", "o", "o", "x"},
                {"o", "x", "x", "o", "x"},
                {"o", "o", "o", "o", "o"},
            };

            canvas.Content.Should().Equal(expected);
        }

        [TestMethod]
        public void BucketFill_OutsideCanvas_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            BucketFill fill = new BucketFill(21, 2, "o");

            Action action = () => canvas.Draw(fill);

            action.Should().Throw<Exception>().WithMessage("Draw inside the canvas");
        }

        [TestMethod]
        public void BucketFill_InvalidColor_ShouldThrowException()
        {
            Canvas canvas = new Canvas(20, 4);
            BucketFill fill = new BucketFill(2, 2, "oy");

            Action action = () => canvas.Draw(fill);

            action.Should().Throw<Exception>().WithMessage("Color should be a single character");
        }
    }
}
