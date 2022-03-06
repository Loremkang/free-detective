using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeductionTile : MonoBehaviour
{
    public DeductionTile sourceDeductionTile; // used in analyzer
    public string description;
    private Animator animator;
    public bool _Selected = false;
    public int selectedPosition;
    public bool Selected {
        get {
            return _Selected;
        }
        set {
            _Selected = value;
            if (animator != null) {
                animator.SetBool("Highlighted", value);
            }
        }
    }
    public Text nameText;
    public Text descriptionText;
    public int level;
    // Start is called before the first frame update

    void Start()
    {
        Transform baseTransform = transform.GetChild(0);
        animator = baseTransform.GetChild(0).GetComponent<Animator>();
        // nameText = baseTransform.GetChild(2).GetComponent<Text>();
        // descriptionText = baseTransform.GetChild(3).GetComponent<Text>();
        Selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setContent(int level_, string name_, string description_) {
        name = name_;
        description = description_;
        level = level_;
        nameText.text = name_;
        descriptionText.text = description_;
    }

    private void OnMouseDown() {
        if (Selected) {
            Selected = false;
            Data.uiData.analyzeController.removeDeduction(selectedPosition);
        } else {
            Selected = Data.uiData.analyzeController.AddDeduction(this, out selectedPosition);
        }
    }
}
