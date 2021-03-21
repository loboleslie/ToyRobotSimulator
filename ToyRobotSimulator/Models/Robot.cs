using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{
    public class Robot
    {
        //X axis on the Table
        public int X { get; set; }

        //Y axis on the Table
        public int Y { get; set; }

        //Direction the Robot is facing
        public string Facing { get; set; }

        //Constructor
        public Robot( int x, int y, string _facing)
        {
            X = x;
            Y = y;
            Facing = _facing;
        }
    }
}
