using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbootbornSchtoocerScript : MonoBehaviour
{
    float minAngle = 118;
    float maxAngle = 70;

    float speed = 5f;

    //float currentPos; 
    float currentAngle = 120;


    //public float speed = 1f;
    Vector3 pos1 = new Vector3(-0.13f, 0.023f, -0.313f);

    private enum State
    {
        off,
        on,
        turnToOff,
        turnToOn
    }

    State state = State.off;

    void ChangeState(bool workShtoocer)
    {
        if (workShtoocer && state == State.off) state = State.turnToOn;
        else if (!workShtoocer && state == State.on) state = State.turnToOff;
    }

    void OnEnable()//при включении/содании объекта
    {
        //currentPos = transform.localPosition.y;
        EventManager.SwitchShtoocer += ChangeState;//подписались на событие 
    }



    void FixedUpdate()
    {

        if (state == State.turnToOn)
        {
            currentAngle -= speed;
            if (currentAngle > maxAngle)
            {
                transform.localEulerAngles = new Vector3(-3.5f, 9.97f, 19.4f);
                transform.Translate(-0.005f, -0.015f, 0.006f);
            }
            else state = State.on;

        }

        if (state == State.turnToOff)
        {
            currentAngle += speed;
            if (currentAngle < minAngle)
            {
                //transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                //transform.Translate(-0.0015f, 0.015f, -0.006f);

                transform.localPosition = new Vector3(-0.152f, 0.1818666f, -0.378f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            else state = State.off;

        }
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        transform.localEulerAngles = new Vector3(-3.5f, 9.97f, 19.4f);
    //        //transform.eulerAngles = new Vector3(-3.5f, 9.97f, 19.4f);
    //        //transform.Rotate(-3.5f, 9.97f, 19.4f);
    //        transform.Translate(-0.05f, -0.15f, 0.06f);
    //    }
    //    if (Input.GetMouseButtonDown(2))
    //    {
    //        transform.localEulerAngles = new Vector3(0, 0, 0);
    //        //transform.eulerAngles = new Vector3(0, 0, 0);
    //        //transform.Rotate(3.5f, -9.97f, -19.4f);
    //        transform.Translate(-0.014f, 0.155f, -0.06f);
    //    }


}

