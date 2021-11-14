using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        TicTacToeClass TicTacToe;
        protected void Page_Load(object sender, EventArgs e)
        {
            TicTacToe = (TicTacToeClass)Session["TicTacToe"];
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
            {
                int i = int.Parse(btn.ID.Substring(4, 1));
                int j = int.Parse(btn.ID.Substring(5, 1));

                if (TicTacToe.Player == 0)
                {
                    btn.Text = "O";
                    TicTacToe[i, j] = 0;
                    TicTacToe.Player = 1;
                }
                else
                {
                    btn.Text = "X";
                    TicTacToe[i, j] = 1;
                    TicTacToe.Player = 0;
                }
                int rez = TicTacToe.Check();
                if (rez == 0) this.lbl_rezult.Text = "Congratulations win Player O";
                if (rez == 1) this.lbl_rezult.Text = "Congratulations win Player X";
                if (rez == 2) this.lbl_rezult.Text = "Congratulations in a tie";
                if (rez == 0 || rez == 1 || rez == 2) btn_Block();
            }
        }
        protected void btn_Block()
        {
            string btn_id = "";
            for (int i = 0; i < 3; i++)
            { 
                for (int j = 0; j < 3; j++)
                {
                    btn_id = "btn_" + i.ToString() + j.ToString();
                    Button btn = (Button)Page.FindControl(btn_id);
                    btn.Enabled = false;
                }
            }
        }
        protected void Restart(object sender, EventArgs e)
        {
            string btn_id = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btn_id = "btn_" + i.ToString() + j.ToString();
                    Button btn = (Button)Page.FindControl(btn_id);
                    btn.Enabled = true;
                    btn.Text = "";
                }
            }
            TicTacToe = new TicTacToeClass();
            Session["TicTacToe"] = TicTacToe;
        }
    }
}