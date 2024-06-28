using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private bool is_ground;

    [SerializeField]
    private GameObject nmp_tail;
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



        //ƒWƒƒƒ“ƒv
        RaycastHit hit;

            if (Physics.Raycast(transform.position, new Vector3(0.0f, -1.0f, 0.0f), out hit, 1.0f))
            {
                if (hit.collider.tag == "Field")
                {
                    is_ground = true;

                    this.GetComponent<Animator>().SetBool("flg_jump", false);
                }
            }
            else
            {
                is_ground = false;
                this.GetComponent<Animator>().SetBool("flg_jump", true);
            }


        if (Input.GetMouseButton(0))
        {
            this.GetComponent<Animator>().SetBool("flg_swing", true);
            this.GetComponent<Animator>().SetBool("flg_jump", false);
            this.GetComponent<Animator>().SetBool("flg_move", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.GetComponent<Animator>().SetBool("flg_swing", false);
        }
        if (!nmp_tail.GetComponent<NMP_Tail>().GetIsCatched())
        {
            this.GetComponent<Animator>().SetBool("flg_fly", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_fly", false);
        }

        if (this.GetComponent<Animator>().GetBool("flg_fly"))
        {
            this.GetComponent<Animator>().SetBool("flg_jump", false);
        }

        

        if (!this.GetComponent<Animator>().GetBool("flg_move") &&
            !this.GetComponent<Animator>().GetBool("flg_jump") &&
            !this.GetComponent<Animator>().GetBool("flg_swing") &&
            !this.GetComponent<Animator>().GetBool("flg_fly"))
        {
            this.GetComponent<Animator>().SetBool("flg_idle", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("flg_idle", false);
        }
    }
}
