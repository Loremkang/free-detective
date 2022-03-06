using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDescriptor : MonoBehaviour
{
    public float waitfor = 0.0f;
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ClickDescriptor>().onLongClick += delegate () {
            sound.GetComponent<AudioSource>().Play();
            // try {
            //     StartCoroutine(playSoundWithWait());
            // } catch (System.Exception e) {
            //     sound.GetComponent<AudioSource>().Play();
            // } finally {

            // }
        };
        //sound.GetComponent<AudioSource>().Play;
    }

    IEnumerator playSoundWithWait() {
        yield return new WaitForSeconds(waitfor);
        sound.GetComponent<AudioSource>().Play();
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
