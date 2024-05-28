using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Ball_Spring : MonoBehaviour
{


    [SerializeField] public float DistToGround;

    [SerializeField] public float Refrect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                Rigidbody rb = this.GetComponent<Rigidbody>();
        if (this.gameObject.tag == "ball"
            &&this.gameObject.GetComponent<Collider>().isTrigger==false)
        {

            if (this.gameObject.transform.parent!=null)
            {

                RaycastHit hit;
                Vector3 rayvec_y01 = new Vector3(0.0f, -1.0f, 0.0f);
                Vector3 rayvec_y02 = new Vector3(0.0f, 1.0f, 0.0f);
                if (Physics.Raycast(this.transform.position, rayvec_y01, out hit, DistToGround)
                    || Physics.Raycast(this.transform.position, rayvec_y02, out hit, DistToGround))
                {

                    if (hit.collider.tag == "Field")
                    {

                        Debug.Log(hit.collider.tag);
                        rb.AddForce(new Vector3(0.0f, rb.velocity.y * -Refrect, 0.0f), ForceMode.VelocityChange);

                    }
                }
                Vector3 rayvec_x01 = new Vector3(-1.0f, 0.0f, 0.0f);
                Vector3 rayvec_x02 = new Vector3(1.0f, 0.0f, 0.0f);
                if (Physics.Raycast(this.transform.position, rayvec_x01, out hit, DistToGround)
                    || Physics.Raycast(this.transform.position, rayvec_x02, out hit, DistToGround))
                {
                    if (hit.collider.tag == "Field")
                    {
                        Debug.Log(hit.collider.tag);
                        rb.AddForce(new Vector3(rb.velocity.x * -Refrect, 0.0f, 0.0f), ForceMode.VelocityChange);

                    }
                }


                Ray ray = new Ray(this.transform.position, rayvec_y01); // RayÇê∂ê¨
                Debug.DrawRay(ray.origin, ray.direction * DistToGround, Color.red, 0.1f); // í∑Ç≥ÇRÇOÅAê‘êFÇ≈ÇTïbä‘â¬éãâª
                Ray ray1 = new Ray(this.transform.position, rayvec_y02); // RayÇê∂ê¨
                Debug.DrawRay(ray1.origin, ray1.direction * DistToGround, Color.red, 0.1f); // í∑Ç≥ÇRÇOÅAê‘êFÇ≈ÇTïbä‘â¬éãâª
                Ray ray2 = new Ray(this.transform.position, rayvec_x01); // RayÇê∂ê¨
                Debug.DrawRay(ray2.origin, ray2.direction * DistToGround, Color.red, 0.1f); // í∑Ç≥ÇRÇOÅAê‘êFÇ≈ÇTïbä‘â¬éãâª
                Ray ray3 = new Ray(this.transform.position, rayvec_x02); // RayÇê∂ê¨
                Debug.DrawRay(ray3.origin, ray3.direction * DistToGround, Color.red, 0.1f); // í∑Ç≥ÇRÇOÅAê‘êFÇ≈ÇTïbä‘â¬éãâª
            }
        }
    }
}
