using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float Speed;        //‰ñ“]‰Á‘¬—Í
    [SerializeField] public float SpeedMax;     //Å‘å‰ñ“]‘¬“x
    [SerializeField] public int AttackPower;    
    [SerializeField] public float AirRes;

    //‚Ì‚¿‚É‘Š«’Ç‰Á

    // Start is called before the first frame update
    void Start()
    {
        if (enabled)
        {
            enabled = false;
        }
    }

    //‘Š«‚É‚æ‚é”j‰óˆ—‚ğŒã‚Å’Ç‰Á

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (transform.parent)
        {
            if (coll.gameObject.tag == "Enemy"|| coll.gameObject.tag == "BossEnemy")
            {
                coll.gameObject.GetComponent<Enemy>().Damage(AttackPower);
            }

            if(coll.gameObject.tag == "DestroyObj")
            {
                coll.gameObject.GetComponent<DestroyObj>().Damage(1,this.gameObject);
            }
        }
    }
}
