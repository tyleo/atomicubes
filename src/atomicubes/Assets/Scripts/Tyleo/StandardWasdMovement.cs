using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Allows an entity to be moved using the WSAD keys.
    /// </summary>
    public sealed class StandardWasdMovement :
        MonoBehaviour
    {
        /// <summary>
        /// The speed with which to move the entity.
        /// </summary>
        [SerializeField]
        private float _metersPerSecond = +1.0f;
        /// <summary>
        /// The speed with which to turn the entity.
        /// </summary>
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
