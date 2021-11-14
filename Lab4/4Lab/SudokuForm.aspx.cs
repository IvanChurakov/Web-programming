using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4Lab
{
    public partial class SudokuForm : System.Web.UI.Page
    {
        SudokuClass sudoku;
        int[] press_field;
        int N = 9;
        Button[,] btn_field;
        Button[] btn_number;

        protected void Page_Load(object sender, EventArgs e)
        {
            sudoku = (SudokuClass)Session["sudoku"];
            press_field = (int[])Session["press_field"];
            Field_Build();
            Field_Fill();
        }
        protected void Field_Build()
        {
            btn_field = new Button[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Создайте кнопку
                    btn_field[i, j] = new Button();
                    btn_field[i, j].ID = Convert.ToString(i) + Convert.ToString(j);
                    // Назначьте свойства кнопке
                    btn_field[i, j].Style.Add("position", "absolute");
                    btn_field[i, j].Style.Add("margin", "auto");
                    btn_field[i, j].Style.Add("width", "8%");
                    btn_field[i, j].Style.Add("height", "8%");
                    btn_field[i, j].Style.Add("top", Convert.ToString(11 + +i * 8) + "%");
                    btn_field[i, j].Style.Add("left", Convert.ToString(14 + j * 8) + "%");
                    btn_field[i, j].Style.Add("border", "2px solid gray");
                    btn_field[i, j].Style.Add("border-radius", "5%");
                    // Добавьте обработчик события кнопке
                    btn_field[i, j].Click += btn_field_Click;
                    // Добавьте кнопку на поле
                    panel_field.Controls.Add(btn_field[i, j]);
                }
            }

            btn_number = new Button[N];
            for (int i = 0; i < N; i++)
            {
                // Создайте кнопку
                btn_number[i] = new Button();
                btn_number[i].ID = "btn_" + Convert.ToString(i);
                btn_number[i].Text = Convert.ToString(i + 1);
                // Назначьте свойства кнопке
                btn_number[i].Style.Add("position", "absolute");
                btn_number[i].Style.Add("margin", "auto");
                btn_number[i].Style.Add("width", "8%");
                btn_number[i].Style.Add("height", "8%");
                btn_number[i].Style.Add("top", "87%");
                btn_number[i].Style.Add("left", Convert.ToString(14 + i * 8) + "%");
                btn_number[i].Style.Add("border", "2px solid gray");
                btn_number[i].Style.Add("border-radius", "5%");
                // Добавьте обработчик события кнопке
                btn_number[i].Click += btn_number_Click;
                // Добавьте кнопку на поле
                panel_field.Controls.Add(btn_number[i]);
            }
        }
        protected void Field_Fill()
        {
            // Реализуйте работу метода
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (sudoku[0, i, j] != 0)
                    {
                        btn_field[i, j].Text = Convert.ToString(sudoku[0, i, j]);
                    }
                }
            }
        }
        protected void btn_field_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int i = Int32.Parse(btn.ID[0].ToString());
            int j = Int32.Parse(btn.ID[1].ToString());
            if (sudoku[1, i, j] == 0)
            {
                press_field[0] = i;
                press_field[1] = j;


                for (int i1 = 0; i1 < N; i1++)
                {
                    for (int j1 = 0; j1 < N; j1++)
                    {
                        if (i1 == i || j1 == j || ((i1 >= (i / 3 * 3)) && (i1 <= (i / 3 * 3 + 2)) && (j1 >= (j / 3 * 3)) && (j1 <= (j / 3 * 3 + 2))))
                            btn_field[i1, j1].Style.Add("background-color", "rgb(210, 210, 210)");
                        else
                            btn_field[i1, j1].Style.Add("background-color", "rgb(239, 239, 239)");
                    }
                }
            }
            else
            {
                for (int i1 = 0; i1 < N; i1++)
                {
                    for (int j1 = 0; j1 < N; j1++)
                    {
                        btn_field[i1, j1].Style.Add("background-color", "rgb(239, 239, 239)");
                    }
                }

            }

        }
        protected void btn_number_Click(object sender, EventArgs e)
        {
            int[] test = (int[])Session["press_field"];
            if (test[0] > -1 && test[1] > -1)
            {
                Button btn = (Button)sender;

                btn_field[test[0], test[1]].Text = btn.Text;
                sudoku[0, test[0], test[1]] = Int32.Parse(btn.Text);

                press_field[0] = -1;
                press_field[1] = -1;

                if (sudoku.CheckFill())
                {
                    if (sudoku.CheckResult())
                    {
                        lbl_rezult.Text = "Game passed";
                    }
                    else
                    {
                        lbl_rezult.Text = "Game failed";
                    }
                }
            }
        }

    }
}