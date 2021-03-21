using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator
{
    public class RobotCommand : IRobotCommand
    {
        Robot robot;
        TableTop tabletop;

        public RobotCommand(Robot _robot, TableTop _tabletop)
        {
            robot = _robot;
            tabletop = _tabletop;

        }

        //Processing all commands
        public Robot ProcessCommand(string command)
        {
            if (command.StartsWith("PLACE"))
            {
                //Process PLACE command
                ProcessPlace(command);
            }
            else if(command == "MOVE") 
            {
                //Processing Move command
                ProcessMove();
            }
            else if(command == "LEFT")
            {
                //Processing Left command
                ProcessLeft();
            }
            else if(command == "RIGHT")
            {
                //Processing Right command
                ProcessRight();
            }
            
            return robot;            
        }

        //Function to process the LEFT command
        public void ProcessLeft()
        {
            if (robot.Facing != "")
            {
                string facing = robot.Facing;

                if (facing == "NORTH")
                {  
                    //Left of North is West
                    robot.Facing = "WEST";
                }
                else if (facing == "SOUTH")
                {
                    //Left of South is East
                    robot.Facing = "EAST";
                }
                else if (facing == "WEST")
                {
                    //Left of West is South
                    robot.Facing = "SOUTH";
                }
                else if (facing == "EAST")
                {
                    //Left of East is North
                    robot.Facing = "NORTH";
                }
            }
        }

        //Function to process the MOVE command
        public void ProcessMove()
        {
            //Making sure the PLACE command run
            if(robot.Facing != "")
            {
                string facing = robot.Facing;

                if (facing == "NORTH")
                {
                    //Check if the Robot does not Fall of the table
                    if ((robot.Y + 1) <= tabletop.Heigth)
                    {
                        //Moving up the Y Axis
                        robot.Y += 1;
                    }

                }
                else if (facing == "SOUTH")
                {
                    //Check if the Robot does not Fall of the table
                    if ((robot.Y - 1) >= 0)
                    {
                        //Moving down the Y Axis
                        robot.Y -= 1;
                    }

                }
                else if (facing == "WEST")
                {
                    //Check if the Robot does not Fall of the table
                    if ((robot.X - 1) >= 0)
                    {
                        //Moving down the X Axis
                        robot.X -= 1;
                    }

                }
                else if (facing == "EAST")
                {
                    //Check if the Robot does not Fall of the table
                    if ((robot.X + 1) <= tabletop.Width)
                    {
                        //Moving up the X Axis
                        robot.X += 1;
                    }

                }

            }
            
        }

        //Function to process the PLACE command
        public void ProcessPlace(string command)
        {
            String[] CommandArray = command.Replace("PLACE ", "").Split(",");

            int X = Convert.ToInt32(CommandArray[0]);

            int Y = Convert.ToInt32(CommandArray[1]);

            string Facing = CommandArray[2];

            //Making sure the X and Y values are valid
            if ((X <= tabletop.Width && X >= 0) && (Y <= tabletop.Heigth && Y >= 0))
            {
                //Setting the Robot values
                robot.X = X;
                robot.Y = Y;
                robot.Facing = Facing;
            }
        }

        //Function to process the RIGHT command
        public void ProcessRight()
        {
            //Making sure the PLACE command run
            if (robot.Facing != "")
            {
                string facing = robot.Facing;

                if (facing == "NORTH")
                {
                    //Right of North is East
                    robot.Facing = "EAST";

                }
                else if (facing == "SOUTH")
                {
                    //Right of South is West
                    robot.Facing = "WEST";

                }
                else if (facing == "WEST")
                {
                    //Right of West is North
                    robot.Facing = "NORTH";

                }
                else if (facing == "EAST")
                {
                    //Right of East is South
                    robot.Facing = "SOUTH";

                }
            }
        }

        //Function to process the REPORT command
        public string RobotResult()
        {            
            string result = "Output: " + robot.X + "," + robot.Y + "," + robot.Facing;
            return result;
        }
        
    }
    
}
