using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherSchtoocer : MonoBehaviour
{
    bool workShtoocer = false;

    private void OnMouseDown()
    {
        workShtoocer = !workShtoocer;
        PowerShtoocer(workShtoocer);
    }

    public void PowerShtoocer(bool workShtoocer)
    {
        EventManager.SwitchWorkShtoocer(workShtoocer);
    }
}
