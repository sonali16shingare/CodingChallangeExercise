using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallangeExercise
{
    class Program
    {
        static void Main()
        {
            Canvas canvas = null;
            CommandProcessor commandProcessor = new CommandProcessor(canvas);

            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                commandProcessor.ProcessCommand(command);
            }
        }
    }

}
