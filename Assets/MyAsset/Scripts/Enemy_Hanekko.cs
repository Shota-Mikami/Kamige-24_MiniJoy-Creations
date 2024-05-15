using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hanekko : Enemy
{
    [SerializeField] public float DistToGround;
    [SerializeField] public float JumpPower;
    private Rigidbody rb;

    private void Start()
    {
        
    }

    public override void Move(float time)
    {
        Vector3 rayvec = new Vector3(0.0f, -1.0f, 0.0f);
        if(Physics.Raycast(this.transform.position + new Vector3(0.0f, -0.2f, 0.0f), rayvec, DistToGround))
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0.0f, JumpPower, 0.0f),ForceMode.Impulse);
        }
    }
}
