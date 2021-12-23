using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterScript : MonoBehaviour
{
    bool MouseDown = false;

    public Transform CenterPoint;
    public float MaxDistance = 4;

    Vector3 StartPosition;
    Vector3 _targetPoint;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = GetComponent<Transform>().position;
        _targetPoint = new Vector3(-0.1f, 0.1f, -0.1f);
    }

    void OnMouseDown()
    {
        MouseDown = true;
    }

    void OnMouseUp()
    {
        MouseDown = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "scaleTag" && this.transform.position != StartPosition)
        {
            //MoveObj();
        }

        if(other.gameObject.tag == "shtoocerTag" && this.transform.position != StartPosition)
        {
            //MoveObj();
        }
    }

    //void MoveObj()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, _targetPoint, speed);
    //}

    // Update is called once per frame
    void Update()
    {
        Vector3 Cursor = Input.mousePosition;
        Cursor = Camera.main.ScreenToWorldPoint(Cursor);

        float dist = Vector3.Distance(CenterPoint.position, this.transform.position);

        if (MouseDown)
        {
            if (MaxDistance > dist)
                this.transform.position = Cursor;
        }
        else
        {
            this.transform.position = StartPosition;
        }
    }
}
