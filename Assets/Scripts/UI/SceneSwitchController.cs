using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSwitchController : MonoBehaviour
{
    public HashSet<string>[] visitedScene;
    public GameObject scenePrefab;
    public GameObject scenePool;

    // Start is called before the first frame update
    void Start()
    {
        // Data.uiData.sceneSwitchController = this;
        if (visitedScene == null) {
            init();
        }
    }

    private void init() {
        visitedScene = new HashSet<string>[Const.levels];
        for (int i = 0; i < Const.levels; i ++) {
            visitedScene[i] = new HashSet<string>();
        }
    }

    public bool insertScene(int level, SceneDescriptor sceneDescriptor) {
        if (visitedScene == null) {
            init();
        }
        if (visitedScene[level].Contains(sceneDescriptor.name)) {
            return false;
        }
        Debug.Log("Enter Scene For First Time: " + sceneDescriptor.name);
        GameObject gameObject = Instantiate(scenePrefab, scenePool.transform);
        //Image targetImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        //targetImage.sprite = sceneDescriptor.transform.GetChild(0).GetComponent<Sprite>();
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sceneDescriptor.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        // Debug.Log(sceneDescriptor.transform.GetChild(0).GetComponent<SpriteRenderer>());
        gameObject.GetComponent<SceneSwitch>().sceneDescriptor = sceneDescriptor;
        gameObject.GetComponent<SceneSwitch>().level = level;
        gameObject.name = sceneDescriptor.name;
        visitedScene[level].Add(sceneDescriptor.name);
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
