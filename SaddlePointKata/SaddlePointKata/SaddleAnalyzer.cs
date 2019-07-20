using NUnit.Framework;
using System.Collections.Generic;

namespace SaddlePointKata
{
    public class SaddleAnalyzer
    {
        public static List<GridPoint> GetSaddleValues(int[,] grid)
        {
            var rowMaxValues = new Dictionary<int, int>();
            var colMinValues = new Dictionary<int, int>();

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (!rowMaxValues.ContainsKey(row))
                    {
                        rowMaxValues.Add(row, grid[row, col]);
                    }
                    if (!colMinValues.ContainsKey(col))
                    {
                        colMinValues.Add(col, grid[row, col]);
                    }
                    if (grid[row, col] > rowMaxValues[row])
                    {
                        rowMaxValues[row] = grid[row, col];
                    }
                    if (grid[row, col] < colMinValues[col])
                    {
                        colMinValues[col] = grid[row, col];
                    }
                }
            }

            var saddlePoints = new List<GridPoint>();
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    var candidate = grid[row, col];
                    if (candidate == rowMaxValues[row] && candidate == colMinValues[col])
                    {
                        saddlePoints.Add(new GridPoint()
                        {
                            Row = row,
                            Column = col,
                            Value = grid[row, col]
                        });
                    }
                }
            }
            return saddlePoints;
        }
    }

}