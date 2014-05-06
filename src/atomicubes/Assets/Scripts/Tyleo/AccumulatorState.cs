namespace Tyleo
{
    /// <summary>
    /// The state of an Accumulator.
    /// </summary>
    public enum AccumulatorState
    {
        /// <summary>
        /// The Accumulator is not accumulating.
        /// </summary>
        None = 0,
        /// <summary>
        /// The Accumulator is adding to its value each frame.
        /// </summary>
        Forwards = None + 1,
        /// <summary>
        /// The Accumulator is subtracting from its value each frame.
        /// </summary>
        Backwards = Forwards + 1
    }
}
