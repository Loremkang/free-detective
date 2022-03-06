using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public Text title;
    public Text description;
    public float waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setContent(string name_, string description_) {
        name = name_;
        StartCoroutine(setText(name_, description_));
    }

    IEnumerator setText(string name_, string description_) {
        title.text = name_;
        description.text = description_;
        yield return new WaitForSeconds(waitTime);
        title.gameObject.SetActive(true);
        description.gameObject.SetActive(true);
        yield return null;
    }

    private void OnMouseDown() {
        gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
    }
}
