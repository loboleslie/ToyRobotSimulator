using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{   
    interface IRobotCommand
    {
        public Robot ProcessCommand(string Command);
        public void ProcessPlace(string Command);
        public void ProcessMove();
        public void ProcessLeft();
        public void ProcessRight();        
        public string RobotResult();
    }
}
