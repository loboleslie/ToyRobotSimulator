using NUnit.Framework;
using ToyRobotSimulator;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Tests
{
    [TestFixture]
    public class Tests
    {

        private RobotCommand _helper;
        private TableTop _tabletop;
        private Robot _robot;

        [SetUp]
        public void Setup()
        { 
             _tabletop = new TableTop(5,5);
             _robot = new Robot(0, 0, "");
            _helper = new RobotCommand(_robot,_tabletop);
           
           
        }

        [Test]
        public void ValidPlaceRobot_X3Y4_SuccessfullyPlaced()
        {
            _robot = _helper.ProcessCommand("PLACE 3,4,NORTH");

            Assert.AreEqual(3, _robot.X);
            Assert.AreEqual(4, _robot.Y);
            Assert.AreEqual("NORTH", _robot.Facing);
        }

        [Test]
        public void InValidPlaceRobot_X6Y6_FailedToPlace()
        {                  
            _robot = _helper.ProcessCommand("PLACE 6,6,NORTH");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("", _robot.Facing);
        }

        [Test]
        public void ValidMoveRobot_North_YIsIncrementedBy1()
        {                     
            _robot = _helper.ProcessCommand("PLACE 0,0,NORTH");

            _robot = _helper.ProcessCommand("MOVE");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(1, _robot.Y);
            Assert.AreEqual("NORTH", _robot.Facing);
        }

        
        [Test]
        public void InValidMoveRobot_North_NoChange()
        {           
            _robot = _helper.ProcessCommand("PLACE 0,5,NORTH");
            _robot = _helper.ProcessCommand("MOVE");
            
            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(5, _robot.Y);
            Assert.AreEqual("NORTH", _robot.Facing);
        }
        
        [Test]
        public void ValidMoveRobot_South_YIsDecreasedBy1()
        {                      
            _robot = _helper.ProcessCommand("PLACE 3,4,SOUTH");
            _robot = _helper.ProcessCommand("MOVE");
            
            Assert.AreEqual(3, _robot.X);
            Assert.AreEqual(3, _robot.Y);
            Assert.AreEqual("SOUTH", _robot.Facing);
        }
        
        [Test]
        public void InValidMoveRobot_South_NoChange()
        {           
            _robot = _helper.ProcessCommand("PLACE 3,0,SOUTH");
            _robot = _helper.ProcessCommand("MOVE");
           
            Assert.AreEqual(3, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("SOUTH", _robot.Facing);
        }
        
        [Test]
        public void ValidMoveRobot_West_XIsDecreasedBy1()
        {                        
            _robot = _helper.ProcessCommand("PLACE 3,4,WEST");
            _robot = _helper.ProcessCommand("MOVE");
           
            Assert.AreEqual(2, _robot.X);
            Assert.AreEqual(4, _robot.Y);
            Assert.AreEqual("WEST", _robot.Facing);
        }
        
        [Test]
        public void InValidMoveRobot_West_NoChange()
        {           
            _robot = _helper.ProcessCommand("PLACE 0,4,WEST");
            _robot = _helper.ProcessCommand("MOVE");
            
            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(4, _robot.Y);
            Assert.AreEqual("WEST", _robot.Facing);
        }
        
        [Test]
        public void ValidMoveRobot_East_XIsIncreasedBy1()
        {                      
            _robot = _helper.ProcessCommand("PLACE 3,4,EAST");
            _robot = _helper.ProcessCommand("MOVE");

            Assert.AreEqual(4, _robot.X);
            Assert.AreEqual(4, _robot.Y);
            Assert.AreEqual("EAST", _robot.Facing);

        }

        [Test]
        public void InValidMoveRobot_East_NoChange()
        {            
            Robot _expectedreport = new Robot(5, 4, "EAST");

            _robot = _helper.ProcessCommand("PLACE 5,4,EAST");
            _robot = _helper.ProcessCommand("MOVE");

            Assert.AreEqual(5, _robot.X);
            Assert.AreEqual(4, _robot.Y);
            Assert.AreEqual("EAST", _robot.Facing);

        }

        [Test]
        public void MoveRobotLeft_FacingNorth_FacingWest()
        {          
            _robot = _helper.ProcessCommand("PLACE 0,0,NORTH");
            _robot = _helper.ProcessCommand("LEFT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("WEST", _robot.Facing);

        }

        [Test]
        public void MoveRobotLeft_FacingSouth_FacingEast()
        {            
            _robot = _helper.ProcessCommand("PLACE 0,0,SOUTH");
            _robot = _helper.ProcessCommand("LEFT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("EAST", _robot.Facing);

        }

        [Test]
        public void MoveRobotLeft_FacingWest_FacingSouth()
        {           
            _robot = _helper.ProcessCommand("PLACE 0,0,WEST");
            _robot = _helper.ProcessCommand("LEFT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("SOUTH", _robot.Facing);

        }

        [Test]
        public void MoveRobotLeft_FacingEast_FacingNorth()
        {            
            _robot = _helper.ProcessCommand("PLACE 0,0,EAST");
            _robot = _helper.ProcessCommand("LEFT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("NORTH", _robot.Facing);

        }

        [Test]
        public void MoveRobotRight_FacingNorth_FacingEast()
        {           
            _robot = _helper.ProcessCommand("PLACE 0,0,NORTH");
            _robot = _helper.ProcessCommand("RIGHT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("EAST", _robot.Facing);

        }

        [Test]
        public void MoveRobotRight_FacingSouth_FacingWest()
        {            
            _robot = _helper.ProcessCommand("PLACE 0,0,SOUTH");
            _robot = _helper.ProcessCommand("RIGHT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("WEST", _robot.Facing);

        }

        [Test]
        public void MoveRobotRight_FacingWest_FacingNorth()
        {            
            _robot = _helper.ProcessCommand("PLACE 0,0,WEST");
            _robot = _helper.ProcessCommand("RIGHT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("NORTH", _robot.Facing);

        }

        [Test]
        public void MoveRobotRight_FacingEast_FacingSouth()
        {            
            _robot = _helper.ProcessCommand("PLACE 0,0,EAST");
            _robot = _helper.ProcessCommand("RIGHT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("SOUTH", _robot.Facing);
        }

        [Test]
        public void ValidMoveRobot_East_Output()
        {
            _robot = _helper.ProcessCommand("PLACE 3,4,EAST");
            _robot = _helper.ProcessCommand("MOVE");

            string output = _helper.RobotResult();

            Assert.AreEqual("Output: 4,4,EAST", output);            
        }

        [Test]
        public void InValidMoveRobot_MoveCommandBeforePlaceCommand_NoChange()
        {
            _robot = _helper.ProcessCommand("MOVE");
            _robot = _helper.ProcessCommand("MOVE");
            _robot = _helper.ProcessCommand("RIGHT");
            _robot = _helper.ProcessCommand("LEFT");

            Assert.AreEqual(0, _robot.X);
            Assert.AreEqual(0, _robot.Y);
            Assert.AreEqual("", _robot.Facing);
        }

    }
}
