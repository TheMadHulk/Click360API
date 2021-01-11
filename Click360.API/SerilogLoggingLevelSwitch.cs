using Serilog.Core;
using Serilog.Events;

namespace Click360.API
{
    public class SerilogLoggingLevelSwitch
    {
        public static LoggingLevelSwitch LevelSwitch = new LoggingLevelSwitch();

        /// <summary>
        /// Set the Serilog logging level switch
        /// Defaults to Information
        /// </summary>
        /// <param name="eventLevel">Logging level</param>
        public static void SetLoggingLevel(int eventLevel)
        {
            switch (eventLevel)
            {
                case 1:
                    LevelSwitch.MinimumLevel = LogEventLevel.Debug;
                    break;

                case 2:
                    LevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;

                case 3:
                    LevelSwitch.MinimumLevel = LogEventLevel.Warning;
                    break;

                case 4:
                    LevelSwitch.MinimumLevel = LogEventLevel.Error;
                    break;

                default:
                    LevelSwitch.MinimumLevel = LogEventLevel.Information;
                    break;
            }
        }
    }
}
