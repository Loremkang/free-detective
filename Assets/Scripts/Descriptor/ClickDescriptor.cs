using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDescriptor : MonoBehaviour
{
    public delegate void Delegate();
    public GameObject clickAudio;
    public Delegate onClick = delegate() {};
    public Delegate onLongClick = delegate() {};

    // Start is called before the first frame update
    void Start()
    {
        // ObjectDescriptor objectDescriptor = gameObject.GetComponent<ObjectDescriptor>();
        // if (objectDescriptor != null) {
        //     onLongClick += objectDescriptor.Discover;
        //     Debug.Log(gameObject.name);
        // }
        EvidenceDescriptor evidenceDescriptor = gameObject.GetComponent<EvidenceDescriptor>();
        if (evidenceDescriptor != null) {
            onLongClick += evidenceDescriptor.Discover;
            Debug.Log(gameObject.name);
        }
        //clickAudio = GameObject.Find("ClickSound");
        clickAudio = GameObject.Find("ZoomSound");
        onLongClick += delegate() {
            clickAudio.GetComponent<AudioSource>().Play();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool tryToClick = false;
    public float clickTime;

    public void OnMouseDown() {
        clickTime = Time.time;
        tryToClick = true;
    }

    private void OnMouseUp() {
        if (tryToClick) {
            if (Time.time - clickTime < Const.longClickTime) {
                if (!Data.uiData.disableAllAction) {
                    onClick();
                    onLongClick();
                }
                
            } else {
                if (!Data.uiData.disableAllAction) {
                    // onLongClick();
                    // onClick();
                }
            }
        }
    }

    private void OnMouseExit() {
        tryToClick = false;
    }
}
