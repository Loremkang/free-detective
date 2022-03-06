using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetail : MonoBehaviour
{
    public Image imageWithoutText;
    public Image imageWithText;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        // image = transform.GetChild(1).GetComponent<Image>();
        // text = transform.GetChild(2).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        gameObject.SetActive(false);
    }
    public void setCardDetail(Sprite sprite, string description) {
        if (description != null && description != "") {
            imageWithText.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            imageWithoutText.gameObject.SetActive(false);
            imageWithText.sprite = sprite;
            text.text = description;
        } else {
            imageWithText.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            imageWithoutText.gameObject.SetActive(true);
            imageWithoutText.sprite = sprite;
        }
    }
}
