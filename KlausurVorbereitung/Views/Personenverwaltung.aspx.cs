using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KlausurVorbereitung.Views
{
    public partial class Personenverwaltung : System.Web.UI.Page
    {
        #region Eigenschaften
        private Controller _verwalter;

        #endregion

        #region Accessoren/Modifier
        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        #endregion

        #region Konstruktoren
        public Personenverwaltung()
        {
            Verwalter = Global.Verwalter;
        }
        
        #endregion

        #region Worker
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoda();
            Button2.Visible = false;
            Button1.Visible = true;

        }

        static int EDITID = 0;
        private void PageLoda()
        {
            Verwalter.LoadAllDateFromAPI();
            for(int index=0;index<Verwalter.List.Count;index++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = Verwalter.List[index].Id.ToString();
                row.Cells.Add(cell);

                 cell = new TableCell();
                cell.Text = Verwalter.List[index].Name;
                row.Cells.Add(cell); 

                 cell = new TableCell();
                cell.Text = Verwalter.List[index].Vorname;
                row.Cells.Add(cell); 

                 cell = new TableCell();
                cell.Text = Verwalter.List[index].Geburtsdatum;
                row.Cells.Add(cell);
                Table1.Rows.Add(row);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Verwalter.AddPerson(TextBox1.Text,TextBox2.Text,TextBox3.Text);
            Response.Redirect("Personenverwaltung.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EDITID = Convert.ToInt32(TextBox4.Text);
            Button1.Visible = false;
            Button2.Visible = true;
            for (int index = 0; index < Verwalter.List.Count; index++)
            {
                if (Verwalter.List[index].Id.ToString() == TextBox4.Text)
                {
                    TextBox1.Text = Verwalter.List[index].Name;
                    TextBox2.Text = Verwalter.List[index].Vorname;
                    TextBox3.Text = Verwalter.List[index].Geburtsdatum;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Verwalter.UpdatePerson(EDITID,TextBox1.Text,TextBox2.Text,TextBox3.Text);
            Response.Redirect("Personenverwaltung.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Verwalter.DeletePerson(TextBox5.Text);
            Response.Redirect("Personenverwaltung.aspx");
        }
    }
    #endregion

}