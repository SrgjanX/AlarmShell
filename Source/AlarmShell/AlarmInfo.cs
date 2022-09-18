namespace AlarmShell
{
    public class AlarmInfo
    {
        public string Name { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public AlarmInfo(string name, TimeSpan timeSpan)
        {
            Name = !string.IsNullOrEmpty(name) ? name : "Unnamed Alarm";
            if (timeSpan.TotalSeconds <= 0)
                throw new Exception("Please specify a valid time span.");
            TimeSpan = timeSpan;
        }
    }
}