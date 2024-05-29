using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    [SerializeField] private int DurableValue;  //‘Ï‹v’l
    // Update is called once per frame
    void Update()
    {
        if (DurableValue <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void Damage(int damage)
    {
        DurableValue -= damage;
        DurableValue = Mathf.Max(0, DurableValue);
    }
}
