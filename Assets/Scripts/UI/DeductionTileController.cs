using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeductionTileController : MonoBehaviour
{
    public string description;
    public GameObject deductionTilePrefab;
    public GameObject deductionTilePool;

    private void Start() {
        // Data.uiData.deductionTileController = this;
    }

    void init() {

    }

    public void AddDeductionTile(Deduction deduction) {
        AddDeductionTile(deduction.level, deduction.name, deduction.description);
    }
    public void AddDeductionTile(int level_, string name_, string description_) {
        GameObject gameObject = Instantiate(deductionTilePrefab, deductionTilePool.transform);
        DeductionTile deductionTile = gameObject.GetComponent<DeductionTile>();
        deductionTile.setContent(level_, name_, description_);
    }

    public void SwitchToLevel(int targetLevel) {
        for (int i = 0; i < deductionTilePool.transform.childCount; i ++) {
            GameObject gameObject = deductionTilePool.transform.GetChild(i).gameObject;
            DeductionTile deductionTile = gameObject.GetComponent<DeductionTile>();
            if (deductionTile.level == targetLevel) {
                gameObject.SetActive(true);
            } else {
                gameObject.SetActive(false);
            }
        }
    }
}
