using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK.InputModule;

public class DetectSwipe : MonoBehaviour, ISwipeHandler
{
    float heightForce, widthForce;
    [SerializeField]
    Rigidbody ball;


    [SerializeField]
    public GameObject Fan;
    [SerializeField]
    public Transform FanT;
    Vector3 Pos1 = new Vector3(-2.41f, 2.66f, 7.69f);
    Vector3 Pos2 = new Vector3(2.01f, 2.66f, 7.69f);
    int p = 0;


    int time = 0;
    bool start = false;
    bool startTimer = false;
    float timerValue = 75;
    //[SerializeField]
    //FanWind wind;


    void ISwipeHandler.OnSwipeCanceled(SwipeEventData eventData)
    {
        //print("Swipe cancelled!");
    }

    void ISwipeHandler.OnSwipeCompleted(SwipeEventData eventData)
    {
        print("COMPLETE");
        start = false;
        time = 0;
        print(time);
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

    }

    void ISwipeHandler.OnSwipeUp(SwipeEventData eventData, float value)
    {


        ball.AddForce(new Vector3(widthForce * 30f, heightForce * 50f, 30f), ForceMode.Impulse);
        startTimer = true;

        print("Swipe!");

        addwind();
        //Instantiate(ball, new Vector3(0, 3.08f, 2.07f), Quaternion.identity);

    }

    void ISwipeHandler.OnSwipeUpdated(SwipeEventData eventData, Vector2 swipeData)
    {

    }

    public void changepos()
    {

        //changing the position of the fan
        if (p == 0)
        {
            FanT.localPosition = Pos2;
            p = 1;
        }
        else
        {
            FanT.localPosition = Pos1;
            p = 0;
        }

    }


    public void addwind()
    {
        //Adding veloity
        if (p == 0)
        {
            print("entering1");
            ball.AddForce(new Vector3(100, 0, 0));
        }
        else
        {
            print("entering2");
            ball.AddForce(-100, 0, 0);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);
        FanT.localPosition = Pos1;
    }

    // Update is called once per frame
    void Update()
    {


        if (start) time++;
        if (startTimer)

        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime * 100;
            }
            else
            {
                print("Times up!");
                ball = Instantiate(ball, new Vector3(0, 3.08f, 2.07f), Quaternion.identity);
                //wind.PaperR=Instantiate(wind.PaperR, new Vector3(0, 3.08f, 2.07f), Quaternion.identity);
                timerValue = 75;
                startTimer = false;
                changepos();
            }

        }


        heightForce = JMRPointerManager.Instance.GetCurrentRay().direction.y;
        widthForce = JMRPointerManager.Instance.GetCurrentRay().direction.x;

    }
}