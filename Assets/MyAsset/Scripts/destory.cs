using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_needle : MonoBehaviour
{
    //コライダー同士がぶつかった瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyWall"))
        {
            Destroy(this.gameObject);
        }
    }
}
