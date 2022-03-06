using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class DiscoveryController : MonoBehaviour
{
    public float waitTime = 1.0f;
    public float textDelayTime = 0.5f;
    public float moveTime = Const.cameraMoveTime;
    GameObject mask;
    Animator maskAnim;
    GameObject focus;
    Animator focusAnim;
    GameObject textBox;
    Animator textBoxAnim;
    GameObject texts;
    Text textField;

    // Start is called before the first frame update
    void Start()
    {
        Data.discoveryController = this;
        mask = transform.GetChild(0).gameObject;
        focus = transform.GetChild(1).gameObject;
        textBox = transform.GetChild(2).gameObject;
        texts = transform.GetChild(3).gameObject;
        maskAnim = mask.GetComponent<Animator>();
        focusAnim = focus.GetComponent<Animator>();
        textBoxAnim = textBox.GetComponent<Animator>();
        textField = texts.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.uiData.inGlassMode) {
            if(Input.GetMouseButtonUp(0)) {
                EndDiscover();
            }
        }
    }

    public void Discover(GameObject gameObject, string description) {
        //DiscoverAnim();
        StartCoroutine(discoverController(gameObject, description));
    }

    IEnumerator discoverController(GameObject gameObject, string description) {
        Data.cameraController.MoveToCatchItem(gameObject.transform.position);
        for (float time = 0.0f; time < Const.cameraMoveTime; time += Time.deltaTime) {
            yield return 0;
        }
        DiscoverAnim();
        Data.uiData.disableAllAction = true;
        for (float time = 0.0f; time < waitTime; time += Time.deltaTime) {
            yield return 0;
        }
        textField.text = description;
    }


    public void EndDiscover() {
        StartCoroutine(endDiscoverController());
    }

    IEnumerator endDiscoverController() {
        endDiscoverAnim();
        for (float time = 0.0f; time < waitTime; time += Time.deltaTime) {
            yield return 0;
        }
        Data.cameraController.MoveBack();
        for (float time = 0.0f; time < Const.cameraMoveTime; time += Time.deltaTime) {
            yield return 0;
        }
        Data.uiData.disableAllAction = false;
        textField.text = "";
    }

    public void DiscoverAnim() {
        // TODO : Check Difference
        maskAnim.SetBool("Has Mask", true);
        focusAnim.SetBool("Glass On", true);
        textBoxAnim.SetBool("Textbox On", true);
        StartCoroutine(showTextDelay());
        Data.uiData.disableSceneAction = true;
        Data.uiData.inGlassMode = true;
    }

    IEnumerator showTextDelay() {
        yield return new WaitForSeconds(textDelayTime);
        texts.SetActive(true);
        yield return null;
    }

    public void endDiscoverAnim() {
        maskAnim.SetBool("Has Mask", false);
        focusAnim.SetBool("Glass On", false);
        textBoxAnim.SetBool("Textbox On", false);
        texts.SetActive(false);
        Data.uiData.disableSceneAction = false;
        Data.uiData.inGlassMode = false;
    }
}
