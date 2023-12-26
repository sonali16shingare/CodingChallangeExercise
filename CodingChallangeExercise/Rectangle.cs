using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallangeExercise
{
    public class Rectangle : IShape
    {
        private readonly int x1, y1, x2, y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public void Draw(char[,] matrix)
        {
            DrawLine(x1, y1, x2, y1, matrix);
            DrawLine(x1, y1, x1, y2, matrix);
            DrawLine(x1, y2, x2, y2, matrix);
            DrawLine(x2, y1, x2, y2, matrix);

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[j, i]);
                }
                Console.WriteLine();
            }
        }

        private void DrawLine(int x1, int y1, int x2, int y2, char[,] matrix)
        {
            List<(int, int)> points = GetLinePoints(x1, y1, x2, y2);
            foreach (var point in points)
            {
              matrix[point.Item1, point.Item2] = 'x';


            }
            
           // Console.WriteLine(matrix);

        }
       
            private List<(int, int)> GetLinePoints(int x1, int y1, int x2, int y2)
        {
            List<(int, int)> points = new List<(int, int)>();
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            while (x1 != x2 || y1 != y2)
            {
                points.Add((x1, y1));
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }

            points.Add((x2, y2));
            return points;
        }
    }

}
