using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class move : MonoBehaviour
{
    public int hpMax = 3;
    public int hp;

    public Rigidbody rb;
    public float speed = 2.0f;
    public float slowSpeed = 1.0f;
    public float maxSpeed = 10.0f;
    public float jump = 1.0f;
    public Vector3 chara;

    public int damageCoolTime = 120;
    private int damageCoolTimeNow = 0;
    public float knockbackPower = 30.0f;

    private bool isGround = false;

    [SerializeField] private Vector2 limitSpacePlus;
    [SerializeField] private Vector2 limitSpaceMinus;
    Animator animator = null;
    [SerializeField] GameObject playerModel = null;

    private float se_WaitTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        hp = hpMax;
        chara = this.transform.position;

        if (playerModel)
            animator = playerModel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isJump", !isGround);
        animator.SetFloat("isMove",Mathf.Abs(rb.velocity.x));

        float time = Time.deltaTime;
        float s = speed;

        //ハンマーと離れているとき
        if (transform.GetChild(0).transform.childCount == 0)
        {
            s = slowSpeed;
            if (Input.GetKey("d"))
            {
                rb.AddForce((Vector3.right * s), ForceMode.Acceleration);
                transform.rotation = new Quaternion(0, 0, 0, 0);

            }
            if (Input.GetKey("a"))
            {
                rb.AddForce((-Vector3.right * s), ForceMode.Acceleration);
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        else
        {
            //ハンマーを回しているとき
            if (Input.GetMouseButton(0))
            {
                s = slowSpeed;
            }

            if (Input.GetKey("d"))
            {
                rb.AddForce(Vector3.right * ((maxSpeed - rb.velocity.x) * s), ForceMode.Acceleration);
                transform.rotation = new Quaternion(0, 0, 0, 0);

            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-Vector3.right * ((maxSpeed + rb.velocity.x) * s), ForceMode.Acceleration);
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        //Debug.Log(rb.velocity);

        if ((Input.GetKey("a") || Input.GetKey("d")) && se_WaitTime >= 0.8)
        {
            // SoundManager.instance.PlaySE(0);
            se_WaitTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
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

        if (transform.position.x <= limitSpaceMinus.x || transform.position.x >= limitSpacePlus.x || transform.position.y <= limitSpaceMinus.y || transform.position.y >= limitSpacePlus.y)
        {
            hp = 0;
        }

        se_WaitTime += 1.0f * Time.deltaTime;



        /////////////
        ///
        if (Input.GetKeyDown("b"))
        {
            SoundManager.instance.PlaySE(0);
        }
        /// 
        /////////////
    }

    public void FixedUpdate()
    {
        damageCoolTimeNow--;
        damageCoolTimeNow = Mathf.Max(damageCoolTimeNow, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //敵との当たり判定処理
        if (damageCoolTimeNow <= 0)
        {
            if (collision.gameObject.tag == "BossEnemy" || collision.gameObject.tag == "Enemy")
            {
                hp--;
                hp = Mathf.Max(hp, 0);

                damageCoolTimeNow = damageCoolTime;

                //Hitした敵とのベクトルを取りAddForceでノックバック処理を行う
                Vector3 vec;
                vec = transform.position - collision.transform.position;
                Vector3.Normalize(vec);

                rb.AddForce(vec * knockbackPower, ForceMode.Impulse);
            }
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            Destroy(collision.gameObject);
        }
    }

    //回復処理
    public void Heel(int HeelPower)
    {
        hp += HeelPower;
        hp = Mathf.Min(hp, hpMax);
    }
}
