using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Provides extensions to the physics class.
    /// </summary>
    public static class PhysicsExtended
    {
        private static Vector3 _previousGravity;
        private static Vector3 _halfGravity;

        /// <summary>
        /// Half gravity.
        /// </summary>
        public static Vector3 HalfGravity
        {
            get
            {
                // This can be done more nicely if PhysicExtended provides its own Gravity property
                // and is used as the only source of access to the value.
                if (Physics.gravity != _previousGravity)
                {
                    _previousGravity = Physics.gravity;
                    _halfGravity = Physics.gravity * 0.5f;
                }
                return _halfGravity;
            }
        }
    }
}
