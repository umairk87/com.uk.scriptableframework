using UnityEngine;
using System.Collections.Generic;

namespace Scriptable.Framework
{
    [CreateAssetMenu(menuName = "Scriptable Architecture/Registry")]
    public class ScriptableRegistry : ScriptableObject
    {
        public List<BaseScriptableAsset> assets = new();
    }

}