using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallangeExercise
{
    public class Canvas : IDrawable
    {
        public char[,] canvasArray;

        public Canvas(int width, int height)
        {
            canvasArray = new char[width, height];
        }

        public void Draw()
        {
            for (int i = 0; i < canvasArray.GetLength(1); i++)
            {
                for (int j = 0; j < canvasArray.GetLength(0); j++)
                {
                    Console.Write(canvasArray[j, i]);
                }
                Console.WriteLine();
            }
        }
        

         public void DrawShape(IShape shape)
        {
            shape.Draw(canvasArray);
        }

        public void SetPixel(int x, int y, char color)
        {
            canvasArray[x, y] = color;
        }
    }
}
