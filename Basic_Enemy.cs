using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy : MonoBehaviour
{
    public float speed = 7f;
    public bool isGrounded = true;
    public Rigidbody2D Body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        transform.position = transform.position + (new Vector3(1, 0, 0) * speed * Time.deltaTime);
        {
            if (isGrounded == false)
                transform.position = transform.position + (new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isGrounded = !isGrounded;
        }
    }
}