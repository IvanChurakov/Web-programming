using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4Lab
{
    public class SudokuClass
    {
        int[] standart = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // Объявление переменной размера поля
        int N = 9;
        // Объявление переменной игрового поля, в котором хранятся числа,
        // полученные при загрузке поля и установленные играком
        int[,] num_field = new int[9, 9];
        // Объявление переменной дополнительного поля, в котором числа 0 и 1,
        // 1 обозначает, что соответствующая ячейка в игровом поле num_field 
        // была заполнена изначально, в результате разметки
        // 0, обозначает, что соответствующая ячейка в игровом поле num_field 
        // может быть заполнена игроком
        int[,] fill_field = new int[9, 9];

        // Объявление конструктора класса
        public SudokuClass()
        {
            StreamReader streamReader = new StreamReader(@"D:\Чураков 4\4Lab\4Lab\permutation.txt");
            string st;
            Random rnd = new Random();
            int count = rnd.Next(160);
            int k = 0;
            while (!streamReader.EndOfStream)
            {
                if (k != count)
                {
                    streamReader.ReadLine();
                    k++;
                }
                else
                {
                    int[] str = Array.ConvertAll(streamReader.ReadLine().ToCharArray(), c => (int)Char.GetNumericValue(c));
                    int q = 0;
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            num_field[i, j] = str[q];
                            if (str[q] == 0)
                            {
                                fill_field[i, j] = 0;
                            }
                            else
                            {
                                fill_field[i, j] = 1;
                            }
                            q++;
                        }
                    }
                    break;
                }
            }
            // инициализация переменных fill_field и num_field
        }

        // Объявление открытого индексатора
        public int this[int c, int i, int j]
        {
            get
            {
                if (c == 0)
                {
                    return num_field[i, j];
                }
                else //if (c == 1)
                {
                    return fill_field[i, j];
                }
            }
            set
            {
                if (c == 0)
                {
                    num_field[i, j] = value;
                }
                else //if (c == 1)
                {
                    fill_field[i, j] = value;
                }
            }
            // Реализовать работу трехмерного индексатора, у которого индексы:
            // c номер матрицы, 0 - num_field, 1 - fill_field
            // i номер строчки
            // j номер столбца
        }
        private int[] Sort(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            return nums;
        }
        private bool MainCheck(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return true;
                }
            }
            return false;
        }
        // Объявление метода проверки значений по строкам
        public bool CheckRow()
        {
            int[] temp = new int[9];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    temp[j] = num_field[i, j];
                }
                if (MainCheck(Sort(temp), standart))
                {
                    return false;
                }
            }
            return true;
            // Возвращает true, если в каждой строке числа от 1 до 9
            // В противном случае возвращает false
        }
        // Объявление метода проверки значений по столбцам
        public bool CheckCol()
        {
            for (int j = 0; j < N; j++)
            {
                int[] temp = new int[9];
                for (int i = 0; i < N; i++) {
                    temp[i] = num_field[i, j];
                }
                if (MainCheck(Sort(temp), standart))
                {
                    return false;
                }
            }
            return true;
            // Возвращает true, если в каждом столбце числа от 1 до 9
            // В противном случае возвращает false
        }
        // Объявление метода проверки значений по областям 3х3
        public bool CheckSquare()
        {
            int k = 0;
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    int[] temp = new int[9];
                    for (int i = h * 3; i < 3 + (h * 3); i++)
                    {
                        for (int j = w * 3; j < 3 + (w * 3); j++)
                        {
                            temp[k] = num_field[i, j];
                            k++;
                        }
                    }
                    if (MainCheck(Sort(temp), standart))
                    {
                        return false;
                    }
                    k = 0;
                }
            }
            return true;
            // Возвращает true, если в каждой области 3х3 числа от 1 до 9
            // В противном случае возвращает false
        }
        // Объявление метода проверки заполнения поля num_field
        public bool CheckFill()
        {
            int[] temp = new int[9];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    temp[j] = num_field[i, j];
                }
                Array.Sort(temp);
                if (Array.BinarySearch(temp, 0) > -1)
                {
                    return false;
                }
            }
            return true;
            // Возвращает true, если все ячейки игрового поля заполнены игроком
            // В противном случае возвращает false
        }
        // Объявление метода проверки выигрыша
        public bool CheckResult()
        {
            if (CheckSquare() && CheckRow() && CheckCol())
            {
                return true;
            }
            else
            {
                return false;
            }
            // Возвращает true, если игрок заполнил все ячейки правильно
            // В противном случае возвращает false
        }

    }
}