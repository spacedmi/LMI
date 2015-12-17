using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    public abstract class IField
    {
        public Field Name;
        public abstract void Draw(Graphics graphics);
        public abstract bool isFixPoint(float currentLocationX, float currentLocationY);
        public abstract void ProcessMousePosition(float currentLocationX, float currentLocationY);
    }
}
