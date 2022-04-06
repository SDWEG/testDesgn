using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace benz_st
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "")//проверка на ввод пустых значений
            {
                this.errorProvider1.SetError(tbLogin, "Введите ваше имя!");
            }
            else if (tbPass.Text == "") { this.errorProvider1.SetError(tbPass, "Введите ваш пароль!"); }
            else if (AK.Text == "") { this.errorProvider1.SetError(AK, "Выберите должность!"); }
            else
            {
                try
                {
                    AppDataTableAdapters.usersTableAdapter user = new AppDataTableAdapters.usersTableAdapter();
                    AppData.usersDataTable dt = user.GetDataByLP(tbLogin.Text, tbPass.Text, AK.Text);


                    if (dt.Rows.Count > 0)
                    {
                        //вот тут разграничение прав доступа за админа или кассира
                        if (AK.Text == "Администратор")
                        {
                            Form2 admin = new Form2();
                            admin.Show();
                            this.Hide();
                            MessageBox.Show("Успешно,рады видеть тебя   " + tbLogin.Text + "!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else if (AK.Text == "Кассир")
                        {


                            MessageBox.Show("Успешно,рады видеть тебя   " + tbLogin.Text + "!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данные введены не верно.\nПопробуйте еще раз!", "Сотрудник не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
    }
}













































//сделано с поддержкой sdweg196