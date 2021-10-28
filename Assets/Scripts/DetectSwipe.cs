using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK.InputModule;

public class DetectSwipe : MonoBehaviour,ISwipeHandler
{
    float heightForce, widthForce;
    [SerializeField]
    Rigidbody ball;

    int time = 0;
    bool startSwipeTimer = false;
    bool startTimer = false;
    float timerValue = 75;
    int points = 0;

    void ISwipeHandler.OnSwipeCanceled(SwipeEventData eventData)
    {
        //print("Swipe cancelled!");
    }

    void IncrementPoint()
    {
        PointsController.incrementPoints();
    }

    void ISwipeHandler.OnSwipeCompleted(SwipeEventData eventData)
    { 
        

        
         
    }

    void ISwipeHandler.OnSwipeDown(SwipeEventData eventData, float value)
    {
        //print("Swipe down!"); 
    }

    void ISwipeHandler.OnSwipeLeft(SwipeEventData eventData, float value)
    {
        //print("Swipe left!");
    }

    void ISwipeHandler.OnSwipeRight(SwipeEventData eventData, float value)
    {
        //print("Swipe right!");
    }

    void ISwipeHandler.OnSwipeStarted(SwipeEventData eventData)
    {
        startSwipeTimer = true;
        
    }

    void ISwipeHandler.OnSwipeUp(SwipeEventData eventData, float value)
    {
        

        ball.AddForce(new Vector3(widthForce*30f,heightForce*50f, 30f),ForceMode.Impulse);
        startTimer = true;
        startSwipeTimer = false;
        print(time);
        time = 0;
        IncrementPoint();
         

    }

    void ISwipeHandler.OnSwipeUpdated(SwipeEventData eventData, Vector2 swipeData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
    }

    // Update is called once per frame
    void Update()
    {


        if (startSwipeTimer) time++;
        if (startTimer)

        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime*100;
            }
            else
            {
                ball = Instantiate(ball, new Vector3(0, 3.08f, 2.07f), Quaternion.identity);
                timerValue = 75;
                startTimer = false;
            }
            
        }


        heightForce = JMRPointerManager.Instance.GetCurrentRay().direction.y;
        widthForce = JMRPointerManager.Instance.GetCurrentRay().direction.x;

    }
}
