using Godot;
using System.Runtime.CompilerServices;
using System;

public partial class Logger : Node
{
    public enum Severity{
        DEBUG = -1,
        INFO = 0,
        WARN = 1,
        ERROR = 2,
    }

#if DEBUG
    public Severity LOG_SEVERITY = Severity.DEBUG; 
#else
    public Severity LOG_SEVERITY = Severity.WARN;
#endif

    public readonly Severity DEBUG = Severity.DEBUG;
    public readonly Severity INFO = Severity.INFO;
    public readonly Severity WARN = Severity.WARN;
    public readonly Severity ERROR = Severity.ERROR;

    public void log (Variant _m, Severity _s = Severity.DEBUG,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string callingFilePath = ""){
        string fileName = callingFilePath.GetFile();
        DateTime localDate = DateTime.Now;
        string message = $"[{localDate}][{fileName} : {caller} : {lineNumber}] [{_s}] {_m}";
        switch(_s){
            case Severity.WARN:
                if(LOG_SEVERITY > Severity.WARN)
                    break;
                GD.PushWarning(message);
                GD.PrintRich($"[color=orange]{message}[/color]");
                break;
            case Severity.ERROR:
                GD.PushError(message);
                GD.PrintErr(message);
                break;
            case Severity.INFO:
                if(LOG_SEVERITY > Severity.INFO)
                    break;
                GD.Print(message);
                break;
            default:
                if(LOG_SEVERITY != Severity.DEBUG)
                    break;
                GD.PrintRich($"[code]{message}[/code]");
                break;
        }
    }

    public void dbg(Variant _m,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string callingFilePath = ""){
        log(_m, Severity.DEBUG, lineNumber, caller, callingFilePath);
    }

    public void info(Variant _m,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string callingFilePath = ""){
        log(_m, Severity.INFO, lineNumber, caller, callingFilePath);
    }

    public void warn(Variant _m,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string callingFilePath = ""){
        log(_m, Severity.WARN, lineNumber, caller, callingFilePath);
    }

    public void error(Variant _m,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string caller = "",
        [CallerFilePath] string callingFilePath = ""){
        log(_m, Severity.ERROR, lineNumber, caller, callingFilePath);
    }

}
