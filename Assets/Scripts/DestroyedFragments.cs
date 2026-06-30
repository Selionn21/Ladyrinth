using UnityEngine;
using System.Collections;

public class DestroyedFragments : MonoBehaviour
{
    private Color started = Color.white;
    private Color target = new Color(1,1,1,0);
    [SerializeField] private float time;
    [SerializeField] private SpriteRenderer sprite;
    private void OnEnable()
    {
        Invoke(nameof(DestroyFragments),1f);
    }
    private void DestroyFragments() 
    {
        StartCoroutine(SlowDestroying());
    }
    private IEnumerator SlowDestroying()
    {
        float t = 0f;
        Vector3 startedScale = transform.localScale;
        while (t < 1f)
        {
            t += Time.deltaTime / time;
            t = Mathf.Clamp01(t);
            sprite.color = Color.Lerp(started, target, t);
            transform.localScale = Vector3.Lerp(startedScale, Vector3.zero, t);

            yield return null;
        }
        sprite.color = target;
        transform.localScale = Vector3.zero;
    }
}
