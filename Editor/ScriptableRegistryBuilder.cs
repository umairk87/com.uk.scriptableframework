using UnityEditor;
using UnityEngine;

namespace Scriptable.Framework
{

    public static class ScriptableRegistryBuilder
    {
        [MenuItem("Tools/Rebuild Scriptable Registry")]
        public static void Rebuild()
        {
            ScriptableRegistry registry =
                Resources.Load<ScriptableRegistry>(
                    "ScriptableRegistry"
                );

            if (registry == null)
            {
                Debug.LogError("Registry not found.");
                return;
            }

            registry.assets.Clear();

            string[] guids =
                AssetDatabase.FindAssets(
                    "t:BaseScriptableAsset"
                );

            foreach (string guid in guids)
            {
                string path =
                    AssetDatabase.GUIDToAssetPath(guid);

                BaseScriptableAsset asset =
                    AssetDatabase.LoadAssetAtPath<BaseScriptableAsset>(
                        path
                    );

                if (asset != null)
                {
                    registry.assets.Add(asset);
                }
            }

            EditorUtility.SetDirty(registry);

            AssetDatabase.SaveAssets();

            Debug.Log(
                $"Registry rebuilt with {registry.assets.Count} assets."
            );
        }
    }
}