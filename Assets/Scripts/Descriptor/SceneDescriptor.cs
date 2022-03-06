using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneDescriptor : MonoBehaviour
{

    // [HideInInspector]
    // public ObjectDescriptor objectDescriptor;

    public GameObject motherSceneObject;
    [HideInInspector] public SceneDescriptor motherScene;
    // public int sceneId;
    public GameObject leftSceneObject;
    public GameObject rightSceneObject;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        // objectDescriptor = gameObject.GetComponent<ObjectDescriptor>();
        // Assert.IsNotNull(objectDescriptor);
        motherScene = motherSceneObject.GetComponent<SceneDescriptor>();
        // objectDescriptor.curItem.sceneObject[sceneId] = gameObject;
        // Assert.IsNotNull(motherScene);
        Debug.Log("Start Scene: " + name);
    }

    void Update() {
        if (SceneData.curScene() != this) {
            gameObject.SetActive(false);
        }
    }
    
    public bool isChild(SceneDescriptor sceneDescriptor) {
        SceneDescriptor curScene = motherScene;
        while (curScene != null) {
            if (curScene == sceneDescriptor) {
                return true;
            }
            curScene = curScene.motherScene;
        }
        return false;
    }

    public void ToLeftScene() {
        // Dictionary<int, GameObject> id2sceneObject = objectDescriptor.curItem.sceneObject;
        // int targetId = sceneId - 1;
        // if (!id2sceneObject.ContainsKey(targetId)) {
            // targetId += id2sceneObject.Count;
        // }
        if (leftSceneObject == null) {
            return;
        }
        SceneData.moveToScene(leftSceneObject.GetComponent<SceneDescriptor>());
        //Debug.Log(id2sceneObject[targetId].name);
        // SceneData.currentScene.SetActive(false);
        gameObject.SetActive(false);
        leftSceneObject.SetActive(true);
        // id2sceneObject[targetId].SetActive(true);
        SceneData.currentScene = leftSceneObject;
    }

    public void ToRightScene() {
        // Dictionary<int, GameObject> id2sceneObject = objectDescriptor.curItem.sceneObject;
        // int targetId = sceneId + 1;
        // if (!id2sceneObject.ContainsKey(targetId)) {
        //     targetId -= id2sceneObject.Count;
        // }
        if (rightSceneObject == null) {
            return;
        }
        SceneData.moveToScene(rightSceneObject.GetComponent<SceneDescriptor>());
        //Debug.Log(id2sceneObject[targetId].name);
        // SceneData.currentScene.SetActive(false);
        // id2sceneObject[targetId].SetActive(true);
        gameObject.SetActive(false);
        rightSceneObject.SetActive(true);
        // SceneData.currentScene = id2sceneObject[targetId];
        SceneData.currentScene = rightSceneObject;
    }

    public void EnterScene() {
        // Assert.IsNotNull(objectDescriptor);
        // Assert.IsNotNull(objectDescriptor.curItem);
        SceneDescriptor prevScene = SceneData.moveToScene(this);
        //prevScene.gameObject.SetActive(false);
        SceneData.currentScene.SetActive(false);
        gameObject.SetActive(true);
        SceneData.currentScene = gameObject;
    }

    public void ExitScene() {
        SceneDescriptor newScene = SceneData.backToPreviousScene();
        if (newScene != this) {
            // gameObject.SetActive(false);
            SceneData.currentScene.SetActive(false);
            newScene.gameObject.SetActive(true);
            SceneData.currentScene = newScene.gameObject;
        }
    }
}
