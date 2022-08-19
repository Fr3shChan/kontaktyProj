using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rekrutacyjneZad
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //Metoda, która w zależności od zalogowania użytkownika ustala widoczność na pasku nawigaycjnym
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; //widoczność przycisku Login 
                    LinkButton2.Visible = false; //widoczność przycisku logout
                    LinkButton3.Visible = false; //widoczność przycisku hello user
                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //widoczność przycisku Login 
                    LinkButton2.Visible = true; //widoczność przycisku logout
                    LinkButton3.Visible = true; //widoczność przycisku hello user
                    LinkButton3.Text = "Witaj " + Session["username"].ToString();
                }               
            }
            catch (Exception ex)
            {

            }           
        }
        //Metoda, która przekierowuje za pomocą przycisku do userLogin.aspx
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        //Metoda, która przekierowuje za pomocą przycisku do userProfile.aspx
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }


        // Metoda służąca do wylogownia
        protected void LinkButton2_Click(object sender, EventArgs e) 
        {
            Session["username"] = "";
            Session["role"] = "";


            LinkButton1.Visible = true; //widoczność przycisku Login 
            LinkButton2.Visible = false; //widoczność przycisku logout
            LinkButton3.Visible = false; //widoczność przycisku Witaj user
        }
    }
}