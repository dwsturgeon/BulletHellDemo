using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TopDown.Movement
{
    public class PlayerRotation : Rotator
    {
        [Header("Body and Legs")]
        [SerializeField] private Transform torso;
        [SerializeField] private Transform legs;


        //Mover Reference
        [Header("Mover Reference")]
        [SerializeField] private Movement playerMovement;

        public Transform Torso { get => torso; set => torso = value; }

        private void OnLook(InputValue value)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint( value.Get<Vector2>());
            LookAt( Torso, mousePosition );
        }

        private void Update()
        {
            //rotate legs based on keyboard inputs
            Vector3 legsLookPoint = transform.position + new Vector3(playerMovement.CurrentInput.x, playerMovement.CurrentInput.y);
            LookAt(legs, Vector3.zero);
        }
    }
}