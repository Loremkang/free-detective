using System;
using UnityEngine;

public class Driver : MonoBehaviour {
    public void Start () {
        Debug.Log("Start Loading");
        Data.Init();
        Debug.Log("Load Finished");
        // foreach(Item item in Data.globalItemMap.Values) {
        //     Debug.Log();
        //     item.tryHiddingThis();
        // }
        // gameLoop();
    }

    // public void gameLoop() {
    //     while (!Data.gameFinished) {
    //         Actor.prePrint();
    //         Actor.stateMachine();
    //         // var action = Actor.getAction();
    //         // Actor.take(action);
    //     }
    // }
}