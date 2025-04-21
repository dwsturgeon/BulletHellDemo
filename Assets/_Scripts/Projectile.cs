using TopDown.Movement;
using Unity.Hierarchy;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
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
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
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
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(this.GetComponent<CapsuleCollider2D>(), enemy.GetComponent<CapsuleCollider2D>(), true);
        }
    }
}
