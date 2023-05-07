using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoscroll : MonoBehaviour
{
    public float speed = 7;
    public Rigidbody2D Body2;
    public GameObject wall;
    public bool left = true;
    public bool up = false;
    public bool down = false;
    void Start()
    {



    }
    public void Update()
    {
        if (left == true)
        {
            transform.position = transform.position + (new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        if (up == true)
        {
            transform.position = transform.position + (new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
        if (down == true)
        {
            transform.position = transform.position + (new Vector3(0, -1, 0) * speed * Time.deltaTime);
        }
    }
    public void OnCollisionEnter2D(Collision2D move)
    {
        if (move.gameObject.tag == "Up")
        {
            left = false;
            up = true;
            down = false;
            //transform.position = transform.position + (new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
        if (move.gameObject.tag == "left")
        {
            left = true;
            up = false;
            down = false;
        }
        if (move.gameObject.tag == "down")
        {
            left = false;
            up = false;
            down = true;
        }
        }
    }

