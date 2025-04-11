using UnityEngine;

namespace TopDown.Movement
{
    [RequireComponent (typeof (Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        private Rigidbody2D body;
        protected Vector3 currentInput;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            body.linearVelocity = movementSpeed * currentInput * Time.deltaTime;
        }
    }
}

