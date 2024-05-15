using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : Enemy
{
    public float speed = 3.0f;

    public bool right = false;

    public override void Move(float time)
    {
        // 現在の位置を取得
        Vector3 currentPosition = transform.position;

        // 次の位置を計算（時間によって移動量を調整）
        Vector3 nextPosition;

        if (right)
        {
            nextPosition = currentPosition + transform.right * speed * time;
        }
        else 
        {
            nextPosition = currentPosition + -transform.right * speed * time;
        }
        // 次の位置に移動
        transform.position = nextPosition;

        if(HP <= 0)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().mass = 1;
        }
    }
}
