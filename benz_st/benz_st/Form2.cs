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
    public partial class Form2 : MaterialForm
    {
        private readonly int топлива;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "appData.Расчет_продажи_суммы". При необходимости она может быть перемещена или удалена.
            listBox1.Visible = false;
            //обновляем данные
            //расчет_продажи_суммыTableAdapter.Update(appData);
           
            // TODO: данная строка кода позволяет загрузить данные в таблицу "appData.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.appData.users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "appData.Фирмы". При необходимости она может быть перемещена или удалена.
            this.фирмыTableAdapter.Fill(this.appData.Фирмы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "appData.Топливо". При необходимости она может быть перемещена или удалена.
            this.топливоTableAdapter.Fill(this.appData.Топливо);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { usersBindingSource.Filter = "[login] LIKE'" + textBox2.Text + "%'"; }
            catch { MessageBox.Show("Error!"); }
                
                
                        }

        private void добавитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                appData.users.AddusersRow(appData.users.NewusersRow());
                usersBindingSource.EndEdit();
                usersBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Увдомление об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void удалитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usersBindingSource.RemoveCurrent();
            usersBindingSource.EndEdit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usersTableAdapter.Update(appData);
            usersBindingSource.EndEdit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           usersBindingSource.Filter = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().Contains(textBox3.Text))
                        {
                            dataGridView2.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void добавитьФирмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                appData.Фирмы.AddФирмыRow(appData.Фирмы.NewФирмыRow());
                фирмыBindingSource.EndEdit();
                фирмыBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Увдомление об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void удалитьФирмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            фирмыBindingSource.RemoveCurrent();
            фирмыBindingSource.EndEdit();
        }

        private void firms_Opening(object sender, CancelEventArgs e)
        {

        }

        private void сохранитьВсеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           фирмыTableAdapter.Update(appData);
           
        }

       

        private void удалитьТопливоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            топливоBindingSource.RemoveCurrent();
            топливоBindingSource.EndEdit();
        }

        private void сохранитьВсеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            топливоTableAdapter.Update(appData);
        }
       
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
               

               appData.Расчет_продажи_суммы.AddРасчет_продажи_суммыRow(appData.Расчет_продажи_суммы.NewРасчет_продажи_суммыRow());
               расчетПродажиСуммыBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Увдомление об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void количествоTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void количествоTextBox_KeyUp(object sender, KeyEventArgs e)
        {
         
        }
        //это бенз
        //лукойла
        int AI95l = 50;
        int AI98l = 55;
        int AI92l =45;
        //у газпрома подороже
        int AI95g = 53;
        int AI98g = 58;
        int AI92g = 47;
        int sum = 0;
        private void количествоTextBox_TextChanged(object sender, EventArgs e)
        {
            
            try
            {//лукойл
                if (вид_топливаComboBox.Text == "АИ-95")
                {
                   
                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI95l);
                    стоимостьLabel1.Text = result.ToString();
                   
                }
                else if (вид_топливаComboBox.Text == "АИ-98") {
                   
                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI98l);
                    стоимостьLabel1.Text = result.ToString();
              
                }
                else if (вид_топливаComboBox.Text == "АИ-92")
                {
                    
                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI92l);
                    стоимостьLabel1.Text = result.ToString();
                 
                }
                //газпром
                if (вид_топливаComboBox.Text == "АИ-95")
                {

                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI95g);
                    стоимостьLabel1.Text = result.ToString();

                }
                else if (вид_топливаComboBox.Text == "АИ-98")
                {

                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI98g);
                    стоимостьLabel1.Text = result.ToString();

                }
                else if (вид_топливаComboBox.Text == "АИ-92")
                {

                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI92g);
                    стоимостьLabel1.Text = result.ToString();

                }


            }
            catch (Exception) {}

            }

        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                appData.Расчет_продажи_суммы.AddРасчет_продажи_суммыRow(appData.Расчет_продажи_суммы.NewРасчет_продажи_суммыRow());
               расчетПродажиСуммыBindingSource.EndEdit();
                расчетПродажиСуммыBindingSource.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", "Увдомление об ошибке", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }
        //это если меняется вид бензина
        private void вид_топливаComboBox_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (вид_топливаComboBox.Text == "АИ-95")
                {

                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI95l);
                    стоимостьLabel1.Text = result.ToString();

                }
                else if (вид_топливаComboBox.Text == "АИ-98")
                {

                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI98l);
                    стоимостьLabel1.Text = result.ToString();

                }
                else if (вид_топливаComboBox.Text == "АИ-92")
                {

                    int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI92l);
                    стоимостьLabel1.Text = result.ToString();

                }


            }
            catch (Exception) { }

        }
        //вот тут зависит от выбора фирмы цена за литр бензина
        private void название_фирмыComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (название_фирмыComboBox.Text == "Лукойл")
                {

                    if (вид_топливаComboBox.Text == "АИ-95")
                    {

                        int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI95l);
                        стоимостьLabel1.Text = result.ToString();

                    }
                    else if (вид_топливаComboBox.Text == "АИ-98")
                    {

                        int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI98l);
                        стоимостьLabel1.Text = result.ToString();

                    }
                    else if (вид_топливаComboBox.Text == "АИ-92")
                    {

                        int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI92l);
                        стоимостьLabel1.Text = result.ToString();

                    }
                }
            }
            catch (Exception) { }
            try
            {
                //газпром
                if (название_фирмыComboBox.Text == "Газпром")
                {

                    if (вид_топливаComboBox.Text == "АИ-95")
                    {

                        int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI95g);
                        стоимостьLabel1.Text = result.ToString();

                    }
                    else if (вид_топливаComboBox.Text == "АИ-98")
                    {

                        int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI98g);
                        стоимостьLabel1.Text = result.ToString();

                    }
                    else if (вид_топливаComboBox.Text == "АИ-92")
                    {

                        int result = Convert.ToInt32(количествоTextBox.Text) * Convert.ToInt32(AI92g);
                        стоимостьLabel1.Text = result.ToString();

                    }

                }
            }
            catch (Exception) { }




        }

        private void название_фирмыLabel_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           Form3 otch =new  Form3();
            otch.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Add("Получен чек!Клиент оформлен!");
            listBox1.Items.Add(item: "ФИО:"+фИОTextBox.Text);
            listBox1.Items.Add(DateTime.Now.ToString("Текущее время: HH:mm:ss"));
            listBox1.Items.Add(item: "Дата продажи:" +дата_продажиDateTimePicker.Text );
            listBox1.Items.Add(item: "Вид топлива:" + вид_топливаComboBox.Text);
            listBox1.Items.Add(item: "количество литров:" + количествоTextBox.Text);
            listBox1.Items.Add(item: "Вид топлива:" + вид_топливаComboBox.Text);
            listBox1.Items.Add(item: "Название фирмы:" + название_фирмыComboBox.Text);
            listBox1.Items.Add(item: "Спасибо что пользуйетесь нашими услугами!:)");

         
              
        }

        private void button9_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                dataGridView5.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView5.ColumnCount; j++)
                    if (dataGridView5.Rows[i].Cells[j].Value != null)
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().Contains(toolStripTextBox1.Text))
                        {
                            dataGridView5.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            расчетПродажиСуммыBindingSource.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            расчетПродажиСуммыBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            расчетПродажиСуммыBindingSource.MoveFirst();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            расчетПродажиСуммыBindingSource.MoveNext();
        }
    }

    
    
           
}
    


























//сделано с поддержкой sdweg196 без него ничего бы не вышло :))