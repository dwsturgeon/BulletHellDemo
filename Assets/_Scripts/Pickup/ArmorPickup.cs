using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    [SerializeField] private float armorValue = 25f;
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
                collision.GetComponent<Armor>().AddArmor(armorValue); //if its null it will break
                pickupColor.a = 0.2f;
                sr.color = pickupColor;
                usedPickup = true;
                Destroy(this.gameObject, 2f);
            }
        }
    }
}
