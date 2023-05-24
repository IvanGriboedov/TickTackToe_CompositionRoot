using CodeBase.Data;
using UnityEngine;

namespace CodeBase
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ContentProvider _contentProvider;
        [SerializeField] private RectTransform _uiRoot;

        private Root _root;

        private void Start()
        {
            var rootCtx = new Root.Ctx
            {
                contentProvider = _contentProvider,
                uiRoot = _uiRoot,
            };

            _root = new Root(rootCtx);
        }

        private void OnDestroy()
        {
            _root.Dispose();
        }
    }
}
