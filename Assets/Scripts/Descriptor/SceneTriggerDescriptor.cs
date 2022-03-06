using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneTriggerDescriptor : MonoBehaviour
{
    // ObjectDescriptor objectDescriptor;
    public GameObject targetScene;
    SceneDescriptor targetSceneDescriptor;

    // Start is called before the first frame update
    void Start()
    {
        // objectDescriptor = gameObject.GetComponent<ObjectDescriptor>();
        // Assert.IsNotNull(objectDescriptor);
        targetSceneDescriptor = targetScene.GetComponent<SceneDescriptor>();
        // objectDescriptor.onClick += targetSceneDescriptor.EnterScene;
        gameObject.GetComponent<ClickDescriptor>().onClick += targetSceneDescriptor.EnterScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
