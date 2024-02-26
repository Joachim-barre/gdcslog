#if TOOLS
using Godot;
using System;

[Tool]
public partial class gdlog : EditorPlugin
{
	public override void _EnterTree()
	{
		// Initialization of the plugin goes here.
            AddAutoloadSingleton("Log", "res://addons/gdlog/Logger.cs");
	}

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
            RemoveAutoloadSingleton("Log");
	}
}
#endif
