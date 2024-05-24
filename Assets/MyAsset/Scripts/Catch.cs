using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Catch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ball;
    public GameObject deathEnemy;

    [SerializeField] public float handSize;
    [SerializeField] public Vector3 handPos;
    [SerializeField] public float handSpan;
    [SerializeField] public GameObject player;
    private Vector3 handPos_Rotation;


    private bool isHold;

    public RectTransform CatchUI;//これにUIを取り付ける
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

                CatchUI.gameObject.SetActive(false);

                deathEnemy.transform.position = ball.transform.position;
                deathEnemy.AddComponent<FixedJoint>();
                deathEnemy.GetComponent<FixedJoint>().anchor = new Vector3(0.0f, 0.0f, 0.0f);
                deathEnemy.GetComponent<FixedJoint>().axis = new Vector3(0.0f, 0.0f, 1.0f);
                deathEnemy.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
                deathEnemy.GetComponent<FixedJoint>().enablePreprocessing = false;
                deathEnemy.GetComponent<Collider>().isTrigger = true;
                if (deathEnemy.transform.childCount != 0)
                {
                    Transform[] children = deathEnemy.transform.GetComponentsInChildren<Transform>();
                    foreach (Transform child in children)
                    {
                        child.gameObject.GetComponent<Collider>().isTrigger = true;
                    }
                }
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

        
        if(player.transform.rotation.y==0.0f)
        {
            handPos_Rotation=handPos;
        }
        else
        {
            handPos_Rotation=handPos*-1;
        }
        //var isHit = Physics.SphereCast(transform.position, radius, transform.right, out hit,1);
        if (!isHold)
        {
            if (Physics.SphereCast(player.transform.position + handPos_Rotation, handSize, player.transform.right, out hit, handSpan))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "ball")
                {
                    deathEnemy = hit.collider.gameObject;

                    CatchUI.gameObject.SetActive(true);//UIの出現
                    CatchUI.position = RectTransformUtility.WorldToScreenPoint(Camera.main, deathEnemy.transform.position);//UIの位置の移動
                }
                else
                {

                    CatchUI.gameObject.SetActive(false);
                    deathEnemy = null;
                }
            }
            else
            {

                CatchUI.gameObject.SetActive(false);
                deathEnemy = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position + handPos_Rotation + player.transform.right * handSpan, handSize);
    }
}

