using System;
using Features.UI.Scripts.Realization;

namespace Features.UI.Scripts.Interfaces
{
    public interface IUIService : IDisposable
    {
        public void LoadWindows();
        public T Show<T>() where T : UIBaseWindow;
    
        public void Hide<T>() where T : UIBaseWindow;
    
        public bool Get<T>(out T window) where T : UIBaseWindow;

        public event EventHandler<Type> WindowShown;
        public event EventHandler<Type> WindowHided;
    }
}
