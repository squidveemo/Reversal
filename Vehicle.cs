using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vehicle : MonoBehaviour
{
    public bool isGrounded = true;
    public float speed = 5f;
    public Rigidbody2D Car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    //ground check
    {
        if (isGrounded == true)
        {
            transform.position = transform.position + (new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
        if (isGrounded == false)
        {
            transform.position = transform.position + (new Vector3(0, 0.5f, 0) * speed * Time.deltaTime);
        }
     //left and right swap
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = transform.position + (new Vector3(3f, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position + (new Vector3(-3f, 0, 0));
        }
        //return to hub
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("hub");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "HubSpawn")
        {
            SceneManager.LoadScene("WinnerIsYou");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isGrounded = false;
        }       
    }
}
