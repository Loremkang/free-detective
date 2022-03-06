using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterfaceSwitch : MonoBehaviour
{
    InterfaceController.SwitchSceneDelegate switchSceneDelegate;
    // Start is called before the first frame update
    void Start()
    {
        InterfaceController interfaceController = transform.GetComponentInParent<InterfaceController>();
        switch (gameObject.name) {
            case "切换到证物":
                switchSceneDelegate = interfaceController.toEvidenceDelegate;
                break;
            case "切换到推论":
                switchSceneDelegate = interfaceController.toInferfaceDelegate;
                break;
            case "切换到地点":
                switchSceneDelegate = interfaceController.toSceneDelegate;
                break;
            default:
                throw new Exception("Unknown interface switch");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        switchSceneDelegate();
    }
}
