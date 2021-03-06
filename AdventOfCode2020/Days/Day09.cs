﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public static class Day09
    {
        private static readonly string FilePath = Directory.GetCurrentDirectory() + @"/Input/Day09.txt";

        public static double GetResultPartOne()
        {
            var input = File.ReadAllLines(FilePath).Select(double.Parse).ToList();

            return GetFirstInvalidNumber(input, 25);
        }

        public static double GetResultPartTwo()
        {
            var input = File.ReadAllLines(FilePath).Select(double.Parse).ToList();

            var invalidNumber = GetFirstInvalidNumber(input, 25);

            return GetEncryptionWeakness(input, invalidNumber);
        }

        public static double GetFirstInvalidNumber(List<double> input, int preambleLength)
        {
            var invalidNumber = -1d;
            var preamble = input.Take(preambleLength).ToList();
            var codes = input.Skip(preambleLength).ToList();

            var offset = 0;

            while (true)
            {
                var currentNumber = codes.First();

                var isInvalid = true;
                foreach (var preambleItem in preamble)
                {
                    var isValid = false;
                    foreach (var innerPreambleItem in preamble)
                    {
                        if (preambleItem != innerPreambleItem)
                        {
                            if (currentNumber == preambleItem + innerPreambleItem)
                            {
                                isValid = true;
                                break;
                            }
                        }
                    }

                    if (isValid)
                    {
                        isInvalid = false;
                        break;
                    }
                }

                if (isInvalid)
                {
                    invalidNumber = currentNumber;
                    break;
                }

                offset++;
                preamble = input.Skip(offset).Take(preambleLength).ToList();
                codes = input.Skip(preambleLength + offset).ToList();
            }

            return invalidNumber;
        }

        public static double GetEncryptionWeakness(List<double> input, double invalidNumber)
        {
            var invalidNumberIndex = input.IndexOf(invalidNumber);
            var codes = input.Take(invalidNumberIndex).ToList();
            var validNumbers = new List<double>();
            var accumulator = 0d;

            var skip = 1;
            foreach (var code in codes)
            {
                validNumbers = new List<double>();

                validNumbers.Add(code);

                accumulator = code;
                var innerCodes = codes.Skip(skip).ToList();

                foreach (var innerCode in innerCodes)
                {
                    validNumbers.Add(innerCode);
                    accumulator += innerCode;

                    if (accumulator >= invalidNumber)
                    {
                        break;
                    }
                }

                if (accumulator == invalidNumber)
                {
                    break;
                }

                skip++;
            }

            return validNumbers.OrderBy(o => o).First() + validNumbers.OrderBy(o => o).Last();

        }
    }
}
