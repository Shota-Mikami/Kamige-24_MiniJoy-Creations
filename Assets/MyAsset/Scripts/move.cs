using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class move : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2.0f;
    public float slowSpeed = 1.0f;
    public float jump = 1.0f;
    public Vector3 chara;

    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        chara = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float time = Time.deltaTime;
        float s = speed;

        if (transform.GetChild(0).transform.childCount == 0)
        {
            s = 0.5f;
        }

        //if (transform.GetChild(0).transform.childCount != 0)
        {

            //ÉnÉìÉ}Å[ÇâÒÇµÇƒÇ¢ÇÈÇ∆Ç´
            if (Input.GetMouseButton(0))
            {
                s = slowSpeed;
            }

            if (Input.GetKey("d"))
            {
                transform.position += new Vector3(s, 0.0f, 0.0f) * time;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            if (Input.GetKey("a"))
            {
                transform.position += new Vector3(-s, 0.0f, 0.0f) * time;
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGround)
                {
                    rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                }
            }

        }

        if (Input.GetKeyDown("r"))
        {
            this.transform.position = chara;
            rb.velocity = Vector3.zero;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0.0f, -1.0f, 0.0f), out hit, 0.6f))
        {
            if (hit.collider.tag == "Field")
            {
                isGround = true;
            }
        }
        else
        {
            isGround = false;
        }
    }
}
