using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    private BoxCollider2D coll;
    public bool isGroundedDX = false;
    public Rigidbody2D Body;
    [SerializeField] private LayerMask Grounded;



    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

        //left/right movement  
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (new Vector3(1, 0, 0) * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - (new Vector3(1, 0, 0) * speed * Time.fixedDeltaTime);
        }
    }
    void Update()
    //jump
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Body.AddForce(new Vector3(0, Body.gravityScale * 12, 0), ForceMode2D.Impulse);
        }

        //gravity reversal
        if (Input.GetKeyDown(KeyCode.W) && CantSwap())
        {
            Body.gravityScale *= -1;
            Vector3 newScale = Body.transform.localScale;
            newScale.y *= -1;
            Body.transform.localScale = newScale;
            transform.position = transform.position + (new Vector3(0, Body.gravityScale * 3));
        }
        //reset to hub
        {
        if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("hub");
            }
        }
    }

    //groundcheck for jump
    //level spawns
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGroundedDX = true;
        }
        if (collision.gameObject.tag == "NextLevel")
        {
            SceneManager.LoadScene("Level-2Intro");
        }
        if (collision.gameObject.tag == "HubSpawn")
        {
            SceneManager.LoadScene("WinnerIsYou");
        }
        if (collision.gameObject.tag == "Level1")
        {
            SceneManager.LoadScene("Level-1Intro");
        }
        if (collision.gameObject.tag == "Level3")
        {
            SceneManager.LoadScene("Level-3Intro");
        }
        if (collision.gameObject.tag == "VehicleStage")
        {
            SceneManager.LoadScene("Level-4Intro");
        }
        if (collision.gameObject.tag == "bounce")
        {
            Body.AddForce(new Vector3(0, Body.gravityScale * 15, 0), ForceMode2D.Impulse);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGroundedDX = false;
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down * Body.gravityScale, .1f, Grounded);
    }

    bool CantSwap()
    {
        RaycastHit2D Hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down * Body.gravityScale, .1f, Grounded);
        if (Hit.collider == null)
        {
            return false;
        }
        if (Hit.collider.gameObject.tag == "floor" && isGroundedDX)
        {
            return true;
        }
        return false;
    }   
}