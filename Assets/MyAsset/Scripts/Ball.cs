using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public int AttackPower;
    [SerializeField] public float AirRes;

    //のちに相性追加

    // Start is called before the first frame update
    void Start()
    {
        if (enabled)
        {
            enabled = false;
        }
    }

    //相性による破壊処理を後で追加

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
        }
    }
}
