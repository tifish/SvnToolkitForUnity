using System;
using System.Diagnostics;

namespace SvnToolkit
{
    public static class TortoiseSvn
    {
        static void ExecuteTortoiseProc(string arguments, string workingDirectory = null)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                Process.Start("TortoiseProc.exe", arguments);
                return;
            }

            var oldDir = Environment.CurrentDirectory;
            try
            {
                Environment.CurrentDirectory = workingDirectory;
                Process.Start("TortoiseProc.exe", arguments);
            }
            finally
            {
                Environment.CurrentDirectory = oldDir;
            }
        }

        public static void Commit(string[] paths, string workingDirectory = null)
        {
            ExecuteTortoiseProc($"/command:commit /path:\"{string.Join("*", paths)}\"", workingDirectory);
        }

        public static void Update(string[] paths, string workingDirectory = null)
        {
            ExecuteTortoiseProc($"/command:update /path:\"{string.Join("*", paths)}\"", workingDirectory);
        }

        public static void Add(string[] paths, string workingDirectory = null)
        {
            ExecuteTortoiseProc($"/command:add /path:\"{string.Join("*", paths)}\"", workingDirectory);
        }

        public static void Remove(string[] paths, string workingDirectory = null)
        {
            ExecuteTortoiseProc($"/command:remove /path:\"{string.Join("*", paths)}\"", workingDirectory);
        }

        public static void Revert(string[] paths, string workingDirectory = null)
        {
            ExecuteTortoiseProc($"/command:revert /path:\"{string.Join("*", paths)}\"", workingDirectory);
        }

        public static void ShowLog(string path, string workingDirectory)
        {
            ExecuteTortoiseProc($"/command:log /path:\"{path}\"", workingDirectory);
        }
    }
}
