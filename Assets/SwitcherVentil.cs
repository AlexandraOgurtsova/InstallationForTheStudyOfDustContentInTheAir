using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcherVentil : MonoBehaviour
{

    [SerializeField]
    Text minutes;

    [SerializeField]
    Text seconds;

    private float timeInSecondsP;
    public static int minutsP;
    public static int secondsP;

    bool workVentil = false;

    //изменяем состояние на вкл/выкл
    private void OnMouseDown()
    {
        workVentil = !workVentil;
        PowerVentil(workVentil);
    }

    public void PowerVentil(bool workVentil)
    {
        EventManager.SwitchWorkVentil(workVentil);
    }

    //при включении тумблера "Вентилятор" начинается отсчет таймера
    internal void Update()
    {
        if (workVentil)
        {
            timeInSecondsP += Time.deltaTime;

            //переводим секунды в минуты
            secondsP = (int)(timeInSecondsP % 60);
            minutsP = (int)(timeInSecondsP / 60);

            if (minutsP < 10)
            {
                minutes.text = 0 + minutsP.ToString();
                if (secondsP < 10)
                {
                    seconds.text = 0 + secondsP.ToString();
                }
                else
                {
                    seconds.text = secondsP.ToString();
                }
            }
            else
            {
                minutes.text = 0 + minutsP.ToString();
                if (secondsP < 10)
                {
                    seconds.text = 0 + secondsP.ToString();
                }
                else
                {
                    seconds.text = secondsP.ToString();
                }
            }
        }

        if(!workVentil)
        {
            timeInSecondsP = 0;
        }
    }
}
