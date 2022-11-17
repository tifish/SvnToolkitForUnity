using SvnToolkit;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(TestSvn))]
    public class TestSvnEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Get current revision"))
            {
                Debug.Log(Svn.GetCurrentRevisionSync("."));
            }
        }
    }
}
