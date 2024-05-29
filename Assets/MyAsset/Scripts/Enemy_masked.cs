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

        //ãﬂÇ√Ç≠Ç∆é~Ç‹ÇÈÇÃÇåJÇËï‘Ç∑
        if (PaceCount >= MovePace)
        {
            PaceCount = 0.0f;
            isMove = !isMove;
        }

        //Ç‰Ç¡Ç≠ÇËï‡Ç≠
        if (isMove)
        {
            rb.velocity = -transform.right * MoveSpeed;

            //ê‹ÇËï‘ÇµîªíË(ï«oräR)
            if (Physics.Raycast(transform.position, -transform.right, 0.5f) || !Physics.Raycast(transform.position - transform.right * 1.0f, -transform.up, 2.0f))
            {
                Debug.Log("âÒì]ÅI");
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

    }
}
