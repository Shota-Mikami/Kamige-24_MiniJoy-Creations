//--------------------------------------------------------------
//Hammerの回転を管理するもの
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Player : MonoBehaviour
{
    private bool isReady = true;    //投げる準備ができているか(ハンマーが手元にあるか)
    private float speed = 0.0f;     //回転速度

    void Start()
    {
        //角度リセット
        InitRotate();
    }

    void Update()
    {
        //投げる準備ができている(ハンマーが手元にある)か
        if (isReady)
        {
            //マウス右クリックで角度リセット
            if (Input.GetMouseButtonDown(1))
            {
                InitRotate();
            }

            //マウス左ボタン長押しで回転
            if (Input.GetMouseButton(0))
            {
                transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime);
            }
        }

        //子オブジェクトがあるか＝ハンマーを投げられるか
        isReady = transform.IsChildOf(transform);
    }

    //回転速度変更関数
    public void SetRotateSpeed(float sp)
    {
        speed = sp;
    }

    //回転角度初期化関数
    public void InitRotate()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
    }

}
