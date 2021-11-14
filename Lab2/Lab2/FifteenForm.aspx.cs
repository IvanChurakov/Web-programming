using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class FifteenForm : System.Web.UI.Page
    {
        FifteenClass Fifteen;
        string Path;
        protected void Page_Load(object sender, EventArgs e)
        {
            Fifteen = (FifteenClass)Session["Fifteen"];
            Path = (string)Session["Path"];
            if (!Page.IsPostBack)
                btn_Init();

        }
        protected void btn_Init()
        {
            // Пиймав розбийнычкив
            string btn_id = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Fifteen[i + 1, j + 1] != -1)
                    {
                        btn_id = "btn_" + i.ToString() + j.ToString();
                        Button btn = (Button)Page.FindControl(btn_id);
                        btn.Text = Fifteen[i + 1, j + 1].ToString();
                    }
                }
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int i = int.Parse(btn.ID.Substring(4, 1));
            int j = int.Parse(btn.ID.Substring(5, 1));
            int[] rez = Fifteen.Twist(i + 1, j + 1);
            if (!(rez[0] == 0 && rez[1] == 0))
            {
                btn.Text = "";
                string btn_id = "btn_" + (rez[0] - 1).ToString() + (rez[1] - 1).ToString();
                Button btn1 = (Button)Page.FindControl(btn_id);
                btn1.Text = Fifteen[rez[0], rez[1]].ToString();
                Fifteen.Count++;
                this.lbl_click.Text = "You made " + Fifteen.Count + " clicks";
                if (Fifteen.Check())
                {
                    lbl_click.Visible = false;
                    // Вывести текст с поздравлением в lbl_rezult
                    lbl_rezult.Text = "Nice game, monkey";
                    // Вызвать метод btn_Block блокировки всех кнопок
                    btn_Block();
                    // Открыть файл игрока
                    FileStream files = new FileStream(Path, FileMode.Create);
                    StreamWriter file = new StreamWriter(files);
                    // Добавить в файл строку с информацией о количестве перемещений
                    file.WriteLine(String.Concat("Oh my God. You spent so many moves that it’s a shame to say, but I’ll still tell you how much you spent on this game. This number is ", Fifteen.Count));
                    // Закрыть файл игрока
                    file.Close();
                }
            }
        }
        protected void btn_Block()
        {
            string btn_id = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    btn_id = "btn_" + i.ToString() + j.ToString();
                    Button btn = (Button)Page.FindControl(btn_id);
                    btn.Enabled = false;
                }
            }
        }

    }
}