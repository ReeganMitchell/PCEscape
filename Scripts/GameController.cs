using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Camera cam;

    public int RoomNumber = 0;
    public int KeysCollected = 0;

    public GameObject plr;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        InitRoom(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitRoom(int num)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < objs.Length; i++)
        {
            objs[i].SendMessage("SetActive", num);
        }
    }

    void MoveCamera(int dir)
    {
        switch (dir)
        {
            case 0:
                cam.transform.position = cam.transform.position + new Vector3(0, 15);
                break;
            case 1:
                cam.transform.position = cam.transform.position + new Vector3(27, 0);
                break;
            case 2:
                cam.transform.position = cam.transform.position + new Vector3(0, -15);
                break;
            case 3:
                cam.transform.position = cam.transform.position + new Vector3(-27, 0);
                break;
        }
    }

    int GetNextRoom(int dir)
    {
        if (dir == 0) //up
        {
            switch (RoomNumber)
            {
                //0, 2, 5, 8, 9, 10, 11
                case 0:
                    return 99;
                case 2:
                    return 1;
                case 5:
                    return 4;
                case 8:
                    return 7;
                case 9:
                    return 8;
                case 10:
                    return 9;
                case 11:
                    return 12;
            }
        } else if (dir == 1) //right
        {
            switch (RoomNumber)
            {
                //0, 1, 3, 4, 5, 6, 11, 13
                case 0:
                    return 7;
                case 1:
                    return 0;
                case 3:
                    return 2;
                case 4:
                    return 3;
                case 5:
                    return 6;
                case 6:
                    return 13;
                case 11:
                    return 10;
                case 13:
                    return 12;
            }

        } else if (dir == 2) //down
        {
            switch (RoomNumber)
            {
                //1, 4, 7, 8, 9, 12
                case 1:
                    return 2;
                case 4:
                    return 5;
                case 7:
                    return 8;
                case 8:
                    return 9;
                case 9:
                    return 10;
                case 12:
                    return 11;
            }
        } else if (dir == 3) //left
        {
            switch (RoomNumber)
            {
                // 0, 2, 3, 6, 10, 12, 13
                case 0:
                    return 1;
                case 2:
                    return 3;
                case 3:
                    return 4;
                case 6:
                    return 5;
                case 10:
                    return 11;
                case 12:
                    return 13;
                case 13:
                    return 6;
            }
        }
        return 0;
    }

    public void openDoor(int dir)
    {

        int nextRoom = GetNextRoom(dir);
        if (nextRoom == 99)
        {
            //End Game
        }
        else
        {
            MoveCamera(dir);
            InitRoom(nextRoom);
        }
        RoomNumber = nextRoom;
    }
}
