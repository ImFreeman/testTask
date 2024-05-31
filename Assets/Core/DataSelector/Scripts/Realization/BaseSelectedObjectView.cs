using Core.DataSelector.Scripts.Interfaces;
using UnityEngine;

namespace Core.DataSelector.Scripts.Realization
{
    public abstract class BaseSelectedObjectView<T> : MonoBehaviour, ISelectedObjectView<T> where T : ISelectableData
    {
        public abstract void UpdateView(T data);
    }
}