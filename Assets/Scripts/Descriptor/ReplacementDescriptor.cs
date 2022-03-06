using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ReplacementDescriptor : MonoBehaviour {

    public float waitfor = 0.0f;
    public GameObject[] disableObjects;
    public GameObject[] enableObjects;
    public string[] requirements;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<ClickDescriptor>().onClick += Replace;
        gameObject.GetComponent<ClickDescriptor>().onClick += delegate () {
            StartCoroutine(ReplaceWithWait());
        };
        //objectDescriptor = gameObject.GetComponent<ObjectDescriptor>();
        //Assert.IsNotNull(objectDescriptor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReplaceWithWait() {
        yield return new WaitForSeconds(waitfor);
        Replace();
        yield return null;
    }

    public void Replace() {
        foreach (string requirement in requirements) {
            Assert.IsTrue(Data.globalEvidenceMap[Data.curLevel].ContainsKey(requirement));
            if (!Data.obtainedEvidence[Data.curLevel].Contains(requirement)) {
                return;
            }
        }
        foreach (GameObject gameObject in disableObjects) {
            if (gameObject.activeSelf == false) {
                return;
            }
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in enableObjects) {
            gameObject.SetActive(true);
        }
    }
}
