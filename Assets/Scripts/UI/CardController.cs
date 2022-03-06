using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject cardPool;
    public CardDetail cardDetail;
    //public int currentLevel = 0;

    private void Start() {
        // Data.uiData.cardController = this;
    }

    public void AddCard(int level_, string name_) {
        GameObject gameObject = Instantiate(cardPrefab, cardPool.transform);
        Card card = gameObject.GetComponent<Card>();
        card.evidence = Data.globalEvidenceMap[level_][name_];
        card.cardDetail = cardDetail;
        card.loadImage(level_, name_, Card.CardType.evidences);
    }

    public void SwitchToLevel(int targetLevel) {
        for (int i = 0; i < cardPool.transform.childCount; i ++) {
            GameObject gameObject = cardPool.transform.GetChild(i).gameObject;
            Card card = gameObject.GetComponent<Card>();
            if (card.level == targetLevel) {
                gameObject.SetActive(true);
            } else {
                gameObject.SetActive(false);
            }
        }
    }
}
