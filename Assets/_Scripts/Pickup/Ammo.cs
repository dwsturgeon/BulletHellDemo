using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int startingAmmo = 120;
    private int currentAmmo;

    private void Awake()
    {
        currentAmmo = startingAmmo;
    }

    public void TakeAmmo(int _count)
    {
        currentAmmo = Mathf.Clamp(currentAmmo - _count, 0, startingAmmo);

        if (currentAmmo < 0)
        {
            //popup on screen?
        }

    }

    public void AddAmmo(int _count)
    {
        currentAmmo = Mathf.Clamp(currentAmmo - _count, 0, startingAmmo);
    }
}
