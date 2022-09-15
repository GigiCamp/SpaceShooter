using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Assignment_11a : MonoBehaviour
{
    public TextMeshProUGUI countdown;
    private float seconds = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        float count = seconds;
        while(count > 0)
        {
            countdown.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

            countdown.text = "GO";
            yield return new WaitForSeconds(1);
            countdown.enabled = false;
        
    }
}
