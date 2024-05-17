using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float Speed;
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
            if (coll.gameObject.tag == "Enemy")
            {
                coll.gameObject.GetComponent<Enemy>().Damage(AttackPower);
            }
        }
    }
}
