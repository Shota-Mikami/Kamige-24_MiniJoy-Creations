//--------------------------------------------------------------
//Player‚ÌˆÚ“®‚ğŠÇ—‚·‚é‚à‚Ì
//--------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    private float speed = 0.0f;     //ˆÚ“®‘¬“x
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //‰¡ˆÚ“®
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed , ForceMode.Impulse);
    }

    //ˆÚ“®‘¬“x•ÏXŠÖ”
    public void SetMoveSpeed(float sp)
    {
        speed = sp;
    }
}
