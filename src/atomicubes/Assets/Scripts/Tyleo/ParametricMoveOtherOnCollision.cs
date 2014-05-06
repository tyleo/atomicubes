using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Causes a ParametricBackForthMovement to begin on a TriggerEnter and to reverse on a
    /// TriggerExit.
    /// </summary>
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
