using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPosition : MonoBehaviour {

    public AudioClip aud;
    AudioSource audio;
    //float min = -0.1f;
    //float max = 0.1f;

    float minAngle = 118;
    float maxAngle = 70;

    float speed = 5f;

    //float currentPos; 
    float currentAngle = 120;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private enum State 
        {
        off,
        on,
        turnToOff,
        turnToOn
        }

    State state = State.off;

    void OnEnable()//при включении/содании объекта
    {
        //currentPos = transform.localPosition.y;
        EventManager.Switch += ChangeState;//подписались на событие 
    }
  
    void ChangeState(bool work)
    {
        if (work && state == State.off) state = State.turnToOn;
        else if (!work && state == State.on) state = State.turnToOff;
    }

    void FixedUpdate()
    {
        
        if (state == State.turnToOn)
        {
            currentAngle -= speed;
            if (currentAngle > maxAngle)
            {
                audio.Play();
                audio.loop = true;
                transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.right);
            }
            else state = State.on;

        }

        if (state == State.turnToOff)
        {
            currentAngle += speed;
            if (currentAngle < minAngle)
            {
                audio.Stop();
                transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.right);            
            }     
            else state = State.off;
            
        }
    }
    
}




