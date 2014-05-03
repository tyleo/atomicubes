using UnityEngine;

namespace Tyleo
{
    public abstract class ParametricEquation3d :
        MonoBehaviour
    {
        public abstract Vector3 Execute(float t);
    }
}
