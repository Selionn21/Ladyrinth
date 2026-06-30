using System;
using UnityEngine;

public class BoxScripts : MonoBehaviour
{
    [SerializeField] private GameObject destroyedBox;
    public void Break()
    {
        GameObject broken = Instantiate(destroyedBox, transform.position, transform.rotation);

        foreach (Rigidbody2D rb in broken.GetComponentsInChildren<Rigidbody2D>())
        {
            rb.AddForce(UnityEngine.Random.insideUnitCircle * 5f, ForceMode2D.Impulse);
            rb.AddTorque(UnityEngine.Random.Range(-200f, 200f));
        }

        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AttackPlayer"))
        {
            Debug.Log("Detecta colision");
            Break();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackPlayer"))
        {
            Debug.Log("Detecta colision");
            Break();
        }
    }
}
