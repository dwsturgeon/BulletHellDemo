using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthValue = 25f;
    private Color pickupColor;
    private SpriteRenderer sr;
    private bool usedPickup = false;

    private void Start()
    {
        pickupColor = GetComponent<SpriteRenderer>().color;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!usedPickup)
            {
                collision.GetComponent<Health>().AddHealth(healthValue);
                pickupColor.a = 0.2f;
                sr.color = pickupColor;    
                usedPickup = true;
                Destroy(this.gameObject, 2f);
            }
        }
    }
}
