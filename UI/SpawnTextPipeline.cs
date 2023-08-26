using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.Events;
using UnityEngine;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    [CreateAssetMenu(menuName = "Game/Text pipeline")]
    public class SpawnTextPipeline : EventObject
    {
        private string _message;
        private string _prefix;
        private string _postfix;
        private Vector3 _position;
        private SpawnTextConfig _config;

        public string Message { get => _message; }
        public Vector3 Position { get => _position; }
        public string Prefix { get => _prefix; }
        public string Postfix { get => _postfix; }
        public SpawnTextConfig Config { get => _config;}

        public static SpawnTextPipeline Import()
        {
            return Resources.Load<SpawnTextPipeline>("SpawnText/SpawnTextPipeline");
        }

        public void SpawnText(SpawnTextConfig config, string message, string prefix, string postfix, Vector3 position)
        {
            _message = message;
            _prefix = prefix;
            _postfix = postfix;
            _position = position;
            _config = config;
            Invoke();
        }
    }
}
