//--------------------------------------------------------------
//Player全体を管理するもの
//こいつ自体は概念でしかなく移動もしないため注意が必要
//調整するステータスはこいつで一括管理したい
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Player : MonoBehaviour
{
    [SerializeField] private GameObject Body;
    [SerializeField] private GameObject Joint_Body;

    [SerializeField] private float move_speed = 25.0f;
    [SerializeField] private float rotate_speed = 100.0f;

    //private bool is_release;    //投げたか否か

    void Start()
    {
        Body.GetComponent<Move_Player>().SetMoveSpeed(move_speed);
        Joint_Body.GetComponent<Rotate_Player>().SetRotateSpeed(rotate_speed);
    }

    void Update()
    {
        //ハンマーを持っている(肩に子オブジェクトがある)のであればプレイヤーの位置とハンマーをくっつける
        if (Joint_Body.transform.IsChildOf(Joint_Body.transform))
        {
            Joint_Body.transform.position = Body.transform.position;
        }
        
    }
}
