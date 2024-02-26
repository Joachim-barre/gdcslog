# GdCSharpLog

A Logger for Godot C# projects

## Features

* Colored output using print_rich
* prompt containing date,time,file,function and line
* multiple log level
* disable debug and info message on release

## How to use

the project uses a static class so that you only need to use the global ```Log``` object.<br>
the ```Log``` object as different log levels to send a message you have to use the appropriate one<br>
for exemple:
```
Log.dbg("debug message");
Log.info("info message");
Log.warn("warning message");
Log.error("error message");
```
