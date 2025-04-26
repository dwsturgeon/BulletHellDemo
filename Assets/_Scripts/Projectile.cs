using TopDown.Movement;
using Unity.Hierarchy;
using UnityEngine.UI;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int bulletDamage = 20;

    private GameObject[] enemies;
    private GameObject enemy;

    public static Projectile instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //loop through enemies to remove collision
        for (int i = 0; i < enemies.Length; i++) 
        {
            enemy = enemies[i];
            

            /*remove collision for game objects with tag Enemy and custom tag Chopper only
            if(enemy.GetComponent<CustomTag>().HasTag("Chopper"))
            {
                if (enemy.GetComponent<CircleCollider2D>() != null)
                {*/
                    Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), enemies[i].GetComponent<CapsuleCollider2D>(), true);
                /*}
            }*/
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
        if (collision == null) return;

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
        //For enemies that get affected by projectile
        if (collision.gameObject.tag == "Enemy")
        {
            
            Slider healthBar = collision.gameObject.GetComponentInChildren<Slider>();

            if ((healthBar.value - bulletDamage) <=0 )
            {
                Destroy(collision.gameObject);
            }
            else
            {
                healthBar.value = healthBar.value - bulletDamage;
            }
            
        }

        Destroy(this.gameObject);
    }
}
