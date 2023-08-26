using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    [CreateAssetMenu(menuName ="Game/Configs/Spawn Text")]
    public class SpawnTextConfig : ScriptableObject
    {
        public SpawnedText TextPrefab;
    }
}
