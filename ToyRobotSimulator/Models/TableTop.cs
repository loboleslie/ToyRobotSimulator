using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{
    public class TableTop
    {
        //Width in Units
        public int Width { get; set; }

        //Height in Units
        public int Heigth { get; set; }

        //Constructor
        public TableTop(int _width, int _height)
        {
            Width = _width;
            Heigth = _height;
        }
        
    }
}
