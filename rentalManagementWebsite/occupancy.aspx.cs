﻿using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace rentalManagementWebsite
{
    public partial class occupancy : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();
            lblUsername.Text = "LANDLORD: " + username;

            if (!IsPostBack)
            {
                DataTable dt = GetDataFromOracleDatabase();


                adminGridView.DataSource = dt;
                adminGridView.DataBind();
            }


        }

        private DataTable GetDataFromOracleDatabase()
        {
            DataTable dt = new DataTable();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {

                string query = "SELECT * FROM \"OCCUPANCY\"";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

    }
}
