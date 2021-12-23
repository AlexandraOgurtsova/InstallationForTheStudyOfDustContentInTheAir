using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void SwitchHandler(bool work);//включение установки
    public delegate bool HandlerValues();//запись в таблицу

    public static event SwitchHandler Switch;//переключение
    public static event HandlerValues WritingValue;//запись в таблицу

    public delegate void SwitchVentilHandler(bool workVentil);//включение тумблера "Вентилятор"
    public static event SwitchVentilHandler SwitchVentil;//переключение

    public delegate void SwitchShtoocerHandler(bool workShtoocer);//откручивание пробоотборного штуцера
    public static event SwitchShtoocerHandler SwitchShtoocer;//откручивание

    public delegate void SwitchFilterHandler(int workFilter);//изменение расположение фильтра
    public static event SwitchFilterHandler SwitchFilter;//переместили

    private void Start()
    {
        Switch(false);
        SwitchVentil(false);
        SwitchShtoocer(false);
        SwitchFilter(1);

    }

    public static void SwitchWork(bool work)//просто метод, который будет вызвать событие
    {
        Switch(work);//вызываем событие для подписчиков
    }

    public static void SwitchWorkVentil(bool workVentil)
    {
        SwitchVentil(workVentil);
    }

    public static void SwitchWorkShtoocer(bool workShtoocer)
    {
        SwitchShtoocer(workShtoocer);
    }

    public static void SwitchWorkFilter(int workFilter)
    {
        SwitchFilter(workFilter);
    }


    public static bool WriteValue()
    {
        if (WritingValue())
        {
            return true;
        }
        else return false;
    }


    public static float ToPersent(float min, float max, float value)
    {
        return Mathf.Abs((min - value) / (max - min));
    }

    public static float FromPersent(float min, float max, float persent)
    {
        return (max-min)*persent+min;
    }
}
