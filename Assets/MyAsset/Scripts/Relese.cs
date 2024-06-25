using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relese : MonoBehaviour
{
    public Rigidbody pole;
    public Rigidbody body;
    public GameObject bodypos;
    public GameObject pole_ob;

    // public GameObject hand;

    public float m_speed;       //回転加速力
    public float speed_max;     //最大回転速度
    public float speed_level;
    public float startTime;
    [SerializeField] private float flyingtime;
    [SerializeField] private float catch_dist_near = 1.0f;
    [SerializeField] private float catch_dist_far = 30.0f;


    public Vector3 chara;

    public Image meter;
    

    bool Swich = false;
    // Start is called before the first frame update
    void Start()
    {
        speed_level = 0.0f;
        
    }


    // Update is called once per frame
    void Update()
    {

        meter.fillAmount = speed_level / speed_max;
        if (!Swich)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (transform.GetChild(0).gameObject.transform.childCount == 1 && transform.GetChild(0).gameObject.transform.GetChild(0).gameObject != null)
                {
                    speed_max = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Ball>().SpeedMax;
                    m_speed = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Ball>().Speed;
                }
                else
                { 
                    speed_max = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Ball>().SpeedMax;
                    m_speed = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Ball>().Speed;
                }
            }

            if (Input.GetMouseButton(0))
            {
                speed_level += m_speed;
                if(speed_level > speed_max)
                {
                    speed_level = speed_max;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                startTime = 0.0f;

                Swich = true;
                //transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = false;
                if (transform.GetChild(0).gameObject.transform.childCount == 1 && transform.GetChild(0).gameObject.transform.GetChild(0).gameObject != null)
                {
                    transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = false;
                }
                else
                {
                    //子オブジェクト全体のトリガーを外す
                    //Transform[] children = transform.GetChild(0).gameObject.transform.GetComponentsInChildren<Transform>();
                    //foreach(Transform child in children)
                    //{
                    //    child.gameObject.GetComponent<Collider>().isTrigger = false;
                    //}
                    transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = false;
                }
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

            flyingtime = 0.0f;
        }


        else
        {
            flyingtime += Time.deltaTime;

            if (Input.GetMouseButtonDown(1))
            {
                CatchHammer();
                //Swich = false;
                ////transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = true;
                //if (transform.GetChild(0).gameObject.transform.childCount == 1 && transform.GetChild(0).gameObject.transform.GetChild(0).gameObject != null)
                //{
                //    transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = true;
                //}
                //else
                //{
                //    //子オブジェクト全体をtrueにする？
                //    //Transform[] children = transform.GetChild(0).gameObject.transform.GetComponentsInChildren<Transform>();
                //    //foreach (Transform child in children)
                //    //{
                //    //    child.gameObject.GetComponent<Collider>().isTrigger = true;
                //    //}
                //    transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = true;
                //}
                ////transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = true;
                ////this.gameObject.transform.rotation =default;
                //this.gameObject.transform.parent = body.gameObject.transform;
                //pole_ob.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                //pole_ob.AddComponent<HingeJoint>();
                //pole_ob.GetComponent<HingeJoint>().anchor = new Vector3(0.0f, 0.0f, 0.0f);
                //pole_ob.GetComponent<HingeJoint>().axis = new Vector3(0.0f, 0.0f, 1.0f);
                //GetComponent<HingeJoint>().connectedBody = body;

                //pole.constraints = RigidbodyConstraints.FreezeRotation;

                //speed_level = 0.0f;

            }

            if (flyingtime >= 0.5f)
            {
                if (Vector3.Distance(transform.position, pole.transform.position) <= catch_dist_near)
                {
                    CatchHammer();
                }
                else if (Vector3.Distance(transform.position, pole.transform.position) >= catch_dist_far)
                {
                    CatchHammer();
                }
                else if (flyingtime >= 5.0f)
                {
                    CatchHammer();
                }
            }
            
        }
        /*

        if (Input.GetKeyDown("1"))
        {
            speed_level = 50.0f;
        }
        if (Input.GetKeyDown("2"))
        {
            speed_level = 75.0f;
        }

        */
    }

    private void CatchHammer()
    {
        Swich = false;
        if (transform.GetChild(0).gameObject.transform.childCount == 1 && transform.GetChild(0).gameObject.transform.GetChild(0).gameObject != null)
        {
            transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Collider>().isTrigger = true;
        }
        this.gameObject.transform.parent = body.gameObject.transform;
        pole_ob.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        pole_ob.AddComponent<HingeJoint>();
        pole_ob.GetComponent<HingeJoint>().anchor = new Vector3(0.0f, 0.0f, 0.0f);
        pole_ob.GetComponent<HingeJoint>().axis = new Vector3(0.0f, 0.0f, 1.0f);
        GetComponent<HingeJoint>().connectedBody = body;

        pole.constraints = RigidbodyConstraints.FreezeRotation;

        speed_level = 0.0f;

        body.gameObject.GetComponent<Rotate>().RotateInit();
    }
}
