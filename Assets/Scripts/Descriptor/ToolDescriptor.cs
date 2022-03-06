using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDescriptor : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ClickDescriptor>().onClick += getObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getObject() {
        Data.obtainedEvidence[level].Add(name);
        Debug.Log("Discover Item: " + name);
        Data.uiData.cardController.AddCard(level, name);
    }
}
