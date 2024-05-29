using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : DestroyObj
{
    public override void Damage(int damage, GameObject gameObject)
    {
        if(gameObject.transform.childCount == 1)
        {
            if(gameObject.transform.GetChild(0).tag == "DestroyWall")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
