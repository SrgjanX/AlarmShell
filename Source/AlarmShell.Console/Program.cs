//srgjanx

using AlarmShell;
using AlarmShell.Console;

try
{
	ArgumentsProcessor argumentsProcessor = new ArgumentsProcessor(Environment.GetCommandLineArgs());
	AlarmInfo alarmInfo = argumentsProcessor.GetAlarmInfo();
	//Call gui with alarm info arguments.
}
catch (Exception ex)
{
	Console.WriteLine($"Error: {ex.Message}");
}