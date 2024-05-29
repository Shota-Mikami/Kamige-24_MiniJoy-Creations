using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_masked : Enemy
{
    [SerializeField] private float MoveSpeed = 0.1f;
    [SerializeField] private float MovePace = 3.0f;

    private bool isMove = false;
    private float PaceCount = 0.0f;
    private GameObject player;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    public override void Move(float time)
    {
        PaceCount += time;

        //近づくと止まるのを繰り返す
        if (PaceCount >= MovePace)
        {
            PaceCount = 0.0f;
            isMove = !isMove;
        }

        //ゆっくり歩く
        if (isMove)
        {
            rb.velocity = -transform.right * MoveSpeed;

            //折り返し判定(壁or崖)
            if (Physics.Raycast(transform.position, -transform.right, 0.5f) || !Physics.Raycast(transform.position - transform.right * 1.0f, -transform.up, 2.0f))
            {
                Debug.Log("回転！");
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

    }
}
