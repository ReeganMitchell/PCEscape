using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int direction;
    Camera cam;
    GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = GameObject.Find("GameController");
        SetDirection(direction);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDirection(int dir)
    {
        direction = dir;
        BoxCollider2D hitbox = gameObject.GetComponent<BoxCollider2D>();


        switch (dir)
        {
            case 0:
                gameObject.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 8.5f);
                hitbox.size = new Vector2(10f, 0.25f);
                break;
            case 1:
                gameObject.transform.position = new Vector3(cam.transform.position.x + 14.5f, cam.transform.position.y);
                hitbox.size = new Vector2(0.25f, 10f);
                break;
            case 2:
                gameObject.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 8.5f);
                hitbox.size = new Vector2(10f, 0.25f);
                break;
            case 3:
                gameObject.transform.position = new Vector3(cam.transform.position.x - 14.5f, cam.transform.position.y);
                hitbox.size = new Vector2(0.25f, 10f);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        controller.GetComponent<GameController>().openDoor(direction);
    }
}
