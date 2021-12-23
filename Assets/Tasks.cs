using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public Camera cam;

    [SerializeField]
    GameObject practice;

    [SerializeField]
    GameObject display;

    [SerializeField]
    GameObject filtr;

    [SerializeField]
    Texture2D img_ms1;

    [SerializeField]
    Texture2D img_ms;

    [SerializeField]
    Texture2D img_ms2;

    [SerializeField]
    Text taskText;

    [SerializeField]
    Button addButton;

    [SerializeField]
    Button tableButton;

    [SerializeField]
    Button clearTableButton;

    [SerializeField]
    GameObject inputArea;

    bool isWorking;
    bool isWorkingVentil;
    bool isSctoocer;
    int positionFilter;

    bool wasTaskControl;

    int numberOfTask = 0;

    private Camera cam1;

    private void Start()
    {
        practice.SetActive(false);
        taskText.enabled = false;
        inputArea.SetActive(false);
        
        taskText.text = ++numberOfTask + ". " + "Включите установку";

        EventManager.Switch += WorkingControl;
        EventManager.SwitchVentil += WorkingVentilControl;
        EventManager.SwitchShtoocer += WorkingSctoocerControl;
        EventManager.Switch += Task1;
    }

    void WorkingControl(bool work)//постоянно отслеживаем включена ли установка
    {
        isWorking = work;
    }

    void WorkingVentilControl(bool workVentil)
    {
        isWorkingVentil = workVentil;
    }

    void WorkingFilterControl(int workFilter)
    {
        positionFilter = workFilter;
    }

    void WorkingSctoocerControl(bool workShtoocer)
    {
        isSctoocer = workShtoocer;
    }

    public void Open()
    {
        practice.SetActive(true);
        taskText.enabled = true;
        inputArea.SetActive(true);
    }

    void Task1(bool w)
    { 
        if (w)
        {
            EventManager.Switch -= Task1;
            taskText.text = ++numberOfTask + ". " + "Взвесте фильтр. Для того, чтобы положить фильтр на весы нажмите на него";
            EventManager.SwitchFilter += Task2;
            Open();
        }
    }

    void Task2(int a)
    {
        if (a==2)
        {
            EventManager.SwitchFilter -= Task2;
            taskText.text = ++numberOfTask + ". " + "Нажмите на кнопку Весы и впишите массу фильтра в таблицу. Чтобы вернуться к установке, нажмите на соответствующую кнопку в меню";
            display.GetComponent<Renderer>().material.mainTexture = img_ms1;
            EventManager.WritingValue += Task3;
            Open();
        }
    }

    bool Task3()
    {
        if (isWorking)
        {
            EventManager.WritingValue -= Task3;
            taskText.text = ++numberOfTask + ". " + "Для того, чтобы вставить фильтр в пылевой блок, открутите пробоотборный штуцер, кликнув по нему";
            EventManager.SwitchShtoocer += Task4;
            Open();
            return true;
        }
        else return false;
    }

    void Task4(bool s)
    {
        if (s)
        {
            EventManager.SwitchShtoocer -= Task4;
            taskText.text = ++numberOfTask + ". " + "Вставте фильтр в пылевой блок, нажав на фильтр";
            EventManager.SwitchFilter += Task5;
            Open();
        }
    }

    void Task5(int a)
    {
        if (a == 3)
        {
            EventManager.SwitchFilter -= Task5;
            display.GetComponent<Renderer>().material.mainTexture = img_ms;
            taskText.text = ++numberOfTask + ". " + "Закрутите пробоотборный штуцер, нажав на него";
            EventManager.SwitchShtoocer += Task6;
            Open();
        }
    }

    void Task6(bool s)
    {
        if (!s)
        {
            EventManager.SwitchShtoocer -= Task6;
            taskText.text = ++numberOfTask + ". " + "Включите тумблер Вентилятора, для создания запыленной среды";
            EventManager.SwitchVentil += Task7;
            Open();
        }
    }

    void Task7(bool v)
    {
        if (v && isWorking)
        {
            EventManager.SwitchVentil -= Task7;
            taskText.text = ++numberOfTask + ". " + "Подождите 2-3 минуты и выключите тумблер Вентилятор";
            EventManager.SwitchVentil += Task8;
            Open();
        }
    }

    void Task8(bool v)
    {
        if (!v && isWorking)
        {
            EventManager.SwitchVentil -= Task8;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу показания таймера, в виде 00,00, где нули до запятой - минуты, после запятой - секунды";
            EventManager.WritingValue += Task9;
            Open();
        }
    }


    bool Task9()
    {
        if (!isWorkingVentil)
        {
            EventManager.WritingValue -= Task9;
            taskText.text = ++numberOfTask + ". " + "Открутите пробоотборный штуцер, нажав на него";
            EventManager.SwitchShtoocer += Task10;
            Open();
            return true;
        }
        else return false;
    }

    void Task10(bool s)
    {
        if (s)
        {
            EventManager.SwitchShtoocer -= Task10;
            taskText.text = ++numberOfTask + ". " + "Выньте фильтр из установки. Для этого нажмите на фильтр";
            EventManager.SwitchFilter += Task11;
            Open();
        }
    }

    void Task11(int a)
    {
        if (a == 2)
        {
            EventManager.SwitchFilter -= Task11;
            display.GetComponent<Renderer>().material.mainTexture = img_ms2;
            taskText.text = ++numberOfTask + ". " + "Положите фильтр на весы и пишите его массу в таблицу";
            EventManager.WritingValue += Task12;
            Open();
        }
    }

    bool Task12()
    {
        if (isWorking)
        {
            EventManager.WritingValue -= Task12;
            taskText.text = ++numberOfTask + ". " + "Измерения сняты! Ознакомтесь с результатами измерений в таблице, а также сделайте соответствующие выводы";
            EventManager.WritingValue += Task13;
            Open();
            return true;
        }
        else return false;
    }

    bool Task13()
    {
        if (isWorking)
        {
            EventManager.WritingValue -= Task13;
            taskText.text = ++numberOfTask + ". " + "Измерения сняты! Ознакомтесь с результатами измерений в таблице, а также сделайте соответствующие выводы";
            Open();
            return true;
        }
        else return false;
    }


    public void Close()
    {
        practice.SetActive(false);
        taskText.enabled = false;
        inputArea.SetActive(false);
    }


        public void ResetTasks()
    {
        EventManager.SwitchWork(false);
        EventManager.SwitchWorkVentil(false);
        EventManager.SwitchWorkShtoocer(false);
        EventManager.SwitchWorkFilter(1);
        filtr.transform.position = new Vector3(2.418f, 0.733f, 2.57f);
        filtr.transform.rotation = Quaternion.Euler(0, 0, 0);
        numberOfTask = 0;
        taskText.text = ++numberOfTask + ". " + "Включите установку";
        EventManager.Switch += Task1;
    }
}




