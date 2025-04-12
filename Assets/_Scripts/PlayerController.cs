using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D playerRB;
    private Vector2 moveInput;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        rotatePlayerTowardsMouse();
    }

    private void PlayerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        playerRB.linearVelocity = moveInput * moveSpeed;
    }

    private void rotatePlayerTowardsMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        //if you are reading this psy, this smooths the rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
    }
}
