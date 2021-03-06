﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireworksNet.Model
{
    public class MutableFirework : Firework
    {
        /// <summary>
        /// Create instance of MutableFirework class
        /// </summary>
        /// <param name="fireworkType">The type of the firework (or spark this firework has been originated from).</param>
        /// <param name="birthStepNumber">The number of step this firework was created at.</param>
        /// <param name="coordinates">The firework coordinates.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"> if <paramref name="birthStepNumber"/>is less than zero.</exception>
        /// <exception cref="System.ArgumentNullException"> if <paramref name="coordinates"/>is <c>null</c>.</exception>
        public MutableFirework(FireworkType fireworkType, int birthStepNumber, IDictionary<Dimension, double> coordinates)
            : base(fireworkType, birthStepNumber, coordinates) 
        {
        }

        /// <summary>
        /// Updates firework. He simply copy fields.
        /// </summary>
        /// <param name="newState">New state of firework.</param>
        public void Update(Firework newState)
        {
            this.BirthStepNumber = newState.BirthStepNumber;
            this.Coordinates = newState.Coordinates;
            this.Quality = newState.Quality;
        }
    }
}
