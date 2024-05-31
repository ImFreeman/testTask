using System;
using Features.UI.Scripts.Interfaces;
using UnityEngine;

namespace Features.UI.Scripts.Realization
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

        public void SetNewParent(RectTransform parent)
        {
            rectTransform.parent = parent;
            rectTransform.position = parent.position;
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            rectTransform.rotation = new Quaternion(0, 0, 0, 0);
        }

        protected abstract void OnShow();
        protected abstract void OnHide();
    }
}