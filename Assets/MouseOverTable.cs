using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseOverTable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        table.SetActive(false);

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        table.SetActive(true);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        table.SetActive(false);
    }
}
