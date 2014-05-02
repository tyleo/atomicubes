using UnityEngine;

namespace Tyleo
{
    public sealed class SpaceToJump :
        MonoBehaviour
    {
        private const float COLLISION_TOLERANCE = 0.09f;

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
                    _isGrounded = false;
                }
                else if (Input.GetKey(KeyCode.Space))
                {
                    _isGrounded = false;
                    _characterController.Move(transform.up * COLLISION_TOLERANCE);
                    _jumpAndGravityVelocity += transform.up * _initialJumpSpeed;
                }
            }
            else
            {
                if (IsHittingGround())
                {
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
