using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SvnToolkit
{
    public static class TortoiseSvn
    {
        private static async Task<bool> ExecuteTortoiseProc(string arguments, string workingDirectory = "")
        {
            var oldDir = Environment.CurrentDirectory;
            try
            {
                if (workingDirectory != "")
                    Environment.CurrentDirectory = workingDirectory;
                var process = Process.Start(new ProcessStartInfo("TortoiseProc.exe", arguments) { UseShellExecute = true });
                if (process == null)
                    return false;
                await process.WaitForExitAsync();
                return process.ExitCode == 0;
            }
            finally
            {
                Environment.CurrentDirectory = oldDir;
            }
        }

        public static async Task<bool> Commit(string[] paths, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:commit /path:\"{string.Join("*", paths)}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Update(string[] paths, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:update /path:\"{string.Join("*", paths)}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Add(string[] paths, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:add /path:\"{string.Join("*", paths)}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Remove(string[] paths, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:remove /path:\"{string.Join("*", paths)}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Revert(string[] paths, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:revert /path:\"{string.Join("*", paths)}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> ShowLog(string path, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:log /path:\"{path}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Cleanup(string path, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:cleanup /path:\"{path}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Checkout(string url, string path, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:checkout /url:{url} /path:\"{path}\" {arguments}", workingDirectory);
        }

        public static async Task<bool> Resolve(string path, string arguments = "", string workingDirectory = "")
        {
            return await ExecuteTortoiseProc($"/command:resolve /path:\"{path}\" {arguments}", workingDirectory);
        }
    }
}
