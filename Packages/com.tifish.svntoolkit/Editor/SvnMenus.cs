using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SvnToolkit
{
    static class SvnMenus
    {
        private static readonly string ProjectPath = Path.GetDirectoryName(Application.dataPath);

        [MenuItem("Assets/SVN Commit...", false, 222)]
        private static void CommitMenu()
        {
            TortoiseSvn.Commit(GetSelectedFiles().ToArray(), "", ProjectPath).ConfigureAwait(false);
        }

        [MenuItem("Assets/SVN/Update", false, 222)]
        private static void UpdateMenu()
        {
            TortoiseSvn.Update(GetSelectedFiles().ToArray(), "", ProjectPath).ConfigureAwait(false);
        }

        [MenuItem("Assets/SVN/Add...", false, 222)]
        private static void AddMenu()
        {
            TortoiseSvn.Add(GetSelectedFiles().ToArray(), "", ProjectPath).ConfigureAwait(false);
        }

        [MenuItem("Assets/SVN/Delete", false, 222)]
        private static void RemoveMenu()
        {
            TortoiseSvn.Remove(GetSelectedFiles().ToArray(), "", ProjectPath).ConfigureAwait(false);
        }

        [MenuItem("Assets/SVN/Revert...", false, 222)]
        private static void RevertMenu()
        {
            TortoiseSvn.Revert(GetSelectedFiles().ToArray(), "", ProjectPath).ConfigureAwait(false);
        }

        [MenuItem("Assets/SVN/Show log", false, 222)]
        private static void ShowLogMenu()
        {
            TortoiseSvn.ShowLog(GetSelectedFile(), "", ProjectPath).ConfigureAwait(false);
        }

        private static string GetSelectedFile()
        {
            var activeObj = Selection.GetFiltered<Object>(SelectionMode.Assets).FirstOrDefault();
            return activeObj ? AssetDatabase.GetAssetPath(activeObj) : string.Empty;
        }

        private static List<string> GetSelectedFiles()
        {
            var paths = new List<string>();
            foreach (var assetPath in Selection.GetFiltered<Object>(SelectionMode.Assets).Select(AssetDatabase.GetAssetPath))
            {
                paths.Add(assetPath);
                paths.Add(assetPath + ".meta");
            }

            return paths;
        }
    }
}
