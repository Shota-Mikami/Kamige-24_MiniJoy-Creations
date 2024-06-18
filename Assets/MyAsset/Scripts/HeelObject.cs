using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelObject : MonoBehaviour
{
    public int HeelPower = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<move>().Heel(HeelPower);

            Destroy(gameObject);
        }
    }

}
