using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using WinFormApp.Models;

namespace WinFormApp
{
    public partial class FrmLogin : Form
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public FrmLogin()
        {
            InitializeComponent();
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            _sqlConnectionStringBuilder.DataSource = txtServer.Text;
            _sqlConnectionStringBuilder.InitialCatalog = txtDatabase.Text;
            _sqlConnectionStringBuilder.UserID = txtUserId.Text;
            _sqlConnectionStringBuilder.Password = txtPassword.Text;

            var connectionString = _sqlConnectionStringBuilder.ToString();
            var schema = txtSchema.Text;
            using (var context = new MinimalDbContext(connectionString, schema))
            {
                try
                {
                    var count = context.Product.Count();

                    MessageBox.Show($"Products: {count}", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex?.InnerException?.Message ?? ex.Message, "Error");
                }
            }
        }
    }
}
