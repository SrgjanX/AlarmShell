//srgjanx

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlarmShell
{
    public class ArgumentsProcessor
    {
        private string Regex_h = "^([0-9]){1,2}h$";
        private string Regex_m = "^([0-9]){1,2}m$";
        private string Regex_s = "^([0-9]){1,2}s$";
        private string Regex_time = "^([0-9]){1,2}:([0-9]){1,2}$";

        public string[] Args { get; private set; }

        public ArgumentsProcessor(string[] args)
        {
            Args = args;
        }

        public AlarmInfo GetAlarmInfo()
        {
            string? name = null;
            int h = 0, m = 0, s = 0;
            Type type = Type.Timer;
            if (Args?.Any() == true)
            {
                foreach (string arg in Args)
                {
                    if (Regex.IsMatch(arg, Regex_h, RegexOptions.IgnoreCase))
                    {
                        h = Convert.ToInt32(arg.Remove(arg.Length - 1, 1));
                    }
                    else if (Regex.IsMatch(arg, Regex_m, RegexOptions.IgnoreCase))
                    {
                        m = Convert.ToInt32(arg.Remove(arg.Length - 1, 1));
                    }
                    else if (Regex.IsMatch(arg, Regex_s, RegexOptions.IgnoreCase))
                    {
                        s = Convert.ToInt32(arg.Remove(arg.Length - 1, 1));
                    }
                    else if (Regex.IsMatch(arg, Regex_time, RegexOptions.IgnoreCase))
                    {
                        type = Type.Alarm;
                        h = Convert.ToInt32(arg.Split(':')[0]);
                        m = Convert.ToInt32(arg.Split(':')[1]);
                    }
                    else
                    {
                        name = arg;
                    }
                }
            }
            return new AlarmInfo(name, new TimeSpan(h, m, s), type);
        }
    }
}