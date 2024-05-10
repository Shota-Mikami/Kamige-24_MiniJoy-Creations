using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Vector3 chara;
    
    public GameObject hand;


    // Start is called before the first frame update
    void Start()
    {
        chara = this.transform.position;
        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = -transform.right * speed;
        }

        if (Input.GetKeyDown("r"))
        {
            this.transform.position = chara;
            rb.velocity =Vector3.zero;

        }

    }
}
