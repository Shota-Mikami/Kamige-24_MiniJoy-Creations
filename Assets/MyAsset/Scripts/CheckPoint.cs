using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private bool move = false;
    [SerializeField] private float movedist = 0.001f;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 2.0)
        {
            time = 0.0f;
        }
        if(move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movedist * Mathf.Sin(time * Mathf.PI), transform.position.z);
        }
    }
}
