using UnityEngine;

namespace Tyleo
{
    public sealed class Accumulator :
        MonoBehaviour
    {
        [SerializeField]
        private float _resetValue = 0.0f;
        [SerializeField]
        private AccumulatorState _accumulatorState = AccumulatorState.None;
        [SerializeField]
        private float _rate = 1.0f;

        public float Value { get; set; }
        public AccumulatorState AccumulatorState { get { return _accumulatorState; } }

        private void Update()
        {
            switch (_accumulatorState)
            {
                case AccumulatorState.Forwards:
                    Value += Time.deltaTime * _rate;
                    break;
                case AccumulatorState.Backwards:
                    Value -= Time.deltaTime * _rate;
                    break;
            }
        }

        public void ResetAccumulation()
        {
            Value = _resetValue;
        }

        public void BeginAccumulatingForwards()
        {
            _accumulatorState = AccumulatorState.Forwards;
        }

        public void BeginAccumulatingBackwards()
        {
            _accumulatorState = AccumulatorState.Backwards;
        }

        public void StopAccumulating()
        {
            _accumulatorState = AccumulatorState.None;
        }
    }
}
