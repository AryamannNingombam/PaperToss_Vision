using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void IncrementPoint()
    {
        PointsController.incrementPoints();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Dustin_Sphere_Tag")
        {
            print("Collided with dustbin!");
            IncrementPoint();
        }
        print("Collided!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
