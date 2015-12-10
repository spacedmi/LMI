using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    public interface IField
    {
        void Draw(Graphics graphics);
        bool isFixPoint(float currentLocationX, float currentLocationY);
        void ProcessMousePosition(float currentLocationX, float currentLocationY);
    }
}
