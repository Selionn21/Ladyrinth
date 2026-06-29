using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class FadeInUI : MonoBehaviour
{

    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private CanvasGroup canvasG;
    [SerializeField] private Coroutine currentCr;



    private void Awake()
    {
        canvasG = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        if (currentCr != null) StopCoroutine(currentCr);

        currentCr = StartCoroutine(StartFade());
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


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentCr != null) StopCoroutine(currentCr);

            currentCr = StartCoroutine(StartFadeOut());
        }
    }


}
