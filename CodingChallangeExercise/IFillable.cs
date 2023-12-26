using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallangeExercise
{
    public interface IFillable
    {
        void Fill(int x, int y, char color, char[,] matrix);
    }
}
