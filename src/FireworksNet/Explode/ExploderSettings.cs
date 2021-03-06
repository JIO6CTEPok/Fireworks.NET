﻿
namespace FireworksNet.Explode
{
    /// <summary>
    /// DTO - stores constants needed for an explosion creation.
    /// </summary>
    public class ExploderSettings
    {
        /// <summary>
        /// m - Parameter controlling the total number of sparks generated
        /// by <see cref="LocationsNumber"/> fireworks.
        /// </summary>
        public double ExplosionSparksNumberModifier { get; set; }

        /// <summary>
        /// a - Constant,
        /// has to be 0 &lt; a &lt; <paramref name="ExplosionSparksNumberUpperBound"/>.
        /// </summary>
        public double ExplosionSparksNumberLowerBound { get; set; }

        /// <summary>
        /// b - Constant,
        /// has to be <paramref name="ExplosionSparksNumberLowerBound"/> &lt; b &lt; 1.
        /// </summary>
        public double ExplosionSparksNumberUpperBound { get; set; }

        /// <summary>
        /// Â - Maximum explosion amplitude.
        /// </summary>
        public double ExplosionSparksMaximumAmplitude { get; set; }

        /// <summary>
        /// Number of specific sparks generated by an explosion.
        /// </summary>
        /// <remarks>No such setting in the 2010 paper.</remarks>
        public int SpecificSparksPerExplosionNumber { get; set; }
    }
}