using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TopDown.Movement
{
    public class PlayerRotation : Rotator
    {
        private void OnLook(InputValue value)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint( value.Get<Vector2>());
            LookAt( mousePosition );
        }
    }
}