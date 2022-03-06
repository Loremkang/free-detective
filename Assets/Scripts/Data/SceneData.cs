using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;

public class SceneData : MonoBehaviour
{
    public static Stack<SceneDescriptor> sceneStack;
    public static GameObject currentScene;
    public GameObject showCurScene;
    // public string[] defaultScene;
    public GameObject defaultScene;
    public GameObject[] initScenes;
    

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject scene in initScenes) {
            // Debug.Log(scene.name);
            scene.SetActive(true);
            // scene.SetActive(false);
        }
        sceneStack = new Stack<SceneDescriptor>();
        // Item defaultItem = ObjectDescriptor.buildItem(defaultScene);
        sceneStack.Push(defaultScene.GetComponent<SceneDescriptor>());
        currentScene = defaultScene;
        Data.uiData.sceneSwitchController.insertScene(0, defaultScene.GetComponent<SceneDescriptor>());
        //visitedScene[defaultScene.GetComponent<SceneDescriptor>()] = true;


        // SwipeController.upSwipe += curScene().ExitScene;

        // SceneDescriptor sceneDes = defaultScene.GetComponent<SceneDescriptor>();
        // sceneDes.EnterScene();
    }

    // return previous scene
    public static SceneDescriptor moveToScene(SceneDescriptor targetSceneDescriptor) {
        Assert.AreNotEqual(sceneStack.Count, 0);
        // SceneDescriptor sceneDescriptor = curScene();
        // Item ret = curScene();
        while (sceneStack.Count != 0 && !targetSceneDescriptor.isChild(curScene())) {
            sceneStack.Pop();
        }
        if (sceneStack.Count == 0 || sceneStack.Peek() != targetSceneDescriptor) {
            sceneStack.Push(targetSceneDescriptor);
        }
        // visitedScene[targetSceneDescriptor] = true;
        Data.uiData.sceneSwitchController.insertScene(targetSceneDescriptor.level, targetSceneDescriptor);
        return curScene();
    }

    public static SceneDescriptor backToPreviousScene() {
        //Assert.IsTrue(sceneStack.Count >= 2);
        if (sceneStack.Count >= 2) { // Root Objects are invisible objects
            sceneStack.Pop();
        }
        return curScene();
    }

    public static SceneDescriptor curScene() {
        return sceneStack.Peek();
    }

    // Update is called once per frame
    void Update()
    {
        showCurScene = currentScene;
    }
}
