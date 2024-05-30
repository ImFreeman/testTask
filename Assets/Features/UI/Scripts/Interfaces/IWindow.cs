using System;
using UnityEngine;

namespace Features.UI.Scripts.Interfaces
{
    public interface IWindow
    {
        public event EventHandler ShowEvent;
        public event EventHandler HideEvent;

        public void Show();
        public void Hide();

        public void SetNewParent(RectTransform parent);
    }
}
