using UnityEngine;

namespace Features.UI.Scripts.Interfaces
{
    public interface IUIRoot
    {
        public Canvas Canvas { get; set; }
        public Camera Camera { get; }
        public Transform Container { get; }
    }
}