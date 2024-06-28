//================================================================================
//NoModelPlayer
//================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMP : MonoBehaviour
{
    [SerializeField] private GameObject player_body_model;
    [SerializeField] private GameObject player_tail_model;

    [SerializeField] private GameObject body;
    [SerializeField] private GameObject tail;
    [SerializeField] private float init_dist_body_tail = 3.0f;
    [SerializeField] private float catch_dist_body_tail = 2.5f;
    //[SerializeField] private float power_tail = 1.0f;

    private float dist_body_tail = 3.0f;
    private Vector3 vec_bodytotail;

    //body
    [SerializeField] private float speed_move = 25.0f;
    [SerializeField] private float speed_jump = 1.0f;

    //tail
    [SerializeField] private float speed_swing = 2.0f;
    [SerializeField] private float power_throw_max = 15.0f;
    [SerializeField] private float power_throw_charge = 0.1f;

    void Start()
    {
        body.GetComponent<NMP_Body>().SetMoveSpeed(speed_move);
        body.GetComponent<NMP_Body>().SetJumpSpeed(speed_jump);

        tail.GetComponent<NMP_Tail>().SetSwingSpeed(speed_swing);
        tail.GetComponent<NMP_Tail>().SetThrowPowerMax(power_throw_max);
        tail.GetComponent<NMP_Tail>().SetThrowPowerCharge(power_throw_charge);
    }

    void Update()
    {
        if (tail.GetComponent<NMP_Tail>().GetIsCatched())
        {
            tail.transform.position = body.transform.position + tail.transform.right * init_dist_body_tail;
        }
        else
        {
            dist_body_tail = Vector3.Distance(tail.transform.position, body.transform.position);
            if(catch_dist_body_tail >= dist_body_tail)
            {
                tail.GetComponent<NMP_Tail>().CatchTail();
                vec_bodytotail = Vector3.zero;
            }
            else
            {
                vec_bodytotail = tail.transform.position - body.transform.position;
                body.GetComponent<Rigidbody>().AddForce(vec_bodytotail);
            }
        }
        
    }

    private void LateUpdate()
    {


        if (player_body_model)
            player_body_model.transform.position = body.transform.position - new Vector3(0.0f, 1.0f, 0.0f);
        if (tail.GetComponent<NMP_Tail>().GetIsCatched())
            return;
        if (player_tail_model)
            player_tail_model.transform.position = tail.transform.position;
    }
}
