using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Generates a lattice of GameObjects at a specified rate within specified bounds.
    /// </summary>
    public sealed class LatticeGenerator :
        MonoBehaviour
    {
        /// <summary>
        /// The GameObject to create a lattice of.
        /// </summary>
        [SerializeField]
        private GameObject _pointObject;
        /// <summary>
        /// The starting position of the GameObjects along the X-axis.
        /// </summary>
        [SerializeField]
        private float _xMin = -1.0f;
        /// <summary>
        /// The ending position of the GameObjects along the X-axis.
        /// </summary>
        [SerializeField]
        private float _xMax = +1.0f;
        /// <summary>
        /// The distance between GameObjects along the X-axis.
        /// </summary>
        [SerializeField]
        private float _xStep = +1.0f;
        /// <summary>
        /// The starting position of the GameObjects along the Y-axis.
        /// </summary>
        [SerializeField]
        private float _yMin = -1.0f;
        /// <summary>
        /// The ending position of the GameObjects along the Y-axis.
        /// </summary>
        [SerializeField]
        private float _yMax = +1.0f;
        /// <summary>
        /// The distance between GameObjects along the Y-axis.
        /// </summary>
        [SerializeField]
        private float _yStep = +1.0f;
        /// <summary>
        /// The starting position of the GameObjects along the Z-axis.
        /// </summary>
        [SerializeField]
        private float _zMin = -1.0f;
        /// <summary>
        /// The ending position of the GameObjects along the Z-axis.
        /// </summary>
        [SerializeField]
        private float _zMax = +1.0f;
        /// <summary>
        /// The distance between GameObjects along the Z-axis.
        /// </summary>
        [SerializeField]
        private float _zStep = +1.0f;

        private void Start()
        {
            _pointObject.SetActive(false);
            _pointObject.transform.parent = transform;
            _pointObject.transform.localPosition = Vector3.zero;

            for (float i = _xMin; i <= _xMax; i += _xStep)
            {
                for (float j = _yMin; j <= _yMax; j += _yStep)
                {
                    for (float k = _zMin; k <= _zMax; k += _zStep)
                    {
                        var newObject = (GameObject)GameObject.Instantiate(_pointObject);
                        newObject.transform.parent = transform;
                        newObject.transform.localPosition = new Vector3(i, j, k);
                        newObject.SetActive(true);
                    }
                }
            }
        }
    }
}
