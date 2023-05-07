using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiResetti : MonoBehaviour
{
    Vector3 orgin;
    // Start is called before the first frame update
    void Start()
    {
        orgin = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OHKO")
        {
            transform.position = orgin;
        }
    }
}
