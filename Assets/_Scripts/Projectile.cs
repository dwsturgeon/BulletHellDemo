using TopDown.Movement;
using Unity.Hierarchy;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private GameObject[] enemies;
    private GameObject enemy;

    private void Start()
    {
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //loop through enemies to remove collision
        for (int i = 0; i < enemies.Length; i++) 
        {
            enemy = enemies[i];

            //just in case we forget to add the component to an enemy;
            CustomTag enemyTagComponent = enemy.GetComponent<CustomTag>();
            if (enemyTagComponent == null)
            {
                Debug.LogWarning("Add CustomTag component or remove Enemy tag for " + enemy);
                continue;
            }



            //remove collision for game objects with tag Enemy and custom tag Chopper only
            if (enemy.GetComponent<CustomTag>().HasTag("Chopper"))
            {
                if (enemy.GetComponent<CircleCollider2D>() != null)
                {
                    Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), enemies[i].GetComponent<CapsuleCollider2D>(), true);
                }
            }
        }
    }
    private void Update()
    { 
        MoveProjectile();
    }
    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    public void UpdateMoveSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    //kill on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
        //For enemies that get affected by projectile
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
