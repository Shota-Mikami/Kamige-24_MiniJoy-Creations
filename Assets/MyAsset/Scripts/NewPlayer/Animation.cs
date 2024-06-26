using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            this.GetComponent<Animator>().SetBool("flg_move", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_move", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Animator>().SetBool("flg_jump", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_jump", false);
        }

        if (Input.GetMouseButton(0))
        {
            this.GetComponent<Animator>().SetBool("flg_swing", true);
            this.GetComponent<Animator>().SetBool("flg_jump", false);
            this.GetComponent<Animator>().SetBool("flg_move", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.GetComponent<Animator>().SetBool("flg_fly", true);
            this.GetComponent<Animator>().SetBool("flg_swing", false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            this.GetComponent<Animator>().SetBool("flg_fly", false);
        }





        if (!this.GetComponent<Animator>().GetBool("flg_move") &&
            !this.GetComponent<Animator>().GetBool("flg_jump") &&
            !this.GetComponent<Animator>().GetBool("flg_swing") &&
            !this.GetComponent<Animator>().GetBool("flg_fly"))
        {
            this.GetComponent<Animator>().SetBool("flg_idol", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_idol", false);
        }
    }
}
