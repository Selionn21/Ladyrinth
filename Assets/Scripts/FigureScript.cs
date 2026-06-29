using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class FigureScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private bool onMouse;
    [SerializeField] private bool cantSelect;
    [SerializeField] private float time;
    private Vector2 offset;
    private Coroutine coroutine;

    private void Start()
    {
        cantSelect = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (cantSelect) return;
        onMouse = true;
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = transform.position.z;
        offset = transform.position - MousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (cantSelect) return;
        onMouse = false;
    }
    private void Update()
    {
        if (targetPos == null) return;

        if (Vector2.Distance(transform.position, targetPos.position) < 1f) 
        {
            cantSelect = true;
            onMouse = false;
            ActivateCoroutine();
        }
        if (onMouse)
        {
            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = transform.position.z;

            transform.position = (Vector2)MousePosition + offset;
        }
    }
    private void ActivateCoroutine() 
    {
        if (coroutine == null)
            coroutine = StartCoroutine(SetBlockToFinalPosition());
    }
    private IEnumerator SetBlockToFinalPosition() 
    {
        Vector2 startPos = transform.position;
        float t = 0f;

        while (t < 1f) 
        {
            t += Time.deltaTime / time;
            t = Mathf.Clamp01(t);
            transform.position = Vector2.Lerp(startPos, targetPos.position, t);
            yield return null;
        }
        transform.position = targetPos.position;
    }
}
