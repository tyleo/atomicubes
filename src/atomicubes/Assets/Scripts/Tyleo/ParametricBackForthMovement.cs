using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Allows an entity to be moved back and forth along a path defined by a parametric equation.
    /// </summary>
    public sealed class ParametricBackForthMovement :
        MonoBehaviour
    {
        /// <summary>
        /// The minimum value the parametric equation will be allowed to accept.
        /// </summary>
        [SerializeField]
        private float _minimumT = 0.0f;
        /// <summary>
        /// The maximum value the parametric equation will be allowed to accept.
        /// </summary>
        [SerializeField]
        private float _maximumT = 1.0f;

        private ParametricEquation3d _parametricEquation3d;
        private Accumulator _accumulator;

        private void Start()
        {
            _parametricEquation3d = GetComponent<ParametricEquation3d>();
            _accumulator = GetComponent<Accumulator>();
        }

        private void Update()
        {
            switch (_accumulator.AccumulatorState)
            {
                case AccumulatorState.Forwards:
                    if (_accumulator.Value >= _maximumT)
                    {
                        _accumulator.StopAccumulating();
                        _accumulator.Value = _maximumT;
                        _accumulator.StopAccumulating();
                    }
                    break;
                case AccumulatorState.Backwards:
                    if (_accumulator.Value <= _minimumT)
                    {
                        _accumulator.StopAccumulating();
                        _accumulator.Value = _minimumT;
                        _accumulator.StopAccumulating();
                    }
                    break;
            }

            transform.localPosition = _parametricEquation3d.Execute(_accumulator.Value);
        }

        /// <summary>
        /// Begins moving the entity forwards along the path.
        /// </summary>
        public void BeginMovingForwards()
        {
            _accumulator.BeginAccumulatingForwards();
        }

        /// <summary>
        /// Begins moving the entity backwards along the path.
        /// </summary>
        public void BeginMovingBackwards()
        {
            _accumulator.BeginAccumulatingBackwards();
        }

        /// <summary>
        /// Stops moving the entity.
        /// </summary>
        public void Stop()
        {
            _accumulator.StopAccumulating();
        }
    }
}
