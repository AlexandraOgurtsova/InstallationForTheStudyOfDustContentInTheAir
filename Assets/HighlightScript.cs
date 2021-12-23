using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    MaterialChanger changer;

    private void Start()
    {
        changer = obj.GetComponent<MaterialChanger>();
    }

    private void OnMouseEnter()
    {
        changer.HighLightObject();
    }

    private void OnMouseExit()
    {
        changer.BackMaterials();
    }
}
