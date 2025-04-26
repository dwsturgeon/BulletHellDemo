using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField] float startingArmor = 100f;
    private float currentArmor;

    private void Awake()
    {
        currentArmor = startingArmor;
    }

    public void TakeArmorDamage(float _damage)
    {
        currentArmor = Mathf.Clamp(currentArmor - (_damage * 0.10f), 0, startingArmor);

        if (currentArmor < 0)
        {
            //remove armor?
        }

    }

    public void AddArmor(float _armor)
    {
        currentArmor = Mathf.Clamp(currentArmor + _armor, 0, startingArmor);
    }
}
