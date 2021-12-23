using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class viewYst : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private Transform anchorObject;

    Replacer camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Replacer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      camera.MoveTo(anchorObject);
    }
}
