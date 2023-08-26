using Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI.TextSpawn;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace Demos.SOArchApproach.CodeBase.ScriptableObjectsFramework.UI
{
    public class SpawnedText : MonoBehaviour
    {
        public TextMeshProUGUI msg;
        RectTransform msg_rect;
        public TextMeshProUGUI prefix;
        public TextMeshProUGUI postfix;
        public PlayableDirector AnimationDirector;

        TextSpawner _parent;
        [Range(1f, -0.01f)]
        public float Lifetime = 1f;

        int prefab_id;

        private void OnEnable()
        {
            Lifetime = 1;
        }

        public void Setup(SpawnTextPipeline Request, Camera WorkCamera, TextSpawner Parent)
        {
            if(msg_rect == null)
                msg_rect = msg.transform as RectTransform;
            _parent = Parent;
            gameObject.SetActive(true);
            msg.text = Request.Message;
            msg.ForceMeshUpdate(true);
            var bounds = msg.textBounds;
            msg_rect.sizeDelta = bounds.size;
            prefix.text = Request.Prefix;
            postfix.text = Request.Postfix;
            prefab_id = Request.Config.TextPrefab.gameObject.GetInstanceID();
            transform.position = WorkCamera.WorldToScreenPoint(Request.Position);
        }

        private void Update()
        {
            if(Lifetime <= 0)
                Free();
            var bounds = msg.textBounds;
            msg_rect.sizeDelta = bounds.size;
        }

        void Free()
        {
            gameObject.SetActive(false);
            _parent.OnFreeText(prefab_id, this);
        }
    }
}
