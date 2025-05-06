using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject buttonTop;
    bool isPressed;
    public UnityEvent onPress, onRelease;

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            buttonTop.transform.localPosition = new Vector3(0, 0f, 0);
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonTop.transform.localPosition = new Vector3(0, 0.15f, 0);
        onRelease.Invoke();
        isPressed = false;
    }
}
