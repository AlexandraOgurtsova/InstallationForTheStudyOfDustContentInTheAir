using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherFilterPosition : MonoBehaviour
{
    Vector3 pos1 = new Vector3(2.6f, 1.06f, 3.1f);
    Vector3 pos2 = new Vector3(2.07f, 0.98f, 2.73f);

    private enum State
    {
        onTable,
        onScales,
        inYst,
        onScalesAfter,
        filterOnTable,
        filterOnScales,
        filterInYst,
        filterOnScalesAfter
    }

    State state = State.onScales;

    void ChangeState(int workFilter)
    {
        if (workFilter == 1 && state == State.onTable) state = State.filterOnTable;//фильтр расположен на столе
        else if (workFilter == 2 && state == State.onScales) state = State.filterOnScales;//фильтр расположен на весах
        else if (workFilter == 3 && state == State.inYst) state = State.filterInYst;//фильтер расположен в установке
        else if (workFilter == 4 && state == State.onScalesAfter) state = State.filterOnScalesAfter;//фильтр расположен на весах, после проведения измерения
    }

    void OnEnable()//при измененении расположения/содании объекта
    {
        
        EventManager.SwitchFilter += ChangeState;//подписались на событие 
    }



    void FixedUpdate()
    {

        if (state == State.filterOnTable)
        {
            transform.position = new Vector3(2.418f, 0.733f, 2.57f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            state = State.onScales;

        }

        if (state == State.filterOnScales)
        {
            transform.position = new Vector3(2.62f, 1.06f, 3.12f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            state = State.inYst;
        }

        if (state == State.filterInYst)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            transform.position = new Vector3(2.05f, 0.894f, 2.62f);
            state = State.onScalesAfter;
        }

        if (state == State.filterOnScalesAfter)
        {
            transform.position = new Vector3(2.62f, 1.06f, 3.12f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            state = State.onTable;
        }
    }
}
