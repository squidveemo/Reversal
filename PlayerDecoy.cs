using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDecoy : MonoBehaviour
{
    public float speed = 0.1f;
    public bool down = false;
    //public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (down == false)
        {
            transform.position = transform.position + (new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
        if (down == true)
        {
            transform.position = transform.position + (new Vector3(0, -1, 0) * speed * Time.deltaTime);
        }
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("hub");
            }
        }
    }
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "down")
            {
                down = true;
            }
            if (collision.gameObject.tag == "Up")
        {
                down = false;
        }
        }
    }

