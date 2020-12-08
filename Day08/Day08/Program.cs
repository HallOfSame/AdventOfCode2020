﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Day08
{
    internal class Program
    {
        #region Class Methods

        public static async Task Main(string[] args)
        {
            List<Operation> operations;

            await using (var file = File.OpenRead("PuzzleInput.txt"))
            {
                using var reader = new StreamReader(file);

                operations = await new InputParser().ReadInput(reader);
            }

            var emulator = new Emulator();

            // Pt 1
            var result = emulator.RunOperations(operations,
                                                out _);

            Console.WriteLine($"Result of running operations {result}. Accumulator at {emulator.AccumulatorValue}.");

            // Pt 2

            var fixer = new OperationFixer(operations);

            var fixedAccValue = fixer.GetAccumulatorForFixedProgram();

            Console.WriteLine($"Result of accumulator with fixed instructions: {fixedAccValue}.");
        }

        #endregion
    }
}