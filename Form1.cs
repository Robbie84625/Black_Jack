using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1106305劉宣甫_期末專案_小遊戲21點
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int player_chips = 100;
        int computer_chips = 100;
        Random r = new Random();
        string[] suit = { "黑桃", "紅心", "方塊", "梅花" };

        int computer1 = 0;
        int computer1_num = 0;
        int computer_total = 0;
        string computer_suit_name = "";
        string computer_num_name = "";
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
           
            //電腦的第一張選牌
            computer1 = r.Next(1, 53);
            //牌號
            computer1_num = computer1 % 13;
            //判斷花色
            int computer1_suit = (computer1- 1)/ 13;
            //花色轉換
            for(int i=0;i<4;i++)
            {
                if(computer1_suit ==i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer1_num == 11)
            {
                computer_num_name = "J";
            }
            else if (computer1_num == 12)
            {
                computer_num_name = "Q";
            }
            else if (computer1_num==0)
            {
                computer_num_name = "K";
            }
            else if (computer1_num == 1)
            {
                computer_num_name = "A";
            }
            else if(computer1_num>1&& computer1_num < 11)
            {
                computer_num_name = computer1_num.ToString();
            }
            button10.Text = computer_suit_name + computer_num_name;
            button10.Enabled = false;

            button5.Hide();
            button11.Hide();
            button12.Hide();
            button13.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();

        }
        int player1 = 0;
        int player1_num = 0;
        int player_total=0;
        string player_suit_name = "";
        string player_num_name = "";
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            //選牌
            player1 = r.Next(1, 53);
            //不能選別人選過的
            while (player1 == computer1)
            {
                player1=r.Next(1, 53);
            }
            //牌號
            player1_num = player1 % 13;
            //判斷花色
            int player1_suit = (player1 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (player1_suit == i)
                {
                   player_suit_name = suit[i];
                }
            }
            //數字轉換
            if (player1_num == 11)
            {
                player_num_name = "J";
                player_total += 10;
            }
            if (player1_num == 12)
            {
                player_num_name = "Q";
                player_total += 10;
            }
            if (player1_num == 0)
            {
                player_num_name = "K";
                player_total += 10;
            }
            if (player1_num == 1)
            {
                player_num_name = "A";
                button3.Text = player_suit_name + player_num_name;
                DialogResult result = MessageBox.Show("請問是否將此張牌賦值為1？確定賦值為1，取消賦值為11"
                    ,"詢問",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(result==DialogResult.OK)
                {
                    player_total += 1;
                }
                else if (result == DialogResult.Cancel)
                {
                    player_total +=11;
                }
            }
            if (player1_num > 1 && player1_num < 11)
            {
                player_num_name = player1_num.ToString();
                player_total += player1_num;
            }
            button3.Text = player_suit_name + player_num_name;
           
        }
        int player2 = 0;
        int player2_num = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            button6.Enabled = false;
            //選牌
            player2 = r.Next(1, 53);
            //不能選別人選過的
            while (player2 == computer1||player2==player1)
            {
                player2 = r.Next(1, 53);
            }
            //牌號
            player2_num = player2 % 13;
            //判斷花色
            int player2_suit = (player2 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (player2_suit == i)
                {
                    player_suit_name = suit[i];
                }
            }
            //數字轉換
            if (player2_num == 11)
            {
                player_num_name = "J";
                player_total += 10;
            }
            if (player2_num == 12)
            {
                player_num_name = "Q";
                player_total += 10;
            }
            if (player2_num == 0)
            {
                player_num_name = "K";
                player_total += 10;
            }
            if (player2_num == 1)
            {
                player_num_name = "A";
                button6.Text = player_suit_name + player_num_name;
                DialogResult result = MessageBox.Show("請問是否將此張牌賦值為1？確定賦值為1，取消賦值為11"
                    , "詢問", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    player_total += 1;
                }
                else if (result == DialogResult.Cancel)
                {
                    player_total += 11;
                }
            }
            if (player2_num > 1 && player2_num < 11)
            {
                player_num_name = player2_num.ToString();
                player_total += player2_num;
            }
            button6.Text = player_suit_name + player_num_name;
            if (player_total > 21)
            {
                player_total = computer_total = 0;
                player_chips -= 20;
                computer_chips += 20;
                toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                if (player_chips == 0 || computer_chips == 0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                DialogResult result = MessageBox.Show("請問是否繼續?", "你爆掉了", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 0 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;

                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();


                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";

                    button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;

                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
        }

            int player3 = 0;
        int player3_num = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            button7.Enabled = false;
            //選牌
            player3 = r.Next(1, 53);
            //不能選別人選過的
            while (player3 == computer1 || player3 == player1|| player3 == player2)
            {
                player3 = r.Next(1, 53);
            }
            //牌號
            player3_num = player3 % 13;
            //判斷花色
            int player3_suit = (player3 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (player3_suit == i)
                {
                    player_suit_name = suit[i];
                }
            }
            //數字轉換
            if (player3_num == 11)
            {
                player_num_name = "J";
                player_total += 10;
            }
            if (player3_num == 12)
            {
                player_num_name = "Q";
                player_total += 10;
            }
            if (player3_num == 0)
            {
                player_num_name = "K";
                player_total += 10;
            }
            if (player3_num == 1)
            {
                player_num_name = "A";
                button7.Text = player_suit_name + player_num_name;
                DialogResult result = MessageBox.Show("請問是否將此張牌賦值為1？確定賦值為1，取消賦值為11"
                    , "詢問", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    player_total += 1;
                }
                else if (result == DialogResult.Cancel)
                {
                    player_total += 11;
                }
            }
            if (player3_num > 1 && player3_num < 11)
            {
                player_num_name = player3_num.ToString();
                player_total += player3_num;
            }
            button7.Text = player_suit_name + player_num_name;
            if (player_total > 21)
            {
                count = 0;
                player_total = computer_total = 0;
                player_chips -= 20;
                computer_chips += 20;
                toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                if (player_chips==0|| computer_chips==0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                DialogResult result = MessageBox.Show("請問是否繼續?", "你爆掉了", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Error);
                if(result==DialogResult.OK)
                {
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 0 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;

                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();


                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";

                    button1.Enabled = button3.Enabled=button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;
                    
                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
        }
        
        int player4 = 0;
        int player4_num = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            button8.Enabled = false;
            //選牌
            player4 = r.Next(1, 53);
            //不能選別人選過的
            while (player4 == computer1 || player4 == player1 || player4 == player2|| player4 == player3)
            {
                player4 = r.Next(1, 53);
            }
            //牌號
            player4_num = player4 % 13;
            //判斷花色
            int player4_suit = (player4 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (player4_suit == i)
                {
                    player_suit_name = suit[i];
                }
            }
            //數字轉換
            if (player4_num == 11)
            {
                player_num_name = "J";
                player_total += 10;
            }
            if (player4_num == 12)
            {
                player_num_name = "Q";
                player_total += 10;
            }
            if (player4_num == 0)
            {
                player_num_name = "K";
                player_total += 10;
            }
            if (player4_num == 1)
            {
                player_num_name = "A";
                button8.Text = player_suit_name + player_num_name;
                DialogResult result = MessageBox.Show("請問是否將此張牌賦值為1？確定賦值為1，取消賦值為11"
                    , "詢問", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    player_total += 1;
                }
                else if (result == DialogResult.Cancel)
                {
                    player_total += 11;
                }
            }
            if (player4_num > 1 && player4_num < 11)
            {
                player_num_name = player4_num.ToString();
                player_total += player4_num;
            }
            button8.Text = player_suit_name + player_num_name;
            if (player_total > 21)
            {
                count = 0;
                player_total = computer_total = 0;
                player_chips -= 20;
                computer_chips += 20;
                toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                if (player_chips == 0 || computer_chips == 0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                DialogResult result = MessageBox.Show("請問是否繼續?", "你爆掉了", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 0 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;

                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();


                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";

                    button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;

                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
        }
        int player5 = 0;
        int player5_num = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            button9.Enabled = false;
            //選牌
            player5 = r.Next(1, 53);
            //不能選別人選過的
            while (player5 == computer1 || player5 == player1 || player5 == player2 || player5 == player3||player5==player4)
            {
                player5 = r.Next(1, 53);
            }
            //牌號
            player5_num = player5 % 13;
            //判斷花色
            int player5_suit = (player5 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (player5_suit == i)
                {
                    player_suit_name = suit[i];
                }
            }
            //數字轉換
            if (player5_num == 11)
            {
                player_num_name = "J";
                player_total += 10;
            }
            if (player5_num == 12)
            {
                player_num_name = "Q";
                player_total += 10;
            }
            if (player5_num == 0)
            {
                player_num_name = "K";
                player_total += 10;
            }
            if (player5_num == 1)
            {
                player_num_name = "A";
                button9.Text = player_suit_name + player_num_name;
                DialogResult result = MessageBox.Show("請問是否將此張牌賦值為1？確定賦值為1，取消賦值為11"
                    , "詢問", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    player_total += 1;
                }
                else if (result == DialogResult.Cancel)
                {
                    player_total += 11;
                }
            }
            if (player5_num > 1 && player5_num < 11)
            {
                player_num_name = player5_num.ToString();
                player_total += player5_num;
            }
            button9.Text = player_suit_name + player_num_name;
            if (player_total > 21)
            {
                count = 0;
                player_total = computer_total = 0;
                player_chips -= 20;
                computer_chips += 20;
                toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                if (player_chips == 0 || computer_chips == 0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                DialogResult result = MessageBox.Show("請問是否繼續?", "你爆掉了", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 0 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;

                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();

                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
                    button1.Enabled=button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;
                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
            else if (player_total <= 21)
            {
                count = 0;
                player_total = computer_total = 0;
                player_chips += 20;
                computer_chips -= 20;
                toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                if (player_chips == 0 || computer_chips == 0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                if ((button3.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled) == false)
                {
                    DialogResult result = MessageBox.Show("請問是否繼續?", "恭喜!過五關", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        //電腦的第一張選牌
                        computer1 = r.Next(1, 53);
                        //牌號
                        computer1_num = computer1 % 13;
                        //判斷花色
                        int computer1_suit = (computer1 - 1) / 13;
                        //花色轉換
                        for (int i = 0; i < 4; i++)
                        {
                            if (computer1_suit == i)
                            {
                                computer_suit_name = suit[i];
                            }
                        }
                        //數字轉換
                        if (computer1_num == 11)
                        {
                            computer_num_name = "J";
                        }
                        else if (computer1_num == 12)
                        {
                            computer_num_name = "Q";
                        }
                        else if (computer1_num == 0)
                        {
                            computer_num_name = "K";
                        }
                        else if (computer1_num == 1)
                        {
                            computer_num_name = "A";
                        }
                        else if (computer1_num > 0 && computer1_num < 11)
                        {
                            computer_num_name = computer1_num.ToString();
                        }
                        button10.Text = computer_suit_name + computer_num_name;
                        button10.Enabled = false;

                        button5.Hide();
                        button11.Hide();
                        button12.Hide();
                        button13.Hide();
                        button6.Hide();
                        button7.Hide();
                        button8.Hide();
                        button9.Hide();

                        button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
                        button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                            = button11.Enabled = button12.Enabled = button13.Enabled = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        f2.StartPosition = FormStartPosition.Manual;
                        f2.Location = new Point(this.Location.X, this.Location.Y);
                        f2.Show();
                        this.Hide();
                    }
                }
            }
        }


        int computer2 = 0;
        int computer3 = 0;
        int computer4 = 0;
        int computer5 = 0;
        int computer2_num = 0;
        int computer3_num = 0;
        int computer4_num = 0;
        int computer5_num = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled=button3.Enabled= button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled= false;

            if (computer1_num == 11)
            {
                computer_total += 10;
            }
            else if (computer1_num == 12)
            {
                computer_total += 10;
            }
            else if (computer1_num == 0)
            {
                computer_total = computer_total + 10;
            }
            else if (computer1_num == 1)
            {
                computer_total += 11;
            }
            else if (computer1_num > 1 && computer1_num < 11)
            {
                computer_total += computer1_num;
            }
            button10.Enabled = false;
            

            //電腦選牌
            computer2 = r.Next(1, 53);
            while(computer2==computer1||computer2==computer3||computer2==computer4||computer2==computer5
                ||computer2==player1||computer2==player2||computer2==player3||computer2==player4||computer2==player5)
            {
                computer2 = r.Next(1, 53);
            }
            //牌號
            computer2_num = computer2 % 13;
            //判斷花色
            int computer2_suit = (computer2 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (computer2_suit == i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer2_num == 11)
            {
                computer_num_name = "J";
                computer_total += 10;
                if(computer_total<=21)
                {
                    button5.Enabled = false;
                    button5.Show();
                }
                else if(computer_total>21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer2_num == 12)
            {
                computer_num_name = "Q";
                computer_total += 10;
                if (computer_total <= 21)
                {
                    button5.Enabled = false;
                    button5.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer2_num == 0)
            {
                computer_num_name = "K";
                computer_total = computer_total + 10;
                if (computer_total <=21)
                {
                    button5.Enabled = false;
                    button5.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer2_num == 1)
            {
                computer_num_name = "A";
                if (computer_total <=10)
                {
                    computer_total += 11;
                    button5.Enabled = false;
                    button5.Show();
                }
                else if (computer_total >10&& computer_total <21)
                {
                    computer_total += 1;
                    button5.Enabled = false;
                    button5.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -=1;
                }
            }
            else if (computer2_num > 1 && computer2_num < 11)
            {
                computer_num_name = computer2_num.ToString();
                if (computer_total <= 21)
                {
                    computer_total += computer2_num;
                    button5.Enabled = false;
                    button5.Show();
                }
                else if(computer_total>21)
                {
                    computer_total -= computer2_num;
                }
            }
            button5.Text = computer_suit_name + computer_num_name;



            //電腦選牌
            computer3 = r.Next(1, 53);
            while (computer3 == computer1 || computer3 == computer2 || computer3 == computer4 || computer3 == computer5
                || computer3 == player1 || computer3 == player2 || computer3 == player3 || computer3 == player4 || computer3 == player5)
            {
                computer3 = r.Next(1, 53);
            }
            //牌號
            computer3_num = computer3 % 13;
            //判斷花色
            int computer3_suit = (computer3 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (computer3_suit == i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer3_num == 11)
            {
                computer_num_name = "J";
                computer_total += 10;
                if (computer_total <= 21 && button5.Enabled == false)
                {
                    button11.Enabled = false;
                    button11.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer3_num == 12)
            {
                computer_num_name = "Q";
                computer_total += 10;
                if (computer_total <= 21 && button5.Enabled == false)
                {
                    button11.Enabled = false;
                    button11.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer3_num == 0)
            {
                computer_num_name = "K";
                computer_total = computer_total + 10;
                if (computer_total <= 21 && button5.Enabled == false)
                {
                    button11.Enabled = false;
                    button11.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer3_num == 1)
            {
                computer_num_name = "A";
                if (computer_total <= 10 && button5.Enabled == false)
                {
                    computer_total += 11;
                    button11.Enabled = false;
                    button11.Show();
                }
                else if (computer_total > 10 && computer_total < 21 && button5.Enabled == false)
                {
                    computer_total += 1;
                    button11.Enabled = false;
                    button11.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 1;
                }
            }
            else if (computer3_num > 1 && computer3_num < 11)
            {
                computer_num_name = computer3_num.ToString();
                computer_total += computer3_num;
                if (computer_total <= 21 && button5.Enabled == false)
                {
                    button11.Enabled = false;
                    button11.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= computer3_num;
                }
            }
            button11.Text = computer_suit_name + computer_num_name;
            //電腦選牌
            computer3 = r.Next(1, 53);
            while (computer3 == computer1 || computer3 == computer2 || computer3 == computer4 || computer3 == computer5
                || computer3 == player1 || computer3 == player2 || computer3 == player3 || computer3 == player4 || computer3 == player5)
            {
                computer3 = r.Next(1, 53);
            }


            //牌號
            computer4_num = computer4 % 13;
            while (computer4 == computer1 || computer4 == computer3 || computer4 == computer3 || computer4 == computer5
               || computer4 == player1 || computer4 == player2 || computer4 == player3 || computer4 == player4 || computer4 == player5)
             {
                  computer4 = r.Next(1, 53);
              }

                //判斷花色
            int computer4_suit = (computer4 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (computer4_suit == i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer4_num == 11)
            {
                computer_num_name = "J";
                computer_total += 10;
                if (computer_total <= 21 && button5.Enabled == false&&button11.Enabled==false)
                {
                    button12.Enabled = false;
                    button12.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer4_num == 12)
            {
                computer_num_name = "Q";
                computer_total += 10;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false)
                {
                    button12.Enabled = false;
                    button12.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer4_num == 0)
            {
                computer_num_name = "K";
                computer_total = computer_total + 10;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false)
                {
                    button12.Enabled = false;
                    button12.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer4_num == 1)
            {
                computer_num_name = "A";
                if (computer_total <= 10 && button5.Enabled == false && button11.Enabled == false)
                {
                    computer_total += 11;
                    button12.Enabled = false;
                    button12.Show();
                }
                else if (computer_total > 10 && computer_total < 21 && button5.Enabled == false && button11.Enabled == false)
                {
                    computer_total += 1;
                    button12.Enabled = false;
                    button12.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 1;
                }
            }
            else if (computer4_num > 1 && computer4_num < 11)
            {
                computer_num_name = computer4_num.ToString();
                computer_total += computer4_num;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false)
                {
                    button12.Enabled = false;
                    button12.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= computer4_num;
                }
            }
            button12.Text = computer_suit_name + computer_num_name;

            //牌號
            computer5_num = computer5 % 13;
            while (computer5 == computer1 || computer5 == computer3 || computer5 == computer3 || computer5 == computer4
             || computer5 == player1 || computer5 == player2 || computer5 == player3 || computer5 == player4 || computer5 == player5)
            {
                computer5 = r.Next(1, 53);
            }
            //判斷花色
            int computer5_suit = (computer5 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (computer5_suit == i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer5_num == 11)
            {
                computer_num_name = "J";
                computer_total += 10;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false && button12.Enabled == false)
                {
                    button13.Enabled = false;
                    button13.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer5_num == 12)
            {
                computer_num_name = "Q";
                computer_total += 10;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false && button12.Enabled == false)
                {
                    button13.Enabled = false;
                    button13.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer5_num == 0)
            {
                computer_num_name = "K";
                computer_total = computer_total + 10;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false && button12.Enabled == false)
                {
                    button13.Enabled = false;
                    button13.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 10;
                }
            }
            else if (computer5_num == 1)
            {
                computer_num_name = "A";
                if (computer_total <= 10 && button5.Enabled == false && button11.Enabled ==false && button12.Enabled == false)
                {
                    computer_total += 11;
                    button13.Enabled = false;
                    button13.Show();
                }
                else if (computer_total > 10 && computer_total < 21 && button5.Enabled == false && button11.Enabled == false && button12.Enabled == false)
                {
                    computer_total += 1;
                    button13.Enabled = false;
                    button13.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= 1;
                }
            }
            else if (computer5_num > 1 && computer5_num < 11)
            {
                computer_num_name = computer5_num.ToString();
                computer_total += computer5_num;
                if (computer_total <= 21 && button5.Enabled == false && button11.Enabled == false && button12.Enabled == false)
                {
                    button13.Enabled = false;
                    button13.Show();
                }
                else if (computer_total > 21)
                {
                    computer_total -= computer5_num;
                }
            }
            button13.Text = computer_suit_name + computer_num_name;


            if (player_total > computer_total && player_total != 0 && computer_total != 0)
            {
                Form2 f2 = new Form2();
                count = 0;
                if (player_chips == 0 || computer_chips == 0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                DialogResult result = MessageBox.Show("請問是否繼續?", "恭喜你贏了", MessageBoxButtons.OKCancel
                  , MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    player_total = computer_total = 0;
                    player_chips += 20;
                    computer_chips -= 20;
                    toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 1 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;

                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();

                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
                    button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;
                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
            if (player_total < computer_total && player_total != 0 && computer_total != 0)
            {
                count = 0;
                Form2 f2 = new Form2();
                if (player_chips == 0 || computer_chips == 0)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
                DialogResult result = MessageBox.Show("請問是否繼續?", "可惜你輸了", MessageBoxButtons.OKCancel
                  , MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    player_total = computer_total = 0;
                    player_chips -= 20;
                    computer_chips += 20;
                    toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 1 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;

                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();

                    button3.Text = "翻牌";

                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
                    button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;
                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
            if (player_total == computer_total && player_total != 0 && computer_total != 0)
            {
                count = 0;
                Form f2 = new Form2();
                DialogResult result = MessageBox.Show("請問是否繼續?", "可惜平手了", MessageBoxButtons.OKCancel
                  , MessageBoxIcon.Information);
                toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                if (result == DialogResult.OK)
                {
                    player_total = computer_total = 0;
                    toolStripStatusLabel1.Text = "玩家剩餘金額:" + player_chips.ToString() + "電腦剩餘金額:" + computer_chips.ToString();
                    //電腦的第一張選牌
                    computer1 = r.Next(1, 53);
                    //牌號
                    computer1_num = computer1 % 13;
                    //判斷花色
                    int computer1_suit = (computer1 - 1) / 13;
                    //花色轉換
                    for (int i = 0; i < 4; i++)
                    {
                        if (computer1_suit == i)
                        {
                            computer_suit_name = suit[i];
                        }
                    }
                    //數字轉換
                    if (computer1_num == 11)
                    {
                        computer_num_name = "J";
                    }
                    else if (computer1_num == 12)
                    {
                        computer_num_name = "Q";
                    }
                    else if (computer1_num == 0)
                    {
                        computer_num_name = "K";
                    }
                    else if (computer1_num == 1)
                    {
                        computer_num_name = "A";
                    }
                    else if (computer1_num > 1 && computer1_num < 11)
                    {
                        computer_num_name = computer1_num.ToString();
                    }
                    button10.Text = computer_suit_name + computer_num_name;
                    button10.Enabled = false;
                    button5.Hide();
                    button11.Hide();
                    button12.Hide();
                    button13.Hide();
                    button6.Hide();
                    button7.Hide();
                    button8.Hide();
                    button9.Hide();

                    button3.Text = "翻牌";

                    button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
                    button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                        = button11.Enabled = button12.Enabled = button13.Enabled = true;
                }
                else if (result == DialogResult.Cancel)
                {
                    f2.StartPosition = FormStartPosition.Manual;
                    f2.Location = new Point(this.Location.X, this.Location.Y);
                    f2.Show();
                    this.Hide();
                }
            }
        }



        private void 結束遊戲SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 場景變更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change++;
            if (change % 2 == 1)
            {
                this.BackColor = Color.Blue;
            }
            else if (change % 2 == 0)
            {
                this.BackColor = Color.Green;
            }
        }

        private void 重玩RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player_total = computer_total = 0;
            //電腦的第一張選牌
            computer1 = r.Next(1, 53);
            //牌號
            computer1_num = computer1 % 13;
            //判斷花色
            int computer1_suit = (computer1 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (computer1_suit == i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer1_num == 11)
            {
                computer_num_name = "J";
            }
            else if (computer1_num == 12)
            {
                computer_num_name = "Q";
            }
            else if (computer1_num == 0)
            {
                computer_num_name = "K";
            }
            else if (computer1_num == 1)
            {
                computer_num_name = "A";
            }
            else if (computer1_num > 1 && computer1_num < 11)
            {
                computer_num_name = computer1_num.ToString();
            }
            button10.Text = computer_suit_name + computer_num_name;
            button10.Enabled = false;

            button5.Hide();
            button11.Hide();
            button12.Hide();
            button13.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();

            button3.Text = "翻牌";
            
            button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
            button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                = button11.Enabled = button12.Enabled = button13.Enabled = true;
        }

        int change=0;
        private void 場景變更ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            change++;
            if(change%2==1)
            {
                this.BackColor = Color.Blue;
            }
            else if(change%2==0)
            {
                this.BackColor = Color.Green;
            }
        }

        private void 重玩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player_total = computer_total = 0;
            //電腦的第一張選牌
            computer1 = r.Next(1, 53);
            //牌號
            computer1_num = computer1 % 13;
            //判斷花色
            int computer1_suit = (computer1 - 1) / 13;
            //花色轉換
            for (int i = 0; i < 4; i++)
            {
                if (computer1_suit == i)
                {
                    computer_suit_name = suit[i];
                }
            }
            //數字轉換
            if (computer1_num == 11)
            {
                computer_num_name = "J";
            }
            else if (computer1_num == 12)
            {
                computer_num_name = "Q";
            }
            else if (computer1_num == 0)
            {
                computer_num_name = "K";
            }
            else if (computer1_num == 1)
            {
                computer_num_name = "A";
            }
            else if (computer1_num > 1 && computer1_num < 11)
            {
                computer_num_name = computer1_num.ToString();
            }
            button10.Text = computer_suit_name + computer_num_name;
            button10.Enabled = false;

            button5.Hide();
            button11.Hide();
            button12.Hide();
            button13.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();

            button3.Text = "翻牌";
            
            button3.Text = button6.Text = button7.Text = button8.Text = button9.Text = "翻牌";
            button1.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled
                = button11.Enabled = button12.Enabled = button13.Enabled = true;
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;

            if(count==1)
            {
                button6.Show();
            }
            else if (count == 2)
            {
                button7.Show();
            }
            else if (count == 3)
            {
                button8.Show();
            }
            else if (count == 4)
            {
                button9.Show();
            }
        }
    }  
}
