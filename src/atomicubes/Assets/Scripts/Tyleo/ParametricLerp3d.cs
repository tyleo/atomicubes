using UnityEngine;

namespace Tyleo
{
    public sealed class ParametricLerp3d :
        ParametricEquation3d
    {
        [SerializeField]
        private Vector3 _from = Vector3.zero;
        [SerializeField]
        private Vector3 _to = Vector3.zero;

        public sealed override Vector3 Execute(float t)
        {
            return Vector3.Lerp(_from, _to, t);
        }
    }
}
