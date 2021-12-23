using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuMouseExit : MonoBehaviour, IPointerExitHandler
{

    [SerializeField]
    Button schooter;

    [SerializeField]
    Button ventilator;

    [SerializeField]
    Button okno;

    [SerializeField]
    Button perecluch;


    public void OnPointerExit(PointerEventData eventData)
    {
        schooter.GetComponent<Image>().enabled = false;
        schooter.GetComponentInChildren<Text>().enabled = false;

        ventilator.GetComponent<Image>().enabled = false;
        ventilator.GetComponentInChildren<Text>().enabled = false;

        okno.GetComponent<Image>().enabled = false;
        okno.GetComponentInChildren<Text>().enabled = false;

        perecluch.GetComponent<Image>().enabled = false;
        perecluch.GetComponentInChildren<Text>().enabled = false;
    }

}
