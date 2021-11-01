using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{

    static public int points = 0;

    static public void incrementPoints()
    {
        points++;
        DetectSwipe.level = points+1;
    }

    static public void restartPoints()
    {
        points = 0;
        
    }

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectSwipe.throws - points > 2)
        {
            print("f");
        }
   
        GetComponent<Text>().text = "Points : " + points.ToString();
    }
}
