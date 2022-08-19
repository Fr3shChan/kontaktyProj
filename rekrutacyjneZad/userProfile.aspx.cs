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

    // Plik napisany w C# Który zajmuje się obsługą profilu użytkownika


    // Główna klasa panelu użytkownika
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        //Dodawanie nowgo kontaktu
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkContact())
            {
                Response.Write("<script>alert('Kontakt z takim ID już istnieje');</script>");
            }
            else
            {
                addNewContact();
            }
        }

        //Updatowanie kontaktu
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkContact())
            {
                updateContact();
                
            }
            else
            {
                Response.Write("<script>alert('Kontakt z takim ID nie istnieje');</script>");
            }
        }

        //Usuwanie kontaku
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkContact())
            {
                deleteContact();

            }
            else
            {
                Response.Write("<script>alert('Kontakt z takim ID nie istnieje');</script>");
            }
        }

        //Go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getContactById();
        }


        // Metoda pobierająca dane kontaktów
        void getContactById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM contactTB WHERE contact_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                

                if (dr.Read())
                {
                    TextBox2.Text = dr.GetValue(1).ToString();
                    TextBox3.Text = dr.GetValue(2).ToString();
                    TextBox4.Text = dr.GetValue(3).ToString();
                    TextBox5.Text = dr.GetValue(4).ToString();
                    TextBox6.Text = dr.GetValue(5).ToString();
                    TextBox7.Text = dr.GetValue(6).ToString();
                    TextBox8.Text = dr.GetValue(7).ToString();
                    TextBox9.Text = dr.GetValue(8).ToString();
                }
                else
                {
                    // W przypadku podania złęgo ID kontaktu na ekran zwracany jest poniższy alert
                    Response.Write("<script>alert('Podano złe ID');</script>");
                }

            }
            catch (Exception ex)
            {
                // W przypadku błędu
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }


        //Mertoda służąca do usuwania wskazanego rekordu
        void deleteContact()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM contactTB WHERE contact_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Pomyślnie usunięto kontakt');</script>");
                clearScreen();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Metoda umożliwiająca aktualizację danego wiersza
        void updateContact()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE contactTB SET contact_name=@contact_name, contact_surname=@contact_surname, contact_email=@contact_email, contact_password=@contact_password, contact_category=@contact_category, contact_undercategory=@contact_undercategory, contact_phone=@contact_phone, contact_birthdate=@contact_birthdate WHERE contact_id='"+TextBox1.Text.Trim()+"'", con);
                
                cmd.Parameters.AddWithValue("@contact_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_surname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_password", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_category", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_undercategory", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_phone", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_birthdate", TextBox9.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Pomyślnie zupdatowano kontakt');</script>");
                clearScreen();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        //Metoda tworząca nowego użytkownika 
        void addNewContact()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO contactTB (contact_id, contact_name, contact_surname, contact_email, contact_password, contact_category, contact_undercategory, contact_phone, contact_birthdate) VALUES (@contact_id, @contact_name, @contact_surname, @contact_email, @contact_password, @contact_category, @contact_undercategory, @contact_phone, @contact_birthdate)", con);


                cmd.Parameters.AddWithValue("@contact_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_surname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_password", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_category", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_undercategory", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_phone", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_birthdate", TextBox9.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Pomyślnie dodano nowy kontakt');</script>");
                clearScreen();

                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        //Metoda prawdzająca czy kontakt o danym ID istnieje
        bool checkContact()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM contactTB WHERE contact_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); // zmienna dt przechowuj nam zawartość tabeli
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        //Metoda czyszcąca pola input po każdej z powyższych aktywności 
        void clearScreen()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}