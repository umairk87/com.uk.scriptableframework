using UnityEngine;

namespace Scriptable.Framework
{
    public abstract class BaseScriptableAsset : ScriptableObject
    {
        [SerializeField]
        private string assetID;

        public string AssetID => assetID;

        protected virtual void OnEnable()
        {
            if (string.IsNullOrEmpty(assetID))
            {
                assetID = this.name;// System.Guid.NewGuid().ToString();
            }
        }
    }
}