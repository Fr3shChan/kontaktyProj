using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rekrutacyjneZad
{
    public partial class userLogin : System.Web.UI.Page
    {
        //strcon zawiera informacje na temat naszego połączenia z bazą
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Metoda umożliwiąca logowanie użytkownika
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from userTB where user_login='"+TextBox1.Text.Trim()+"' and user_password='"+TextBox2.Text.Trim()+"'", 
                con);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Response.Write("<script>alert('Zalogowano pomyślnie')");
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["role"] = "user";
                    }

                    Response.Redirect("homePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Błąd, błędne dane logowania');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}