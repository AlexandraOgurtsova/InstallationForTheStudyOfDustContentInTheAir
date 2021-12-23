using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filter : MonoBehaviour
{
    public float speed = 1f;
    Vector3 pos1 = new Vector3(2.6f, 1.06f, 3.1f);
    Vector3 pos2 = new Vector3(2.07f, 0.98f, 2.73f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {

            transform.position = Vector3.MoveTowards(transform.position, pos1, speed);

        }

        if (Input.GetKey(KeyCode.Y))
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, pos2, speed);

        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, pos1, speed);

        }
    }

}

