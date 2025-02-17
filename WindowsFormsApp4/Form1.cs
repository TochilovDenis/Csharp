using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable table = new DataTable(); //создана пустая
                                               //таблица
            table.Columns.Add("id");//создана новая колонка id
            table.Columns.Add("FirstName");//создана новая
                                           //колонка FirstName
            table.Columns.Add("LastName"); //создана новая
                                           //колонка LastName
                                           //теперь можно заносить в таблицу строки
                                           //каждая строка — это объект типа DataRow
            DataRow row = table.NewRow();
            //метод NewRow() создает строку соответствующую
            //таблице, от имени которой он вызван
            //в нашем случае row будет массивом из трех элементов
            //потому, что мы уже сформировали в table три колонки
            //заполним элементы объекта row подходящими данными
            //и занесем в таблицу
            row[0] = 1;
            row[1] = "Francis";
            row[2] = "Becon";
            table.Rows.Add(row);//в таблицу добавлена новая строка
                                //другие строки добавляются аналогично
            dataGridView1.DataSource = table; 
        }


    }
}
