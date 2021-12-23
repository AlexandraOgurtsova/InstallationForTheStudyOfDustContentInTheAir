using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherFilter : MonoBehaviour
{
    int workFilter = 1;

    private void OnMouseDown()
    {
        if (workFilter == 1)
        {
            workFilter = workFilter + 1;
            PowerFilter(workFilter);
        }
        
        if (workFilter == 2)
        {
            workFilter = workFilter + 1;
            PowerFilter(workFilter);
        }

        if (workFilter == 3)
        {
            workFilter = workFilter + 1;
            PowerFilter(workFilter);
        }

        if (workFilter == 4)
        {
            workFilter = workFilter - 3;
            PowerFilter(workFilter);
        }

    }

    public void PowerFilter(int workFilter)
    {
        EventManager.SwitchWorkFilter(workFilter);
    }
}
