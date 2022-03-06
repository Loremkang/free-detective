using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{
    public bool disableAllAction = false;
    public bool disableSceneAction = false;
    public bool inGlassMode = false;
    public GameObject inferencePanel;
    public GameObject scanPanel;
    public CardController cardController;
    public DeductionTileController deductionTileController;
    public SceneSwitchController sceneSwitchController;
    public AnalyzeController analyzeController;
    public int currentLevel = 0;
    public LevelSwitch[] levelSwitch = new LevelSwitch[3];

    //private bool canvasActive;
    public bool AnalyzeUIActive {
        get {
            return inferencePanel.activeSelf;
        }
        set {
            //canvasActive = value;
            Debug.Log("Set AnalyzeUIActive: " + value.ToString());
            disableAllAction = value;
            inferencePanel.SetActive(value);
        }
    }

    public int CurrentLevel {
        get {
            return currentLevel;
        }
        set {
            if (value < 0 || value >= 3) {
                throw new System.Exception("Invalid Level Switch NO.");
            }
            if (currentLevel == value) {
                return;
            }
            currentLevel = value;
            cardController.SwitchToLevel(value);
            deductionTileController.SwitchToLevel(value);
            analyzeController.Clear();
            refreshLevelSwitch();
        }
    }

    public void refreshLevelSwitch() {
        for (int i = 0; i < Data.levels; i ++) {
            if (i == Data.uiData.currentLevel) {
                //Data.uiData.levelSwitch[i].transform.GetChild(0).gameObject.SetActive(false);
                Data.uiData.levelSwitch[i].transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
                Data.uiData.levelSwitch[i].transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
            } else {
                //Data.uiData.levelSwitch[i].transform.GetChild(0).gameObject.SetActive(true);
                Data.uiData.levelSwitch[i].transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
                Data.uiData.levelSwitch[i].transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }

    void Start() {
        Data.uiData = this;
        AnalyzeUIActive = false;
        currentLevel = 0;
    }
}
