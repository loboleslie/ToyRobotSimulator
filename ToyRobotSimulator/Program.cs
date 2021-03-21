using System;
using ToyRobotSimulator.Models;


namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Console.WriteLine("========================================================");
            Console.WriteLine("               TOY ROBOT SIMULATOR                      ");
            Console.WriteLine("========================================================");
            Console.WriteLine("");
            Console.WriteLine("DESCRIPTION");
            Console.WriteLine("");
            Console.WriteLine("- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.");
            Console.WriteLine("- There are no other obstructions on the table surface.");
            Console.WriteLine("- The robot is free to roam around the surface of the table");
            Console.WriteLine("");
            Console.WriteLine("VALID COMMAND");
            Console.WriteLine("");
            Console.WriteLine("- PLACE X,Y,F (Place the Robot on the Table Top)");
            Console.WriteLine("- MOVE (Move the Robot 1 Unit in the Direction the Robot is facing)");
            Console.WriteLine("- LEFT (Turn the Robot Left)");
            Console.WriteLine("- RIGHT (Turn the Robot Right)");
            Console.WriteLine("- REPORT (Show the Robot Status)");


            TableTop tabletop = new TableTop(5, 5);
            Robot robot = new Robot(0, 0, "");

            RobotCommand robotCommand = new RobotCommand(robot, tabletop);
                       
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please Enter Your Command");
                command = Console.ReadLine().ToUpper();

                if(command == "REPORT")
                {
                    Console.WriteLine(robotCommand.RobotResult());
                }
                else
                {
                    robot = robotCommand.ProcessCommand(command);
                }
               

            } while (command != "EXIT");
        }
    }
}
