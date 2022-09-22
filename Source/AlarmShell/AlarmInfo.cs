//srgjanx

using System;

namespace AlarmShell
{
    public class AlarmInfo
    {
        public string Name { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public Type Type { get; set; }

        public AlarmInfo(string? name, TimeSpan timeSpan, Type type)
        {
            Name = !string.IsNullOrEmpty(name) ? name : "Unnamed Alarm";
            if (timeSpan.TotalSeconds <= 0)
                throw new Exception("Please specify a valid time span.");
            TimeSpan = timeSpan;
            Type = type;
        }
    }
}