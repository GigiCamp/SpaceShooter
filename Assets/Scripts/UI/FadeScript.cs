using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    float gameStart;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        gameStart = Time.time;
    }

    private void Update()
    {
        if(Time.time - gameStart > 300)
        {

        }
    }

    private void OnEnable()
    {
        Fade(true);
    }

    public void Fade(bool fadeIn)
    {
        float startValue = canvasGroup.alpha;
        float endValue = (fadeIn) ? 1 : 0;

        StartCoroutine(FadeCoroutine(fadeIn, endValue));
    }
    
    private IEnumerator FadeCoroutine(bool fadeIn, float endValue)
    {
        while(canvasGroup.alpha != endValue)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, endValue, Time.unscaledDeltaTime * 2);
            yield return null;
        }

        if(fadeIn == false)
        {
            gameObject.SetActive(false);
        }
    }
}
