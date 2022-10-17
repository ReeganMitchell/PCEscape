using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    public int type; // 0: still flash, 1: Rotate, 2: Follow Path 
    public int Room;
    public bool active;

    public bool direction;
    public float speed;

    public Transform[] wayPointList;
    int state;
    int target;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        target = 0;
        active = false;
        timer = 0f;
        if (type == 2)
        {
            transform.up = -(wayPointList[target].transform.position - transform.position);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (type == 0)
            {
                timer += Time.fixedDeltaTime;

                if (timer > speed)
                {
                    gameObject.transform.GetChild(0).GetComponent<FieldOfView>().on = !gameObject.transform.GetChild(0).GetComponent<FieldOfView>().on;
                    timer = 0f;
                }
            }
            else if (type == 1)
            {
                if (direction)
                {
                    transform.Rotate(0.0f, 0.0f, speed);
                }
                else
                {
                    transform.Rotate(0.0f, 0.0f, -speed);
                }
                
            }
            else if (type == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPointList[target].transform.position, speed * Time.fixedDeltaTime);

                //If Arrived change target
                if (Vector3.Distance(transform.position, wayPointList[target].transform.position) < 0.001f)
                {
                    if (target == wayPointList.Length - 1)
                    {
                        target = 0;
                    }
                    else
                    {
                        target++;
                    }
                    if (direction == false)
                    {
                        transform.Rotate(0.0f, 0.0f, -90f);
                    } else
                    {
                        transform.Rotate(0.0f, 0.0f, 90f);
                    }
                }
            }
            else if (type == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPointList[target].transform.position, speed * Time.fixedDeltaTime);

                //If Arrived change target
                if (Vector3.Distance(transform.position, wayPointList[target].transform.position) < 0.001f)
                {
                    if (target == wayPointList.Length - 1)
                    {
                        target = 0;
                    }
                    else
                    {
                        target++;
                    }
                }
            }
        }
    }

    void SetActive(int roomNum)
    {
        if (roomNum == Room)
        {
            active = true;
            gameObject.transform.GetChild(0).GetComponent<FieldOfView>().on = true;
        }
        else
        {
            active = false;
            gameObject.transform.GetChild(0).GetComponent<FieldOfView>().on = false;
        }
    }
}
