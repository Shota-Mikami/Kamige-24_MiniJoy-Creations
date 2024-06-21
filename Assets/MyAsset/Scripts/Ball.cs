using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public float Speed;        //回転加速力
    [SerializeField] public float SpeedMax;     //最大回転速度
    [SerializeField] public int AttackPower;    
    [SerializeField] public float AirRes;
    [SerializeField] private int hitSE_enemy_num;
    [SerializeField] private int hitSE_destroyObj_num;

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
                SoundManager.instance.PlaySE(0);
            }

            if(coll.gameObject.tag == "DestroyObj")
            {
                coll.gameObject.GetComponent<DestroyObj>().Damage(1,this.gameObject);
                SoundManager.instance.PlaySE(0);
            }
        }
    }
}
