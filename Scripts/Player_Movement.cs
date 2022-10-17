using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float maxSpeed = 1f;
    public bool canMove = true;

    public Rigidbody2D rb;
    public Animator anim;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            anim.SetFloat("Horisontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * maxSpeed * Time.fixedDeltaTime);
    }
}
