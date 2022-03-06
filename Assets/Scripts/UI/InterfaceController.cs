using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterfaceController : MonoBehaviour
{
    public delegate void SwitchSceneDelegate();

    public SwitchSceneDelegate toEvidenceDelegate;
    public SwitchSceneDelegate toInferfaceDelegate;
    public SwitchSceneDelegate toSceneDelegate;

    public GameObject evidenceScene;
    public GameObject deductionTileScene;
    public GameObject sceneScene;
    public GameObject deductionScene;
    private GameObject currentActiveScene;

    // Start is called before the first frame update
    void Start()
    {
        currentActiveScene = null;
        if (deductionTileScene.activeSelf) {
            currentActiveScene = deductionTileScene;
        } else if (sceneScene.activeSelf) {
            currentActiveScene = sceneScene;
        } else {
            currentActiveScene = evidenceScene;
        }
        evidenceScene.SetActive(false);
        deductionTileScene.SetActive(false);
        deductionScene.SetActive(false);
        sceneScene.SetActive(false);
        currentActiveScene.SetActive(true);

        toEvidenceDelegate = delegate () {
            Debug.Log("Switch to evidence scene");
            // currentActiveScene.SetActive(false);
            // currentActiveScene = evidenceScene;
            deductionScene.SetActive(true);
            evidenceScene.SetActive(true);
            deductionTileScene.SetActive(false);
            sceneScene.SetActive(false);
        };
        toInferfaceDelegate = delegate () {
            Debug.Log("Switch to interface scene");
            // currentActiveScene.SetActive(false);
            // currentActiveScene = deductionTileScene;
            deductionScene.SetActive(true);
            deductionTileScene.SetActive(true);
            evidenceScene.SetActive(false);
            sceneScene.SetActive(false);
        };
        toSceneDelegate = delegate () {
            Debug.Log("Switch to scene scene");
            // currentActiveScene.SetActive(false);
            // currentActiveScene = sceneScene;
            // currentActiveScene.SetActive(true);
            deductionScene.SetActive(false);
            deductionTileScene.SetActive(false);
            evidenceScene.SetActive(false);
            sceneScene.SetActive(true);
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
