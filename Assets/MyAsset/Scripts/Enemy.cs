using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //後々ステートパターン追加？
    // Update is called once per frame
    void Update()
    {
        Move(Time.deltaTime);
        if (HP <= 0)
        {
            this.gameObject.GetComponent<Ball>().enabled = true;
            this.gameObject.tag = "ball";
            enabled = false;
        }
    }

    //絶対継承後追記,移動速度はtimeで制御すること(time = deltaTime)
    public virtual void Move(float time)
    {

    }

    //戻り値で相性参照？
    public virtual void Damage(int damage)
    {
        HP -= damage;
        HP = Mathf.Max(0, HP);
    }
}
