using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField]
    Button schooter;

    [SerializeField]
    Button ventilator;

    [SerializeField]
    Button okno;

    [SerializeField]
    Button perecluch;
    // Start is called before the first frame update
    void Start()
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

   public void OnPointerEnter(PointerEventData eventData)
    {
        schooter.GetComponent<Image>().enabled = true;
        schooter.GetComponentInChildren<Text>().enabled = true;

        ventilator.GetComponent<Image>().enabled = true;
        ventilator.GetComponentInChildren<Text>().enabled = true;

        okno.GetComponent<Image>().enabled = true;
        okno.GetComponentInChildren<Text>().enabled = true;

        perecluch.GetComponent<Image>().enabled = true;
        perecluch.GetComponentInChildren<Text>().enabled = true;
    }
}
