using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Causes an entity to jump when the space bar is pressed.
    /// </summary>
    public sealed class SpaceToJump :
        MonoBehaviour
    {
        /// <summary>
        /// We raycast to determine when the object is grounded. This requires some tolerance.
        /// </summary>
        private const float COLLISION_TOLERANCE = 0.09f;

        /// <summary>
        /// The initial speed of the jump, applied when the space bar is first pressed.
        /// </summary>
        [SerializeField]
        private float _initialJumpSpeed = 10.0f;

        private bool _isGrounded = true;
        private Vector3 _jumpAndGravityVelocity = Vector3.zero;

        private CharacterController _characterController;
        private float _verticalExtent;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _verticalExtent = collider.bounds.extents.y;
        }

        private void FixedUpdate()
        {
            UpdateJumpState();

            UpdateVelocity();
            UpdatePosition();
        }

        private void UpdateJumpState()
        {
            if (_isGrounded)
            {
                if (!IsHittingGround())
                {
                    // If we were hitting the ground but we aren't any more, were not grounded and
                    // we can't do anything else.
                    _isGrounded = false;
                }
                else if (Input.GetKey(KeyCode.Space))
                {
                    // If we were hitting the ground but space was pressed, we need to jump.
                    _isGrounded = false;
                    _characterController.Move(transform.up * COLLISION_TOLERANCE);
                    _jumpAndGravityVelocity += transform.up * _initialJumpSpeed;
                }
            }
            else
            {
                if (IsHittingGround())
                {
                    // If we weren't hitting the ground but, we are now we can jump next frame.
                    _isGrounded = true;
                    _jumpAndGravityVelocity = Vector3.zero;
                }
            }
        }

        private bool IsHittingGround()
        {
            return Physics.Raycast(transform.position, -transform.up, _verticalExtent + COLLISION_TOLERANCE);
        }

        private void UpdateVelocity()
        {
            if (!_isGrounded)
            {
                if (IsHittingCeiling())
                {
                    _jumpAndGravityVelocity = Vector3.zero;
                }

                _jumpAndGravityVelocity += PhysicsExtended.HalfGravity * Time.fixedDeltaTime;
            }
        }

        private bool IsHittingCeiling()
        {
            return Physics.Raycast(transform.position, transform.up, _verticalExtent + COLLISION_TOLERANCE);
        }

        private void UpdatePosition()
        {
            _characterController.Move(_jumpAndGravityVelocity * Time.fixedDeltaTime);
        }
    }
}
