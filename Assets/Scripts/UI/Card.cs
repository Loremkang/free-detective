using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card sourceCard; // used in analyzer
    public CardDetail cardDetail;
    public Evidence evidence;
    Image image;
    public CardShowDetailButton cardShowDetailButton;
    public int level;
    public enum CardType {
        evidences,
        objects
    };
    public CardType type;
    public bool selected = false;
    int selectedPosition;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame

    public void loadImage(int level_, string name_, CardType cardType) {
        image = gameObject.GetComponent<Image>();
        level = level_;
        name = name_;
        string path;
        switch (type) {
            case CardType.evidences:
                path = "cards/EP" + (level + 1).ToString() + "/" + name;
                break;
            case CardType.objects:
                path = "cards/objects/" + name;
                break;
            default:
                throw new System.Exception("Unknown Card Type");
        }
        Debug.Log(path);
        Sprite sprite = Resources.Load<Sprite>(path);
        image.sprite = sprite;
        if (evidence != null && (evidence.descriptionInCardDetail == null || evidence.descriptionInCardDetail == "")) {
            cardShowDetailButton.NoDetailInfo();
        }
        // cardShowDetailButton.card = this;
    }

    public void showDetail() {
        cardDetail.gameObject.SetActive(true);
        cardDetail.setCardDetail(image.sprite, evidence.descriptionInCardDetail);
    }
    
    private void OnMouseDown() {
        if (selected) {
            selected = false;
            Data.uiData.analyzeController.removeCard(selectedPosition);
        } else {
            selected = Data.uiData.analyzeController.AddCard(this, out selectedPosition);
        }
    }
}
