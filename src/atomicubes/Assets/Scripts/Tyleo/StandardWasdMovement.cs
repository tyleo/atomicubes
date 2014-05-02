using UnityEngine;

namespace Tyleo
{
    public sealed class StandardWasdMovement :
        MonoBehaviour
    {
        [SerializeField]
        private float _metersPerSecond = +1.0f;
        [SerializeField]
        private float _degreesPerSecond = +45.0f;

        private CharacterController _characterController;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            HandleVerticalMovement();
            HandleHorizontalMovement();
        }

        private void HandleVerticalMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _characterController.Move(+_metersPerSecond * transform.forward * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _characterController.Move(-_metersPerSecond * transform.forward * Time.fixedDeltaTime);
            }
        }

        private void HandleHorizontalMovement()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -_degreesPerSecond * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, +_degreesPerSecond * Time.fixedDeltaTime);
            }
        }
    }
}
