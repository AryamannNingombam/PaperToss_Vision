using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool collided;
    bool startTimer = false;
    float timer = 150;
    // Start is called before the first frame update
    void Start()
    {
        collided = false;
    }
    void IncrementPoint()
    {
        PointsController.incrementPoints();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Dustin_Sphere_Tag" && collided==false)
        {
            collided = true;
            startTimer = true;
            print(collision.gameObject.name);
            IncrementPoint();

        }
        print("Collided!");
    }
    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime * 100;
        }
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
