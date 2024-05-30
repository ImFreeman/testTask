using System.Collections;
using System.Collections.Generic;
using Features.UI.Scripts.Realization;
using UnityEngine;

public class TestWindow : UIBaseWindow
{
    protected override void OnShow()
    {
        Debug.Log("Window is showed");
    }

    protected override void OnHide()
    {
        Debug.Log("Window is hided");
    }
}
