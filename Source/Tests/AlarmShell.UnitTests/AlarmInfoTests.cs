//srgjanx

namespace AlarmShell.UnitTests
{
    [TestClass]
    public class AlarmInfoTests
    {
        [TestMethod]
        public void TestNullName()
        {
            AlarmInfo alarmInfo = new AlarmInfo(null, new TimeSpan(1, 0, 0), Type.Timer);
            Assert.AreEqual("Unnamed Alarm", alarmInfo.Name);
        }

        [TestMethod]
        public void TestSpecifiedName()
        {
            AlarmInfo alarmInfo = new AlarmInfo("Test Alarm", new TimeSpan(1, 0, 0), Type.Timer);
            Assert.AreEqual("Test Alarm", alarmInfo.Name);
        }

        [TestMethod]
        public void TestValidTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan(1, 30, 0);
            AlarmInfo alarmInfo = new AlarmInfo(null, timeSpan, Type.Timer);
            Assert.AreEqual(timeSpan, alarmInfo.TimeSpan);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please specify a valid time span.")]
        public void TestInvalidTimeSpan1()
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 0);
            new AlarmInfo(null, timeSpan, Type.Timer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Please specify a valid time span.")]
        public void TestInvalidTimeSpan2()
        {
            TimeSpan timeSpan = new TimeSpan(-1, 30, 0);
            new AlarmInfo(null, timeSpan, Type.Timer);
        }
    }
}