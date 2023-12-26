using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallangeExercise
{
    public class CommandProcessor
    {
        private bool isCanvasCreated = false;
        private Canvas canvas;

        public CommandProcessor(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void ProcessCommand(string command)
        {
            string[] commandParts = command.Split(' ');

            if(commandParts[0].ToUpper() != "C" && !isCanvasCreated)
            {
                Console.WriteLine("Please create canvas first.");
                return;
            }

            try
            {
                switch (commandParts[0].ToUpper())
                {
                    case "C":
                        CreateCanvas(commandParts);
                        isCanvasCreated = true;
                        break;
                    case "R":
                        DrawRectangleCommand(commandParts);
                        break;
                    case "L":
                        DrawLine(commandParts);
                        break;
                    case "Q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(IndexOutOfRangeException))
                {
                    Console.WriteLine($"Please enter width <= {canvas.canvasArray.GetUpperBound(0)} " +
                        $"and height <= {canvas.canvasArray.GetUpperBound(1)}.");
                }
            }
        }
        private void CreateCanvas(string[] commandParts)
        {
            if (commandParts.Length == 3 && int.TryParse(commandParts[1], out int width) &&
                int.TryParse(commandParts[2], out int height))
            {
                canvas = new Canvas(width, height);
                canvas.Draw();
            }
            else
            {
                Console.WriteLine("Invalid command for creating canvas. Try again.");
            }
        }

        private void DrawLine(string[] commandParts)
        {
            if (commandParts.Length == 5 && int.TryParse(commandParts[1], out int x1) &&
                int.TryParse(commandParts[2], out int y1) && int.TryParse(commandParts[3], out int x2) &&
                int.TryParse(commandParts[4], out int y2))
            {
                // Assume drawing only horizontal or vertical lines for simplicity
                if (x1 == x2 || y1 == y2)
                {
                    for (int i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
                    {
                        for (int j = Math.Min(y1, y2); j <= Math.Max(y1, y2); j++)
                        {
                            canvas.SetPixel(i, j, 'X');
                        }
                    }

                    canvas.Draw();
                }
                else
                {
                    Console.WriteLine("Invalid line. Only horizontal or vertical lines are supported.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command for drawing line. Try again.");
            }
        }
        private void DrawRectangleCommand(string[] commandParts)
        {
            
            if (commandParts.Length == 5 &&
                int.TryParse(commandParts[1], out int x1) &&
                int.TryParse(commandParts[2], out int y1) &&
                int.TryParse(commandParts[3], out int x2) &&
                int.TryParse(commandParts[4], out int y2))
            {
                Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
                canvas.DrawShape(rectangle);
                //canvas.Draw();
            }
            else
            {
                Console.WriteLine("Invalid 'R' command format.");
            }
        }

    }
}
