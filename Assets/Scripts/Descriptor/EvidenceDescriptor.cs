using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EvidenceDescriptor : MonoBehaviour
{
    // public string name;
    public int level;
    // Item item;
    Evidence evidence;

    // Start is called before the first frame update
    void Start() {
        Assert.IsTrue(Data.globalEvidenceMap[level].ContainsKey(name));
        // Assert.IsTrue(Data.globalItemMap[level].ContainsKey(name));
        // item = Data.globalItemMap[level][name];
        evidence = Data.globalEvidenceMap[level][name];
    }

    public void Discover() {

        Debug.Log("Discovering: " + name);
        if (Data.globalEvidenceMap[Data.curLevel][name] == null) {
            return;
        }
        Debug.Log(Data.discoveryController);
        Data.discoveryController.Discover(gameObject, evidence.descriptionInDiscovery);
        // if (Data.obtainedItem[this.level].Contains(item)) {
        //     return;
        // }
        // Data.obtainedItem[this.level].Add(name);
        if (Data.obtainedEvidence[level].Contains(name)) {
            return;
        }
        Data.obtainedEvidence[level].Add(name);
        Debug.Log("Discover Item: " + name);
        Data.uiData.cardController.AddCard(this.level, name);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
