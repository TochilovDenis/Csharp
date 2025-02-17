using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder cmd = null;
        string cs = "";


        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["MyConnString"].
            ConnectionString;
            conn.ConnectionString = cs;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn =  new SqlConnection(cs);
                set = new DataSet();
                string sql = "SELECT * FROM Authors;" + "SELECT * FROM Books;";
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;
                cmd = new SqlCommandBuilder(da);

                //Debug.WriteLine(cmd.GetInsertCommand().CommandText);
                //Debug.WriteLine(cmd.GetUpdateCommand().CommandText);
                //Debug.WriteLine(cmd.GetDeleteCommand().CommandText);

                da.TableMappings.Add("Table", "Authors");
                da.TableMappings.Add("Table1", "Books");
                da.Fill(set);

                dataGridView1.DataSource = set.Tables["Books"];
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            da.Update(set, "mybook");
        }
    }

}
