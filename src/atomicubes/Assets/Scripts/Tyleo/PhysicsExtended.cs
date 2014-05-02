using UnityEngine;

namespace Tyleo
{
    public static class PhysicsExtended
    {
        private static Vector3 _previousGravity;
        private static Vector3 _halfGravity;

        public static Vector3 HalfGravity
        {
            get
            {
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
