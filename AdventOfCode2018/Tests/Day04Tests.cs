﻿using System.Collections.Generic;
using System.Dynamic;
using AdventOfCode2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void Part1_TestOne()
        {
            Assert.AreEqual(240, Day04.GetSleepiestGuardResult(GetTestData()).TotalSleepiest);
        }

        [TestMethod]
        public void Part2_TestOne()
        {
            Assert.AreEqual(4455, Day04.GetSleepiestGuardResult(GetTestData()).SleepiestSameTime);
        }

        private static List<string> GetTestData()
        {
            return new List<string> {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-05 00:55] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-01 00:25] wakes up"
            };

        }
    }
}
