using UnityEngine;
using System.Collections.Generic;

namespace Scriptable.Framework
{


    public class ScriptableUsageManager : MonoBehaviour
    {
        public static ScriptableUsageManager Instance;

        [SerializeField]
        private ScriptableRegistry registry;

        private Dictionary<string, BaseScriptableAsset>
            assetLookup = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Initialize()
        {
            assetLookup.Clear();

            foreach (var asset in registry.assets)
            {
                if (asset == null)
                    continue;

                assetLookup[asset.AssetID] = asset;
            }

            Debug.Log(
                $"Registered {assetLookup.Count} scriptable assets."
            );
        }

        // ---------------- GET BY ID ----------------

        public T Get<T>(string id)
            where T : BaseScriptableAsset
        {
            if (assetLookup.TryGetValue(id, out var asset))
            {
                return asset as T;
            }

            return null;
        }

        // ---------------- GET ALL ----------------

        public List<T> GetAll<T>()
            where T : BaseScriptableAsset
        {
            List<T> result = new();

            foreach (var pair in assetLookup)
            {
                if (pair.Value is T asset)
                {
                    result.Add(asset);
                }
            }

            return result;
        }
    }
}