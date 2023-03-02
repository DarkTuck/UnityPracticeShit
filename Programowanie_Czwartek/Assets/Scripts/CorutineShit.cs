using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CorutineShit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    LECoding leCoding;
    private void Awake()
    {
        leCoding = new LECoding();
    }
    private void OnEnable()
    {
        leCoding.Player.Jump.performed += ShittyTest;
        leCoding.Player.Enable();
    }
    private void OnDisable()
    {
        leCoding.Player.Jump.performed -= ShittyTest;
        leCoding.Player.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShittyTest(InputAction.CallbackContext callback)
    {
        StartCoroutine(DelayedDebug(3, 3,true));
    }
    IEnumerator DelayedDebug(float delay,string masage,bool writeOnScreen=false)
    {
        if (writeOnScreen != true)
        {
            for (float lowerDelay = delay; lowerDelay > 0; lowerDelay--)
            {
                yield return new WaitForSeconds(lowerDelay);
                Debug.Log($@"{masage} time left {lowerDelay}s starting time {delay}s");
            }
        }
        if (writeOnScreen == true)
        {                                                                                                                  
            for (float lowerDelay = delay; lowerDelay > 0; lowerDelay--)
            {
                yield return new WaitForSeconds(lowerDelay);
               text.text=$@"{masage} time left {lowerDelay}s starting time {delay}s";
            }
        }
    }
    IEnumerator DelayedDebug(float delay, int masage, bool writeOnScreen = false)
    {
        if (writeOnScreen != true)
        {
            for (float lowerDelay = masage; lowerDelay > 0; lowerDelay--)
            {
                yield return new WaitForSeconds(delay);
                Debug.Log($@"current number {lowerDelay} starting from {masage} writting every {delay}s");
            }
        }
        if (writeOnScreen == true)
        {
            for (float lowerDelay = masage; lowerDelay > 0; lowerDelay--)
            {
                yield return new WaitForSeconds(delay);
                text.text=$@"current number {lowerDelay} starting from {masage} writting every {delay}s";
            }
        }
    }

}
