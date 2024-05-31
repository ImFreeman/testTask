using Sample.Features.UI.Scripts.Interfaces;
using UnityEngine;

namespace Sample.Features.UI.Scripts.Realization
{
    public abstract class UIBaseWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private RectTransform rectTransform;
        
        public void Show()
        {
            OnShow();
        }

        public void Hide()
        {
            OnHide();
        }

        protected abstract void OnShow();
        protected abstract void OnHide();
    }
}