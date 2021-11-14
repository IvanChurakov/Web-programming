using NUnit.Framework;
using System.Collections.Generic;

namespace Lab1.Tests
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
            public void ConstructorAndOpenPropertyPlayer()
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();

                Assert.AreEqual(ticTacToe.Player, 1);
            }

            [Test]
            public void ConstructorAndIndexator()
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();

                Assert.AreEqual(ticTacToe[1, 1], -1);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Colunms))]
            public void CheckCols(int[,] value)
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        ticTacToe[i, j] = value[i, j];

                Assert.AreEqual(ticTacToe.Check(), 1);
            }


            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Rows))]
            public void CheckRows(int[,] value)
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        ticTacToe[i, j] = value[i, j];

                Assert.AreEqual(ticTacToe.Check(), 1);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Major))]
            public void CheckMajorDiag(int[,] value)
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        ticTacToe[i, j] = value[i, j];

                Assert.AreEqual(ticTacToe.Check(), 1);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Minor))]
            public void CheckMinorDiag(int[,] value)
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        ticTacToe[i, j] = value[i, j];

                Assert.AreEqual(ticTacToe.Check(), 1);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Tie))]
            public void CheckTie(int[,] value)
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        ticTacToe[i, j] = value[i, j];

                Assert.AreEqual(ticTacToe.Check(), 2);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.NoWinsAndTie))]
            public void CheckingMinusOne(int[,] value)
            {
                TicTacToeClass ticTacToe = new TicTacToeClass();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        ticTacToe[i, j] = value[i, j];

                Assert.AreEqual(ticTacToe.Check(), -1);
            }
        }

        class ParamsForChecking
        {
            public static object[] Colunms =
            {
                new int[,] { { 1, 0, 1 },
                             { 1, 0, 1 },
                             { 1, 1, 0 } 
                },
                new int[,] { { 0, 1, 0 },
                             { 0, 1, 1 },
                             { 1, 1, 0 } 
                },
                new int[,] { { 0, 1, 1 },
                             { 0, 0, 1 },
                             { 1, 0, 1 } 
                }
            };

            public static object[] Rows =
            {
                new int[,] { { 1, 1, 1},
                             { 0, 1, 1},
                             { 1, 0, 0} 
                },
                new int[,] { { 0, 0, 1},
                             { 1, 1, 1},
                             { 0, 1, 0}
                },
                new int[,] { { 0, 0, 1},
                             { 1, 0, 0},
                             { 1, 1, 1} }
            };

            public static object[] Major =
            {
                new int[,] { { 1, 0, 0},
                             { 0, 1, 0},
                             { 0, 0, 1} }
            };

            public static object[] Minor =
            {
                new int[,] { { 0, 0, 1},
                             { 0, 1, 0},
                             { 1, 0, 0} }
            };

            public static object[] Tie =
            {
                new int[,] { { 0, 0, 1},
                             { 1, 1, 0},
                             { 0, 1, 0} 
                }
            };

            public static object[] NoWinsAndTie =
            {
                new int[,] { { 1, 0, 1},
                             { 1, 1, 0},
                             { 0, 1, 0}
                }
            };
        }
    }
}