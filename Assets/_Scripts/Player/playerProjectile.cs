using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private Animator projAnim;
    public float _speed;
    private Vector2 direction;

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
        if (collision.gameObject.tag == "Enemy")
        {
            projAnim.Play("collision", 0 ,0.25f);
            Destroy(this.gameObject, 0.25f);        
        }
    }

}
