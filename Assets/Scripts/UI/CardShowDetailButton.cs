using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShowDetailButton : MonoBehaviour
{
    public Card card;
    public Sprite emptySprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        card.showDetail();
    }
    
    public void NoDetailInfo() {
        GetComponent<Image>().sprite = emptySprite;
    }
}
