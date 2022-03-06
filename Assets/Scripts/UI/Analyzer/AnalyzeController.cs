using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzeController : MonoBehaviour
{
    public Evidence[] evidence;
    public GameObject[] cardsObject;
    public GameObject[] deductionTileObject;
    public GameObject AnalyzeObject;
    public GameObject ClearObject;
    
    public GameObject analyzeAnimation;
    public GameObject resultBox;
    public float waitForAnalyzeAnimation = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddCard(Card card, out int pos) {
        for (int i = 0; i < cardsObject.Length; i ++) {
            GameObject gameObject = cardsObject[i];
            if (gameObject.activeSelf == false) {
                Card targetCard = gameObject.GetComponent<Card>();
                targetCard.loadImage(card.level, card.name, card.type);
                targetCard.sourceCard = card;
                gameObject.SetActive(true);
                pos = i;
                return true;
            }
        }
        pos = 0;
        return false;
    }

    public void removeCard(int pos) {
        cardsObject[pos].SetActive(false);
    }
    
    public bool AddDeduction(DeductionTile deductionTile, out int pos) {
        for (int i = 0; i < cardsObject.Length; i ++) {
            GameObject gameObject = deductionTileObject[i];
            if (gameObject.activeSelf == false) {
                DeductionTile targetDeductionTile = gameObject.GetComponent<DeductionTile>();
                targetDeductionTile.setContent(deductionTile.level, deductionTile.name, deductionTile.description);
                targetDeductionTile.Selected = true;
                targetDeductionTile.sourceDeductionTile = deductionTile;
                gameObject.SetActive(true);
                pos = i;
                return true;
            }
        }
        pos = 0;
        return false;
    }

    public void removeDeduction(int pos) {
        deductionTileObject[pos].SetActive(false);
    }

    public void Analyze() {
        Debug.Log("Analyze Controller: Analyze");
        List<string> info = new List<string>();
        for (int i = 0; i < cardsObject.Length; i ++) {
            GameObject gameObject = cardsObject[i];
            if (gameObject.activeSelf == true) {
                Card card = gameObject.GetComponent<Card>();
                info.Add(card.name);
            }
        }
        for (int i = 0; i < deductionTileObject.Length; i ++) {
            GameObject gameObject = deductionTileObject[i];
            if (gameObject.activeSelf == true) {
                DeductionTile deductionTile = gameObject.GetComponent<DeductionTile>();
                info.Add(deductionTile.name);
            }
        }

        foreach (string str in info) {
            Debug.Log(str);
        }

        foreach (Deduction deduction in Data.globalDeductionMap[Data.uiData.CurrentLevel].Values) {
            Debug.Log(deduction.tostr());
            if (deduction.CheckDeduction(info.ToArray())) {
                Debug.Log("Get Deduction: " + deduction.name);
                if (!Data.obtainedDeduction[Data.uiData.currentLevel].Contains(deduction.name)) {
                    Data.obtainedDeduction[Data.uiData.currentLevel].Add(deduction.name);
                    Data.uiData.deductionTileController.AddDeductionTile(deduction);
                    StartCoroutine(AnalyzeAnimationControl(deduction.name, deduction.description));
                }
            }
        }
    }

    IEnumerator AnalyzeAnimationControl(string name, string description) {
        analyzeAnimation.SetActive(true);
        yield return new WaitForSeconds(waitForAnalyzeAnimation);
        analyzeAnimation.SetActive(false);
        resultBox.SetActive(true);
        resultBox.GetComponent<ResultController>().setContent(name, description);
        yield return null;
    }

    public void Clear() {
        Debug.Log("Analyze Controller: Clear");
        foreach (GameObject gameObject in cardsObject) {
            gameObject.SetActive(false);
            if (gameObject.GetComponent<Card>().sourceCard != null) {
                gameObject.GetComponent<Card>().sourceCard.selected = false;
            }
            
        }
        foreach (GameObject gameObject in deductionTileObject) {
            gameObject.SetActive(false);
            if (gameObject.GetComponent<DeductionTile>().sourceDeductionTile != null) {
                gameObject.GetComponent<DeductionTile>().sourceDeductionTile.Selected = false;
            }
        }
    }
}
