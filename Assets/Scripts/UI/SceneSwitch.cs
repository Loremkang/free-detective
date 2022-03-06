using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public SceneDescriptor sceneDescriptor;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        //SceneData.moveToScene(sceneDescriptor);
        sceneDescriptor.EnterScene();
        Data.uiData.AnalyzeUIActive = false;
    }
}
