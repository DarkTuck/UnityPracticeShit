using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CountDownCor(5));
            //StartCoroutine(DelayedDebug(2, "Delayed message"));
        }
    }

    IEnumerator DelayedDebug(float delay, string message)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(message);
    }

    IEnumerator CountDownCor(int count)
    {
        countDownText.gameObject.SetActive(true);
        for (int i = count; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countDownText.gameObject.SetActive(false);
    }

}
