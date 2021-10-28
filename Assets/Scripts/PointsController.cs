using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{

    static private int points = 0;
  
    static public void incrementPoints()
    {
        points++;
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
        GetComponent<Text>().text = "Points : " + points.ToString();
    }
}
