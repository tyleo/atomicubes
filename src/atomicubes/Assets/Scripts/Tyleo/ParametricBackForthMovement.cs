using UnityEngine;

namespace Tyleo
{
    public sealed class ParametricBackForthMovement :
        MonoBehaviour
    {
        [SerializeField]
        private float _minimumT = 0.0f;
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
                    }
                    break;
                case AccumulatorState.Backwards:
                    if (_accumulator.Value <= _minimumT)
                    {
                        _accumulator.StopAccumulating();
                        _accumulator.Value = _minimumT;
                    }
                    break;
            }

            transform.localPosition = _parametricEquation3d.Execute(_accumulator.Value);
        }

        public void BeginMovingForwards()
        {
            _accumulator.BeginAccumulatingForwards();
        }

        public void BeginMovingBackwards()
        {
            _accumulator.BeginAccumulatingBackwards();
        }

        public void Stop()
        {
            _accumulator.StopAccumulating();
        }
    }
}
