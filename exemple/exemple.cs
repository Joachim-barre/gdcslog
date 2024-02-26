using Godot;
using System;

public partial class exemple : Control
{
    public void _On_Debug_Pressed(){
        Log.dbg("debug button"); 
    }

    public void _On_Info_Pressed(){
        Log.info("info button"); 
    }

    public void _On_Warn_Pressed(){
        Log.warn("warn button"); 
    }

    public void _On_Error_Pressed(){
        Log.error("error button"); 
    }
}
