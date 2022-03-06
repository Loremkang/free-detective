using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour
{
    private int selfLevel;
    private Animator animator;
  
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        switch (name) {
            case "Level1":
                selfLevel = 0;
                break;
            case "Level2":
                selfLevel = 1;
                break;
            case "Level3":
                selfLevel = 2;
                break;
            default:
                throw new System.Exception("Invalid Level Switch Name");
        }
        Debug.Log(name + " " + selfLevel.ToString());
        Data.uiData.levelSwitch[selfLevel] = this;
        if (selfLevel == Data.uiData.currentLevel) {
            transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
            transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
        } else {
            transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
            transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
        }
    }
    private void OnMouseDown() {
        Data.uiData.CurrentLevel = selfLevel;
    }
}
