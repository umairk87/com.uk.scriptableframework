using UnityEngine;

namespace Scriptable.Framework
{

    [CreateAssetMenu(menuName = "Game/Weapon")]
    public class WeaponData : BaseScriptableAsset
    {
        public string weaponName;

        public int damage;

        public float fireRate;
    }
}