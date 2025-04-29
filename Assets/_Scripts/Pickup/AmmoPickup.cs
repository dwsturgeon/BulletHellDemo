using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoValue = 50;
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
        if (collision.gameObject.tag == "Player")
        {
            if (!usedPickup)
            {
                collision.GetComponent<Ammo>().AddAmmo(ammoValue); //if its null it will break
                pickupColor.a = 0.2f;
                sr.color = pickupColor;
                usedPickup = true;
                Destroy(this.gameObject, 2f);
            }
        }
    }
}
