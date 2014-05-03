using UnityEngine;

namespace Tyleo
{
    public sealed class ParametricMoveOtherOnCollision :
        MonoBehaviour
    {
        [SerializeField]
        private ParametricBackForthMovement _parametricBackForthMovement;

        private void OnTriggerEnter(Collider collider)
        {
            _parametricBackForthMovement.BeginMovingForwards();
        }

        private void OnTriggerExit(Collider collider)
        {
            _parametricBackForthMovement.BeginMovingBackwards();
        }
    }
}
