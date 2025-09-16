using System.IO;
using VRage.Utils;

namespace avaness.PluginLoader
{
    public static class LogFile
    {
        private const string fileName = "loader.log";
        private static FileStream logger;

        public static void Init(string mainPath)
        {
            string file = Path.Combine(mainPath, fileName);
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
            logger = File.Open(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);            
        }

        public static void Error(string text, bool gameLog = true)
        {
            WriteLine(text, MyLogSeverity.Error, gameLog);
        }

        public static void Warn(string text, bool gameLog = true)
        {
            WriteLine(text, MyLogSeverity.Warning, gameLog);
        }

        public static void WriteLine(string text, MyLogSeverity level = MyLogSeverity.Info, bool gameLog = true)
        {
            try
            {
                var logText = $"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {text}\r\n";
                logger?.Write(System.Text.Encoding.UTF8.GetBytes(logText), 0, logText.Length);
                logger.Flush();
                if (gameLog)
                    MyLog.Default?.Log(level, $"[PluginLoader] {text}");
            }
            catch 
            {
                Dispose();
            }
        }


        public static void Dispose()
        {
            if (logger == null)
                return;

            try
            {
                logger.Flush();
                logger.Dispose();
            }
            catch { }
            logger = null;
        }
    }
}