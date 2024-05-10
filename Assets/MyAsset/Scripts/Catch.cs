using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Catch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball;
    public GameObject deathEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ボールを取り替える
        if (Input.GetKeyDown("f"))
        {
            //デスエネミー設定
            if(deathEnemy != null) 
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
            }
        }



        //ボールを戻す
        if (Input.GetKeyDown("g"))
        {
            ball.SetActive(true);

            //デスエネミーが自壊したのでなければ
            if(deathEnemy != null)
            {
                Destroy( deathEnemy );
                deathEnemy = null;
            }

            
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "ball"/* && deathEnemy == null*/)
        {
            deathEnemy = collider.gameObject;
        }
    }


}

