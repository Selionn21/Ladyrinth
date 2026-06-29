using TMPro;
using UnityEngine;

public class Recollection : MonoBehaviour
{

    [Header("Recoletables")]
    [SerializeField] private int moon;
    [SerializeField] private int star;
    [SerializeField] private int cloud;

    [Header("Cantidades")]
    [SerializeField] private TextMeshProUGUI moonQ;
    [SerializeField] private TextMeshProUGUI starQ;
    [SerializeField] private TextMeshProUGUI cloudQ;


    [Header("Verificadores")]
    [HideInInspector] public bool hasMoon;
    [HideInInspector] public bool hasStar;
    [HideInInspector] public bool hasCloud;


    [SerializeField] private GameObject puzzlepanel;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        moonQ.text = moon.ToString();
        starQ.text = star.ToString();
        cloudQ.text = cloud.ToString();

    }

    private void CollectItem(string figura)
    {
        switch (figura)
        {
            case "moon": hasMoon = true; moon += 1; 
                break;
            case "star": hasStar = true; star += 1;  
                break;
            case "cloud": hasCloud = true; cloud += 1;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "moon" || collision.gameObject.name == "star" || collision.gameObject.name == "cloud")
        {
            CollectItem(collision.gameObject.name);
        }

       
        
    }

}
