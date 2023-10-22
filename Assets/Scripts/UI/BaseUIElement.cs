using UnityEngine;

namespace Scripts.UI
{
    public abstract class BaseUIElement : MonoBehaviour, IUIElement
    {
        public abstract UIGroup UIGroup { get; }

        private void Awake()
        {
            UIManager.AddUIElement(UIGroup, this);
        }

        private void OnDestroy()
        {
            UIManager.RemoveUIElement(this);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public abstract void UpdateUIVisual();
    }
}