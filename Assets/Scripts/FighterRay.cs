using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterRay : MonoBehaviour
{
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Ray ray = new Ray (transform.position, new Vector3 (0, -1, 0));
        RaycastHit hit;
        int distance = 1000;
        // float dis = hit.distance;

        if (Physics.Raycast(ray,out hit,10.0f))
        {
            Debug.Log(hit.collider.gameObject.transform.position);
        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 5);

        if(Physics.Raycast(ray, out hit, 10.0f, mask)) 
        {
            float dis = hit.distance;

            if (hit.collider.tag == "ground")
            {
                Debug.Log(hit.distance);
            }
        }
    }
}
