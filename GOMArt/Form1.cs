using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOMArt
{
    public partial class Form1 : Form
    {
        DBConnection dBCon = new DBConnection();
        public static string loginname, logintype;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRole.SelectedIndex > 0)
                {
                    if (txtUsername.Text == String.Empty)
                    {
                        MessageBox.Show("Enter UserName");
                        txtUsername.Focus();
                        return;

                    }
                    if (txtUsername.Text == String.Empty && txtPassword.Text != String.Empty)
                    {
                        //MessageBox.Show("Please Enter Valid User PAssword");
                    }
                    if (cmbRole.SelectedIndex > 0 && txtUsername.Text != String.Empty && txtPassword.Text != String.Empty)

                    {
                        //logincode
                        if (cmbRole.Text == "Admin")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 AdminId, Password, Fullname from tblAdmin where AdminID=@AdminID and Password=@PAssword", dBCon.GetCon());
                            cmd.Parameters.AddWithValue("@AdminId", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                            dBCon.Open();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0) { MessageBox.Show("LOgin Success");
                                loginname = txtUsername.Text;
                                logintype = cmbRole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Error LOging in");
                            }

                        }
                        else if (cmbRole.Text == "Seller")
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid User PAssword");
                        clrValue();
                    }

                }
                else {
                    MessageBox.Show("Select Any Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
        }
        private void clrValue()
        {
            cmbRole.SelectedIndex =0;
            txtUsername.Clear();
            txtPassword.Clear();

        }
    }
}
