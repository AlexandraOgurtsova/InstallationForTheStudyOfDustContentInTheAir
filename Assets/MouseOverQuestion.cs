using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverQuestion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        img.SetActive(false);
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        img.SetActive(true);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.SetActive(false);
    }
}
