using NUnit.Framework;
using System.Linq;

namespace SaddlePointKata
{
    [TestFixture]
    public class SaddleTests
    {
        // A saddle point is a cell whose value is greater than or equal to any in its
        // row, and less than or equal to any in its column.

        [Test]
        public void Returns25NumbersGivenGridOfSameValue()
        {
            var result = SaddleAnalyzer.GetSaddleValues(GetSingleNumberGrid());
            Assert.AreEqual(25, result.Count);
        }

        [Test]
        public void Returns5LastColumnValuesGivenGridOfAscendingRows()
        {
            var result = SaddleAnalyzer.GetSaddleValues(GetTestGrid());
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(5, result.Count(r => r.Value == 4));
        }

        [Test]
        public void ReturnsOneItemGivenGridOfProducts()
        {
            var result = SaddleAnalyzer.GetSaddleValues(GetProductGrid());
            Assert.AreEqual(1, result.Count(r => r.Value == 5));
        }

        [Test]
        public void ReturnsEmptyListGivenNoSaddleGrid()
        {
            var result = SaddleAnalyzer.GetSaddleValues(GetNoSaddleGrid());
            Assert.False(result.Any());
        }

        /*
        0 1 2 3 4
        0 1 2 3 4
        0 1 2 3 4
        0 1 2 3 4
        0 1 2 3 4
        Should yield every cell in the last column
        */
        public static int[,] GetTestGrid()
        {
            var grid = new int[5, 5];

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    grid[row, col] = col;
                }
            }
            return grid;
        }

        public static int[,] GetSingleNumberGrid()
        {
            var grid = new int[5, 5];

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    grid[row, col] = 1;
                }
            }
            return grid;
        }

        /*
        1 2   3  4  5
        2 4   6  8 10
        3 6   9 12 15
        4 8  12 16 20
        5 10 15 20 25
        */
        public static int[,] GetProductGrid()
        {
            var grid = new int[5, 5];

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    grid[row, col] = (row + 1) * (col + 1);
                }
            }
            return grid;
        }
        /*
        1 2   3  4  5
        2 10  6  8  4
        3 6   9 12 15
        4 8  12 16 20
        5 10 15 20 25
        */
        public static int[,] GetNoSaddleGrid()
        {
            var grid = new int[5, 5];

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    grid[row, col] = (row + 1) * (col + 1);
                }
            }
            grid[1, 1] = 10;
            grid[1, 4] = 4;
            return grid;
        }
    }
}
