using UnityEngine;

namespace Tyleo
{
    /// <summary>
    /// Increases a value with each update by scaled delta time.
    /// </summary>
    public sealed class Accumulator :
        MonoBehaviour
    {
        /// <summary>
        /// The value the Accumulator should hold when it is reset.
        /// </summary>
        [SerializeField]
        private float _resetValue = 0.0f;
        /// <summary>
        /// Determines whether the Accumulator is adding to the value each frame, subtracting or
        /// doing nothing.
        /// </summary>
        [SerializeField]
        private AccumulatorState _accumulatorState = AccumulatorState.None;
        /// <summary>
        /// The rate at which the value held by the Accumulator changes. This is multiplied by the
        /// delta time before being applied to the value.
        /// </summary>
        [SerializeField]
        private float _rate = 1.0f;

        /// <summary>
        /// The value held by the accumulator.
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Indicates whether the Accumulator is adding to the value each frame, subtracting or
        /// doing nothing.
        /// </summary>
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

        /// <summary>
        /// Resets the accumulator to the reset value.
        /// </summary>
        public void ResetAccumulation()
        {
            Value = _resetValue;
        }

        /// <summary>
        /// Begins adding to the value each frame.
        /// </summary>
        public void BeginAccumulatingForwards()
        {
            _accumulatorState = AccumulatorState.Forwards;
        }

        /// <summary>
        /// Begins subtracting from the value each frame.
        /// </summary>
        public void BeginAccumulatingBackwards()
        {
            _accumulatorState = AccumulatorState.Backwards;
        }

        /// <summary>
        /// Stops modifying the value each frame.
        /// </summary>
        public void StopAccumulating()
        {
            _accumulatorState = AccumulatorState.None;
        }
    }
}
