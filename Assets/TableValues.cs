using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableValues : MonoBehaviour
{
    [SerializeField]
    InputField textInput;

    [SerializeField]
    Text ms1;

    [SerializeField]
    Text ms2;

    [SerializeField]
    Text t;

    [SerializeField]
    Text V;

    [SerializeField]
    Text C;

    [SerializeField]
    Text n1;

    [SerializeField]
    Text n2;

    [SerializeField]
    Text min;

    [SerializeField]
    Text sec;


    // Update is called once per frame
    public void WriteValue()
    {

        string valueText = textInput.text;
        float newValue = 0;

        if (float.TryParse(valueText, out newValue) && newValue != 0)
        {
            newValue *= 1;
        }
        else
        {
            textInput.text = "";
            return;
        }

        if (ms1.text == "_")
        {
            if (EventManager.WriteValue()) ms1.text = newValue.ToString();
            else return;
        }
        else if (t.text == "_")
        {

            if (EventManager.WriteValue()) t.text = translateInMinute(newValue).ToString();
            else return;
            V.text = CalculateV(newValue).ToString();

        }
        else if (ms2.text == "_")
        {
            if (EventManager.WriteValue()) ms2.text = newValue.ToString();
            else return;
            calculateC();

        }
        textInput.text = "";

    }

    //расчет объема воздуха, который прошел через фильтр
    float CalculateV(float tm)
    {
        return tm * 15;
    }

    //переводим время в минуты(для расчетов) 
    float translateInMinute(float time)
    {
        float seconds;
        float minutes;

        string str = time.ToString();

        string getSeconds = str.Substring(str.Length - 2);
        if(getSeconds == "00")
        {
            seconds = 0.0f;
        }
        else
        {
         seconds = float.Parse(getSeconds);
        }
        

        string getMinutes = str.Substring(0, 2);
        if (getMinutes == "00")
        {
            minutes = 0.0f;
        }
        else
        {
            minutes = float.Parse(getMinutes);
        }
        

        float m = minutes + (seconds/60);

        return m;
    }

    //высчитываем запыленность воздуха
    void calculateC()
    {
        float v = float.Parse(V.text);
        float tm = float.Parse(t.text);
        float m1 = float.Parse(ms1.text);
        float m2 = float.Parse(ms2.text);
        float c = (((m2 - m1) * 1000)) / (v);
        float value = Random.Range(c, c + 0.004f);
        C.text = value.ToString();
        n1.text = value.ToString();
    }

    public void Clean()
    {
        t.text = "_";
        ms1.text = "_";
        ms2.text = "_";
        V.text = "_";
        C.text = "_";
        n1.text = "_";
        min.text = "00";
        sec.text = "00";
    }
}
