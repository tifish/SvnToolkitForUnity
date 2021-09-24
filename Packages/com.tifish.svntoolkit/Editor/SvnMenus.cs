using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SvnToolkit
{
    static class SvnMenus
    {
        static readonly string ProjectPath = Path.GetDirectoryName(Application.dataPath);

        [MenuItem("Assets/SVN Commit...")]
        static void CommitMenu()
        {
            TortoiseSvn.Commit(GetSelectedFiles().ToArray(), ProjectPath);
        }

        [MenuItem("Assets/SVN/Update")]
        static void UpdateMenu()
        {
            TortoiseSvn.Update(GetSelectedFiles().ToArray(), ProjectPath);
        }

        [MenuItem("Assets/SVN/Add...")]
        static void AddMenu()
        {
            TortoiseSvn.Commit(GetSelectedFiles().ToArray(), ProjectPath);
        }

        [MenuItem("Assets/SVN/Delete")]
        static void RemoveMenu()
        {
            TortoiseSvn.Commit(GetSelectedFiles().ToArray(), ProjectPath);
        }

        [MenuItem("Assets/SVN/Revert...")]
        static void RevertMenu()
        {
            TortoiseSvn.Commit(GetSelectedFiles().ToArray(), ProjectPath);
        }

        [MenuItem("Assets/SVN/Show log")]
        static void ShowLogMenu()
        {
            TortoiseSvn.ShowLog(GetSelectedFile(), ProjectPath);
        }

        static string GetSelectedFile()
        {
            var activeObj = Selection.GetFiltered<Object>(SelectionMode.Assets).FirstOrDefault();
            return activeObj ? AssetDatabase.GetAssetPath(activeObj) : string.Empty;
        }

        static List<string> GetSelectedFiles()
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
