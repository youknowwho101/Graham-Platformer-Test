using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour {
    public bool Jump;
    public Transform tf;
    private Vector2 initialPosition;
    public Rigidbody2D rb;
    public float MoveSpeed;
    public float jumpSpeed;

   

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    //to make sure you can't fly
    public void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            Jump = true;
        }
    }

    //haha you lost now jump to reset game
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Jump = true;
            transform.position = initialPosition;
        }
    }




    // Update is called once per frame
    void Update() {

        //move to the right baby
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(MoveSpeed, 0), ForceMode2D.Impulse);
        }

        //move to the left baby
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-MoveSpeed, 0), ForceMode2D.Impulse);
        }

        //jump high baby
        {
                if (Input.GetKey(KeyCode.Space) && Jump == true)
                {
                    rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                    Jump = false;

                }
        }

       








    }
    }



