using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Lab2.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class MainTests 
        {
            [Test]
            public void ConstructorPlusPublicPropertyCount()
            {
                FifteenClass fifteenClass = new FifteenClass();

                Assert.AreEqual(0, fifteenClass.Count);
            }

            [Test]
            public void ConstructorPlusIndexatorPlusGenerateField()
            {
                List<int> list = new List<int> { -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                FifteenClass fifteenClass = new FifteenClass();

                for (int i = 1; i < 5; i++)
                    for (int j = 1; j < 5; j++)
                        list.Remove(fifteenClass[i, j]);

                Assert.AreEqual(new List<int>(), list);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Twist))]
            public void WorkTwist(int[,] value)
            {
                FifteenClass fifteenClass = new FifteenClass();
                for (int i = 1; i < 5; i++)
                    for (int j = 1; j < 5; j++)
                        fifteenClass[i, j] = value[i - 1, j - 1];
                int[] NeededAnswer = new int[2] { value[4, 0], value[4, 1]};

                int[] answer = fifteenClass.Twist(3, 4);

                Assert.AreEqual(NeededAnswer, answer);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.CheckWinOrlosing))]
            public void CheckWinOrlosing(int[,] value)
            {
                FifteenClass fifteenClass = new FifteenClass();
                for (int i = 1; i < 5; i++)
                    for (int j = 1; j < 5; j++)
                        fifteenClass[i, j] = value[i - 1, j - 1];
                bool NeededAnswer = Convert.ToBoolean(value[4, 0]);

                bool answer = fifteenClass.Check();

                Assert.AreEqual(NeededAnswer, answer);
            }
        }

        class ParamsForChecking
        {
            public static object[] Twist =
            {
                //answer must be 4, 4
                new int[,] { { 1,   2,  3,  4 },
                             { 5,   6,  7,  8 },
                             { 9,  10, 11, 12 },
                             { 13, 14, 15, -1 },
                             { 4, 4, default, default }
                },
                //answer must be 0, 0
                new int[,] { { 1,   2,  3,  4 },
                             { 5,   6,  7,  8 },
                             { 9,  -1, 11, 12 },
                             { 13, 14, 15, 10 },
                             { 0, 0, default, default }
                }
            };

            public static object[] CheckWinOrlosing =
            {
                //answer must be true
                new int[,] { { 1,   2,  3,  4 },
                             { 5,   6,  7,  8 },
                             { 9,  10, 11, 12 },
                             { 13, 14, 15, -1 },
                             { 1, default, default, default }
                },
                //answer must be false
                new int[,] { { 1,   2,  3,  4 },
                             { 5,   6,  7,  8 },
                             { 9,  -1, 11, 12 },
                             { 13, 14, 15, 10 },
                             { 0, default, default, default }
                }
            };
        }
    }
}