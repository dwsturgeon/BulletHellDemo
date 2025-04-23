using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private Animator projAnim;
    public float _speed;
    public float _bulletDamage = 20;
    private Vector2 direction;


    public static PlayerProjectile instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {

        Destroy(this.gameObject, 10f);
    }

    private void Update()
    {
        transform.position += (Vector3)(direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       //Manipulating health bars
       GameObject enemy = collision.gameObject;
       if(enemy.tag == "Enemy")
        {
            Slider healthBar = enemy.GetComponentInChildren<Slider>();
            if ((healthBar.value - _bulletDamage) <= 0)
            {
                Destroy(enemy);
            }
            else
            {
                healthBar.value = healthBar.value - _bulletDamage;
            }
        }

        projAnim.Play("collision", 0, 0f);
        Destroy(this.gameObject, 0.1f);
    }

}
