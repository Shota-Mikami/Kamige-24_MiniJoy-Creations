using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy_mawaru : Enemy
{
    public float Rotate_time;
    public float Start_time=0.0f;
    public bool Move_sw=false;

    public override void Move(float time)
    {
        if(Move_sw)
        {
       // this.GetComponent<Rigidbody>().AddTorque(new Vector3(0.0f, 0.0f, 2.0f));
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 3.0f);
            Start_time += 1*time;
            if(Start_time>Rotate_time)
            {
                Move_sw = false;
                Start_time = 0.0f;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
        else 
        {
            // this.GetComponent<Rigidbody>().AddTorque(new Vector3(0.0f, 0.0f, -2.0f));
            this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, -3.0f);
            Start_time += 1 * time;
            if (Start_time > Rotate_time)
            {
                Move_sw = true;
                Start_time = 0.0f;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
    }

}
