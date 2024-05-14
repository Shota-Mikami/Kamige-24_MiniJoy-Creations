using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Catch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball;
    public GameObject deathEnemy;

    private bool isHold;

    void Start()
    {
        isHold = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ボールを取り替える
        if (Input.GetKeyDown("f"))
        {
            //デスエネミー設定
            if(deathEnemy != null && !isHold) 
            {
                deathEnemy.transform.position = ball.transform.position;
                deathEnemy.AddComponent<FixedJoint>();
                deathEnemy.GetComponent<FixedJoint>().anchor = new Vector3(0.0f, 0.0f, 0.0f);
                deathEnemy.GetComponent<FixedJoint>().axis = new Vector3(0.0f, 0.0f, 1.0f);
                deathEnemy.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                deathEnemy.GetComponent<FixedJoint>().enablePreprocessing = false;
                deathEnemy.GetComponent<Collider>().isTrigger = true;
                deathEnemy.transform.parent = transform.GetChild(0).gameObject.transform;


                ball.SetActive(false);

                isHold = true;
            }
        }



        //ボールを戻す
        if (Input.GetKeyDown("g"))
        {
            ball.SetActive(true);

            //デスエネミーが自壊したのでなければ
            if(deathEnemy != null && isHold)
            {
                Destroy( deathEnemy );
                deathEnemy = null;
                isHold = false;
            }

            
        }

        RaycastHit hit;

        var radius = transform.lossyScale.x * 0.5f;



        //var isHit = Physics.SphereCast(transform.position, radius, transform.right, out hit,1);
        if (!isHold)
        {
            if (Physics.SphereCast(transform.position, radius, transform.right, out hit, 1))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "ball")
                {
                    deathEnemy = hit.collider.gameObject;
                }
            }
            else
            {

                deathEnemy = null;
            }
        }
    }
}

