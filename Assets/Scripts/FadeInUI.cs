using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class FadeInUI : MonoBehaviour
{

    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private CanvasGroup canvasG;
    [SerializeField] private Coroutine currentCr;

    [SerializeField] private TriggerPannel triggerPannel;

    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
    }
    public void FadeIn() 
    {
        if (currentCr == null)
            currentCr = StartCoroutine(StartFade());
        else
        {
            StopAllCoroutines();
            currentCr = StartCoroutine(StartFade());
        }
    }
    public void FadeOut()
    {
        if (currentCr == null)
            currentCr = StartCoroutine(StartFadeOut());
        else 
        {
            StopAllCoroutines();
            currentCr = StartCoroutine(StartFadeOut());
        }
    }
    IEnumerator StartFade()
    {
        canvasG.alpha = 0f;
        float time = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;
            canvasG.alpha = Mathf.Clamp01(time / fadeTime);
            yield return null;
        }
    }
    IEnumerator StartFadeOut()
    {
        float initAlpha = canvasG.alpha;
        float time = 0f;
        while (time < fadeTime)
        {
            time += Time.deltaTime;
            canvasG.alpha = Mathf.Clamp01(initAlpha * (1f - (time / fadeTime)));
            yield return null;
        }        
    }
}
