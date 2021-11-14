using NUnit.Framework;

namespace _4Lab.Tests
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
            public void ConstructorPlusOpenIndexatorNum_Field()
            {
                SudokuClass sudokuClass = new SudokuClass();

                Assert.GreaterOrEqual(sudokuClass[0, 1, 1], 0);
            }

            [Test]
            public void ConstructorPlusOpenIndexatorFill_Field()
            {
                SudokuClass sudokuClass = new SudokuClass();

                Assert.GreaterOrEqual(sudokuClass[1, 1, 1], 0);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.RowsPlusColumnsPlusFiiling))]
            public void CheckingRows(int[,] value)
            {
                SudokuClass sudokuClass = new SudokuClass();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        sudokuClass[0, i, j] = value[i, j];

                bool answer = sudokuClass.CheckRow();

                Assert.AreEqual(answer, true);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.RowsPlusColumnsPlusFiiling))]
            public void CheckingColumns(int[,] value)
            {
                SudokuClass sudokuClass = new SudokuClass();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        sudokuClass[0, i, j] = value[i, j];

                bool answer = sudokuClass.CheckCol();

                Assert.AreEqual(answer, true);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Squares))]
            public void CheckingSquares(int[,] value)
            {
                SudokuClass sudokuClass = new SudokuClass();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        sudokuClass[0, i, j] = value[i, j];

                bool answer = sudokuClass.CheckSquare();

                Assert.AreEqual(answer, true);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.RowsPlusColumnsPlusFiiling))]
            public void CheckingFill(int[,] value)
            {
                SudokuClass sudokuClass = new SudokuClass();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        sudokuClass[0, i, j] = value[i, j];

                bool answer = sudokuClass.CheckFill();

                Assert.AreEqual(answer, true);
            }

            [TestCaseSource(typeof(ParamsForChecking), nameof(ParamsForChecking.Wins))]
            public void CheckingResult(int[,] value)
            {
                SudokuClass sudokuClass = new SudokuClass();
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        sudokuClass[0, i, j] = value[i, j];

                bool answer = sudokuClass.CheckResult();

                Assert.AreEqual(answer, true);
            }
        }

        class ParamsForChecking
        {
            public static object[] RowsPlusColumnsPlusFiiling =
            {
                new int[,] { { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                             { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                             { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
                             { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
                             { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
                             { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
                             { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
                             { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
                             { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
                }
            };

            public static object[] Squares =
            {
                new int[,] { { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
                             { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
                             { 7, 8, 9, 7, 8, 9, 7, 8, 9 },
                             { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
                             { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
                             { 7, 8, 9, 7, 8, 9, 7, 8, 9 },
                             { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
                             { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
                             { 7, 8, 9, 7, 8, 9, 7, 8, 9 }
                }
            };

            public static object[] Wins =
            {
                new int[,] { { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                             { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                             { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                             { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                             { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                             { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                             { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                             { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                             { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
                }
            };
        }
    }    
}