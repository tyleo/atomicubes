using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Classes inheriting from this class will have an execute function which calculates a Vector3
    /// from a float.
    /// </summary>
    public abstract class ParametricEquation3d :
        MonoBehaviour
    {
        /// <summary>
        /// Calculates a Vector3 from a float. 
        /// </summary>
        /// <param name="t">
        /// The float to use to calculate the Vector3.
        /// </param>
        /// <returns>
        /// A Vector3 calculated from the float.
        /// </returns>
        public abstract Vector3 Execute(float t);
    }
}
