using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OHKO : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Body;
    Vector3 orgin;
    void Start()
    {
        orgin = gameObject.transform.position;
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "OHKOscroll")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        {
            if (collider.gameObject.tag == "OHKO")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }
        }
    }
}