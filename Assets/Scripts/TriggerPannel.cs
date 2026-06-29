using UnityEngine;

public class TriggerPannel : MonoBehaviour
{
    [SerializeField] private GameObject pannel;
    [SerializeField] private FadeInUI fade;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        fade.FadeOut();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (!collision.CompareTag("Player")) return;
        pannel.SetActive(true);
        fade.FadeIn();
    }
    public void DesactivatePannel() 
    {
        pannel.SetActive(false);
    }
}
