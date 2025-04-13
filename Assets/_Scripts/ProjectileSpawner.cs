using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    enum SpawnerType {Straight, Spin}

    [Header("Projectile Attributes")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float bulletLife;
    [SerializeField] private float speed;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private float rotationSpeed = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);
        if(timer >= firingRate)
        {
            Fire();
            timer = 0f;
        }
        
        
    }

    private void Fire()
    {
        if(projectile)
        {
            spawnedBullet = Instantiate(projectile, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Projectile>().speed = speed;
            spawnedBullet.GetComponent<Projectile>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }



}
