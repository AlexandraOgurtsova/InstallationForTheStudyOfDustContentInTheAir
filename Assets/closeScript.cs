using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class closeScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Image scaleImage;

    [SerializeField]
    Image massa1;

    [SerializeField]
    Image massa2;

    [SerializeField]
    Button close;
    // Start is called before the first frame update

    public void OnPointerClick(PointerEventData eventData)
    {
        scaleImage.enabled = false;
        massa1.enabled = false;
        massa2.enabled = false;
        close.GetComponent<Image>().enabled = false;
    }
    //public void OnClick()
    //{
    //    scaleImage.enabled = false;
    //    massa1.enabled = false;
    //    massa2.enabled = false;
    //    //close.GetComponent<Image>().enabled = false;
    //}
}
