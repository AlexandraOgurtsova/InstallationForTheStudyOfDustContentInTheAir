using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcherVentilPosition : MonoBehaviour
{
    [SerializeField]
    ParticleSystem Pyl;
    AudioSource audio;

    float minAngle = 118;
    float maxAngle = 70;

    float speed = 5f;

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
        EventManager.SwitchVentil += ChangeState;//подписались на событие 
    }

    void ChangeState(bool workVentil)
    {
        if (workVentil && state == State.off) state = State.turnToOn;//включен
        else if (!workVentil && state == State.on) state = State.turnToOff;//выключен
    }

    //если изменилось состояние, меняем угол поворота объекта
    void FixedUpdate()
    {

        if (state == State.turnToOn)
        {
            currentAngle -= speed;
            if (currentAngle > maxAngle)
            {
                Pyl.Play();//включаем систему для создания пылевых частиц
                audio.Play();
                audio.loop = true;
                transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.right);
            }
            else 
            { 
                state = State.on;

            }

        }

        if (state == State.turnToOff)
        {
            currentAngle += speed;
            if (currentAngle < minAngle)
            {
                audio.Stop();
                transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.right);
                Pyl.Stop();

            }
            else state = State.off;

        }
    }
}
