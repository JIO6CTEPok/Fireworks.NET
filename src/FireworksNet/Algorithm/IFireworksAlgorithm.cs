﻿using System.Collections.Generic;
using FireworksNet.Model;
using FireworksNet.Problems;

namespace FireworksNet.Algorithm
{
    public interface IFireworksAlgorithm
    {
        Problem ProblemToSolve { get; }

        Firework Solve();
        IEnumerable<Firework> MakeStep(IEnumerable<Firework> currentFireworks);
    }
}