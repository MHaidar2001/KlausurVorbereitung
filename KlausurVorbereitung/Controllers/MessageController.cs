using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KlausurVorbereitung.Controllers
{
    public class MessageController : ApiController
    {
        #region Eigenschaften
        private Controller _verwalter;

        #endregion

        #region Accessoren/Modifier
        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        #endregion

        #region Konstruktoren
        public MessageController():base()
        {
            Verwalter = Global.Verwalter;
        }
        #endregion

        #region Worker
        // GET: api/Message
        public List<Models.Personen> Get()
        {
            List<Models.Personen> list = new List<Models.Personen>();
            string connectionstring = "Server=localhost;Port=3307;Database=klausur vorbereitung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "SELECT * FROM `person` ;";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetValue(0).ToString();
                        string x1 = reader.GetValue(1).ToString();
                        string x2 = reader.GetValue(2).ToString();
                        string x3 = reader.GetValue(3).ToString();
                        Models.Personen value1 = new Models.Personen(Convert.ToInt32(id), x1, x2,x3);
                        list.Add(value1);
                    }
                }
                else
                { }
            }
            catch (Exception)
            {
                return new List<Models.Personen>();
            }
            conn.Close();
            return list;

        }

        // GET: api/Message/5
        public Models.Personen Get(int id)
        {
            Models.Personen pers = new Models.Personen();
            string connectionstring = "Server=localhost;Port=3307;Database=klausur vorbereitung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "SELECT * FROM `person` where id="+id;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id1 = reader.GetValue(0).ToString();
                        string x1 = reader.GetValue(1).ToString();
                        string x2 = reader.GetValue(2).ToString();
                        string x3 = reader.GetValue(3).ToString();
                        Models.Personen value1 = new Models.Personen(Convert.ToInt32(id1), x1, x2, x3);
                    }
                }
                else
                { }
            }
            catch (Exception)
            {
            }
            conn.Close();
            return pers;
        }

        // POST: api/Message
        public void Post([FromBody]string value)
        {
            Models.Personen value1 = (Models.Personen)JsonConvert.DeserializeObject(value, typeof(Models.Personen));

            string connectionstring = "Server=localhost;Port=3307;Database=klausur vorbereitung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "INSERT INTO `person`(`ID`, `Name`, `vorname`, `Geburtsdatum`) VALUES (Null,'"+value1.Name+"','"+value1.Vorname+"','"+value1.Geburtsdatum+"')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                }
                else
                {
                }
            }
            catch (Exception)
            {

            }
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
            string ergebnis = "false;";
            Models.Personen value1 = (Models.Personen)JsonConvert.DeserializeObject(value, typeof(Models.Personen));
            string connectionstring = "Server=localhost;Port=3307;Database=klausur vorbereitung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "UPDATE `person` SET `Name`='"+value1.Name+"',`vorname`='"+value1.Vorname+"',`Geburtsdatum`='"+value1.Geburtsdatum+"' WHERE id="+id;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                    ergebnis = "false";
                }
                else
                {
                    ergebnis = "ok";
                }
            }
            catch (Exception)
            {
            }
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
            string connectionstring = "Server=localhost;Port=3307;Database=klausur vorbereitung; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "DELETE FROM `Person` WHERE `ID` = " + id ;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
       
    }
}
