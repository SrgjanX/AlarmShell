<p align="center">
  <img width="64" align="center" src="https://icons.iconarchive.com/icons/umut-pulat/tulliana-2/128/k-alarm-icon.png">
</p>
<h1 align="center">
  AlarmShell
</h1>
<p align="center">
  Quickest alarm set ever :) (for Windows)
</p>

## Introduction
The point of this application is to set alarm by using the command prompt or if you are like me and love the Windows Run app, <br/>
setting up quick alarm can but as fast as CTRL+R and typing <b>alarm "pizza time" 20m</b>.

## Why?
I fixed my own problem when I'm doing something and in meantime someone calls me and tell me to another thing, how I solved that problem?<br/>
CTRL+R notepad and type the thing and 70% of the time I'll forgot because I'm in the middle of working on something.

## Features
- Quick alarm set by typing one command.
- Snooze command

## Usage example
Write these commands in cmd or Windows Run:
- alarm test 1h
- alarm test 1h 20m
- alarm 1h
- alarm 1h 20m 30s
- alarm "call someone" 30m

## How to install
- Copy the batch script <b>alarm.bat</b> to <b>%windir%\system32</b>.
- Copy the output folder to <b>C:\ProgramData\AlarmShell</b>.

## Virus notification
My anti virus sure was popping up while I was developing this, <br/>
but I assure you there is no malicious code in here afterall its open source, take a look at it :].<br/>
Note that you will probably need to whitelist your <b>C:\ProgramData\AlarmShell</b> directory for your anti virus.

## How to contribute
If you want to contribute to this project, you are welcome!
To do so, you need to follow the following simple steps:
- Fork the project.
- Create a brench with prefix either Feature_ or BugFix_ or whatever the issue it is.
- Do the changes.
- Make a pull request.