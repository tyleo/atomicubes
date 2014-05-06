using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Fulfills the ParametricEquation3d abstract interface by providing an Execute method which
    /// interpolates between two vectors.
    /// </summary>
    public sealed class ParametricLerp3d :
        ParametricEquation3d
    {
        /// <summary>
        /// The vector obtained at t == 0.
        /// </summary>
        [SerializeField]
        private Vector3 _from = Vector3.zero;
        /// <summary>
        /// The vector obtained at t == 1.
        /// </summary>
        [SerializeField]
        private Vector3 _to = Vector3.zero;

        /// <summary>
        /// Linearly interpolates between the from and to vectors.
        /// </summary>
        /// <param name="t">
        /// The interpolant.
        /// </param>
        /// <returns>
        /// The a vector generated from the from and to vectors using the interpolant, t.
        /// </returns>
        public sealed override Vector3 Execute(float t)
        {
            return Vector3.Lerp(_from, _to, t);
        }
    }
}
