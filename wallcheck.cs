using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcheck : MonoBehaviour
{
    public bool isGrounded = false;
    public Rigidbody2D Body;
    void Start()
    {

    }
    
    void Update()
        //jump
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Body.AddForce(new Vector3(0, Body.gravityScale * 11, 0), ForceMode2D.Impulse);
            }
        }
    
        //groundcheck for jump
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Wall")
            {
                isGrounded = true;
                
            }
        }
        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Wall")
            {
                isGrounded = false;
            }
        }
    }

