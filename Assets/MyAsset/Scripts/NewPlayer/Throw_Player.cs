//--------------------------------------------------------------
//投げたHammerの挙動を管理するもの
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Player : MonoBehaviour
{
    private float speed = 0.0f;                                 //投擲速度
    private Vector3 throw_vec = new Vector3(2.0f, 2.0f, 0.0f);  //投擲方向
    private GameObject hammer = null;                           //先端オブジェクト
    private Transform player_transform = null;

    void Start()
    {
        //先端オブジェクトは初期指定
        hammer = transform.GetChild(0).gameObject;
        player_transform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        //マウス左ボタンホールド解除で投げる
        if (Input.GetMouseButtonUp(0))
        {
            //親から分離
            if (transform.parent)
            {
                transform.parent = null;
            }

            //先端のリジットボディ有効化
            if (hammer.GetComponent<Rigidbody>().isKinematic)
            {
                hammer.GetComponent<Rigidbody>().isKinematic = false;
            }

            hammer.GetComponent<Rigidbody>().AddForce(throw_vec, ForceMode.Impulse);
        }

        //手元に戻す
        if (Input.GetMouseButtonDown(1))
        {
            hammer.GetComponent<Rigidbody>().isKinematic = true;
            hammer.transform.position = player_transform.position;
            transform.parent = player_transform;
            transform.eulerAngles = Vector3.zero;
            hammer.transform.eulerAngles = Vector3.zero;
        }
    }

    //投擲速度変更関数
    public void SetThrowSpeed(float sp)
    {
        speed = sp;
    }

    //投擲方向変更関数
    public void SetThrowVec(Vector3 vec)
    {
        throw_vec = vec;
    }

    public void SetThrowTip(GameObject obj)
    {
        hammer = obj;
    }
}
//-0.1533364