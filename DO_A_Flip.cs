using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DO_A_Flip : MonoBehaviour

{
    public Rigidbody2D Body;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    public movement move;
    void Update()
    {
        bool LocalSwapCheck = true;
        {
            //if (move.IsGrounded)
                LocalSwapCheck = true;
                //gravity reversal
                if (Input.GetKeyDown(KeyCode.W) && LocalSwapCheck)
            {
                Body.gravityScale *= -1;
                Vector3 newScale = Body.transform.localScale;
                newScale.y *= -1;
                transform.position = transform.position + (new Vector3(0, Body.gravityScale * 2));
            }

        }
    }
}