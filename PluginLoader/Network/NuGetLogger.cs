using NuGet.Common;
using System.Threading.Tasks;
using VRage.Utils;

namespace avaness.PluginLoader.Network
{
    public class NuGetLogger : ILogger
    {
        public void Log(LogLevel level, string data)
        {
            LogFile.WriteLine($"[NuGet] {data}", ConvertLogLevel(level));
        }

        public void Log(ILogMessage message)
        {
            Log(message.Level, message.Message);
        }

        private MyLogSeverity ConvertLogLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return MyLogSeverity.Debug;
                case LogLevel.Verbose:
                    return MyLogSeverity.Debug;
                case LogLevel.Information:
                    return MyLogSeverity.Info;
                case LogLevel.Minimal:
                    return MyLogSeverity.Info;
                case LogLevel.Warning:
                    return MyLogSeverity.Warning;
                case LogLevel.Error:
                    return MyLogSeverity.Error;
            }

            return MyLogSeverity.Info;
        }

        public Task LogAsync(LogLevel level, string data)
        {
            Log(level, data);
            return Task.CompletedTask;
        }

        public Task LogAsync(ILogMessage message)
        {
            Log(message);
            return Task.CompletedTask;
        }

        public void LogDebug(string data)
        {
            Log(LogLevel.Debug, data);
        }

        public void LogError(string data)
        {
            Log(LogLevel.Error, data);
        }

        public void LogInformation(string data)
        {
            Log(LogLevel.Information, data);
        }

        public void LogInformationSummary(string data)
        {
            Log(LogLevel.Information, data);
        }

        public void LogMinimal(string data)
        {
            Log(LogLevel.Minimal, data);
        }

        public void LogVerbose(string data)
        {
            Log(LogLevel.Verbose, data);
        }

        public void LogWarning(string data)
        {
            Log(LogLevel.Warning, data);
        }
    }
}
