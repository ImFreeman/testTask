using Features.UI.Scripts.Realization;

public interface IUIService
{
    public void LoadWindows();
    public T Show<T>() where T : UIBaseWindow;
    
    public void Hide<T>() where T : UIBaseWindow;
    
    public bool Get<T>(out T window) where T : UIBaseWindow;
}
