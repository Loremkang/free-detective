using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public delegate void Delegate();
    public static Delegate leftSwipe = delegate() {
        Debug.Log("left swipe");
        SceneData.curScene().ToRightScene();
    };
    public static Delegate rightSwipe = delegate() {
        Debug.Log("right swipe");
        SceneData.curScene().ToLeftScene();
    };
    public static Delegate upSwipe = delegate() {
        Debug.Log("up swipe");
        SceneData.curScene().ExitScene();
    };
    public static Delegate downSwipe = delegate() {
        Debug.Log("down swipe");
    };

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public float swipeThreshold = 0.8f;

    public float swipeMagnitude = 500f;

    // Start is called before the first frame update
    void Start()
    {
        //dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }

    // Update is called once per frame
    void Update()
    {
        MouseSwipe();
    }

    void MouseSwipe() {
        if (Data.uiData.disableSceneAction || Data.uiData.disableAllAction) {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(0))
        {
                //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        
                //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);


            Debug.Log(currentSwipe.magnitude);
            Debug.Log(swipeMagnitude);

            if (currentSwipe.magnitude < swipeMagnitude) {
                return;
            }
            
            //normalize the 2d vector
            currentSwipe.Normalize();
            Debug.Log(currentSwipe);
    
            //swipe upwards
            if(currentSwipe.y > swipeThreshold && currentSwipe.x > -swipeThreshold && currentSwipe.x < swipeThreshold)
            {
                upSwipe();
            }
            //swipe down
            if(currentSwipe.y < -swipeThreshold && currentSwipe.x > -swipeThreshold && currentSwipe.x < swipeThreshold)
            {
                downSwipe();
            }
            //swipe left
            if(currentSwipe.x < -swipeThreshold && currentSwipe.y > -swipeThreshold && currentSwipe.y < swipeThreshold)
            {
                leftSwipe();
            }
            //swipe right
            if(currentSwipe.x > swipeThreshold && currentSwipe.y > -swipeThreshold && currentSwipe.y < swipeThreshold)
            {
                rightSwipe();
            }
        }
    }
}
