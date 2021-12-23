using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeByCursor : MonoBehaviour {

    MaterialChanger changer;
    
    private void Start()
    {
        changer = GetComponent<MaterialChanger>();
    }
    
    void OnMouseEnter()
    {
        changer.HighLightObject();
    }
    void OnMouseExit()
    {
        changer.BackMaterials();
    }
}

