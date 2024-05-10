using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relese : MonoBehaviour
{
    public Rigidbody pole;
    public Rigidbody body;
    public GameObject bodypos;
    public GameObject pole_ob;

    // public GameObject hand;

    public float speed_level;
    public float startTime;


    public Vector3 chara;
    

    bool Swich = false;
    // Start is called before the first frame update
    void Start()
    {
        speed_level = 0.0f;

    }


    // Update is called once per frame
    void Update()
    {


        if (!Swich)
        {


            if (Input.GetMouseButtonDown(0))
            {
                startTime = Time.time;
            }

            if (Input.GetMouseButtonUp(0) || startTime + 1.0f <= Time.time && startTime != 0.0f)
            {
                startTime = 0.0f;

                Swich = true;
                //transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = false;
                transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = false;
                // GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<HingeJoint>());
                this.gameObject.transform.parent = null;

                pole.AddForce(transform.right * speed_level, ForceMode.Impulse);
                pole.constraints = RigidbodyConstraints.None;
                pole.constraints = RigidbodyConstraints.FreezePositionZ| RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;


            }

            //if (Input.GetMouseButtonDown(2))
            //{
            //    Swich = true;
            //    ball.isTrigger = false;
            //    // Destroy(GetComponent<FixedJoint >());

            //    GetComponent<FixedJoint >().SetActive(false);

            //    this.gameObject.transform.parent = null;

            //    hand.AddForce(transform.up * speed_level, ForceMode .Impulse);

            //}

        }


        else
        {
            

            if (Input.GetMouseButtonDown(1))
            {

                Swich = false;
                //transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = true;
                transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = true;
                this.gameObject.transform.rotation =default;
                this.gameObject.transform.parent = body.gameObject.transform;
                pole_ob.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                pole_ob.AddComponent<HingeJoint>();
                pole_ob.GetComponent<HingeJoint>().anchor = new Vector3(0.0f, 0.0f, 0.0f);
                pole_ob.GetComponent<HingeJoint>().axis = new Vector3(0.0f, 0.0f, 1.0f);
                GetComponent<HingeJoint>().connectedBody = body;

                pole.constraints = RigidbodyConstraints.FreezeRotation;

            }

        }

        if (Input.GetKeyDown("1"))
        {
            speed_level = 50.0f;
        }
        if (Input.GetKeyDown("2"))
        {
            speed_level = 75.0f;
        }


    }
}
