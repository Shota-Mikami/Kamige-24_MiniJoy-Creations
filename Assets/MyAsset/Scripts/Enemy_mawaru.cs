using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy_mawaru : Enemy
{
    public float Rotate_time;
    public float Start_time=0.0f;
    public bool Move_sw = false;
    public bool Stop_sw = false;
    public int Step_cnt;
    public int Step_now = 1;

    public override void Move(float time)
    {
        if(Move_sw)
        {
            if (!Stop_sw)
            {
                this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 3.0f);
                Start_time += 1 * time;
                if (Start_time > Rotate_time)
                {
                    Stop_sw = true;

                    Start_time = 0.0f;
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }

            if (Stop_sw)
            {
                Start_time += 1 * time;
                if (Start_time > Rotate_time)
                {
                    Stop_sw = false;
                    Step_now++;
                    Start_time = 0.0f;
                }
            }

            if (Step_now > Step_cnt)
            {
                Move_sw = false;
                Step_now = 1;
            }
        }
        else 
        {
            // this.GetComponent<Rigidbody>().AddTorque(new Vector3(0.0f, 0.0f, -2.0f));
           if(!Stop_sw)
            {
                this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, -3.0f);
                Start_time += 1 * time;
                if (Start_time > Rotate_time)
                {
                    Stop_sw = true;
                   
                    Start_time = 0.0f;
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }

            if (Stop_sw)
            {
                Start_time += 1 * time;
                if (Start_time > Rotate_time)
                {
                    Stop_sw = false;
                    Step_now++;
                    Start_time = 0.0f;
                }
            }

            if(Step_now>Step_cnt)
            {
                Move_sw = true;
                Step_now = 1;
            }
        }
    }

}
