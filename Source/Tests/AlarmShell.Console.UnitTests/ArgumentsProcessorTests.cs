//srgjanx

namespace AlarmShell.Console.UnitTests
{
    [TestClass]
    public class ArgumentsProcessorTests
    {
        [TestMethod]
        public void ConstructorTest_Null_Args()
        {
            string[] args = null;
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            Assert.AreEqual(args, argumentsProcessor.Args);
        }

        [TestMethod]
        public void ConstructorTest_Empty_Args()
        {
            string[] args = new string[0];
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            Assert.AreEqual(args, argumentsProcessor.Args);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please specify a valid time span.")]
        public void GetAlarmInfo_Name_Without_TimeSpans()
        {
            string[] args = new string[]
            {
                "Test Alarm"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
        }

        [TestMethod]
        public void GetAlarmInfo_Without_Name_TimeSpans()
        {
            string[] args = new string[]
            {
                "20m"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Unnamed Alarm", alarmInfo.Name);
            Assert.AreEqual(20 * 60, alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Valid_Name_And_Hours()
        {
            string[] args = new string[]
            {
                "Test Alarm", "1h"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual(1*60*60, alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Valid_Name_And_Minutes()
        {
            string[] args = new string[]
            {
                "Test Alarm", "20m"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual(20 * 60, alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Valid_Name_And_Seconds()
        {
            string[] args = new string[]
            {
                "Test Alarm", "50s"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual(50, alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Combined1()
        {
            string[] args = new string[]
            {
                "Test Alarm", "1h", "20m"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual((1 * 60 * 60) + (20 * 60), alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Combined2()
        {
            string[] args = new string[]
            {
                "Test Alarm", "1h", "20m"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual((1 * 60 * 60) + (20 * 60), alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Combined3()
        {
            string[] args = new string[]
            {
                "Test Alarm", "1h", "30m", "0s"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual((1 * 60 * 60) + (30 * 60), alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Combined4s()
        {
            string[] args = new string[]
            {
                "Test Alarm", "1h", "30m", "45s"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
            Assert.AreEqual((1 * 60 * 60) + (30 * 60) + 45, alarmInfo.TimeSpan.TotalSeconds);
        }

        [TestMethod]
        public void GetAlarmInfo_Combined_Without_Name()
        {
            string[] args = new string[]
            {
                "1h", "30m", "45s"
            };
            ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(args);
            AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
            Assert.AreEqual("Unnamed Alarm", alarmInfo.Name);
            Assert.AreEqual((1 * 60 * 60) + (30 * 60) + 45, alarmInfo.TimeSpan.TotalSeconds);
        }
    }
}