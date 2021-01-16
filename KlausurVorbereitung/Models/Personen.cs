using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace KlausurVorbereitung.Models
{
    public class Personen
    {
        #region Eigenschaften
        private int _id;
        private string _Name;
        private string _vorname;
        private string _geburtsdatum;

        #endregion

        #region Accessoren/Modifier
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        public string Geburtsdatum { get => _geburtsdatum; set => _geburtsdatum = value; }

        #endregion

        #region Konstruktoren
        public Personen()
        {
            Id = 0;
            Name = "";
            Vorname = "";
            Geburtsdatum = "";
        } 
        public Personen( int id,string v1,string v2,string v3)
        {
            Id = id;
            Name = v1;
            Vorname = v2;
            Geburtsdatum = v3;
        }


        #endregion

        #region Worker
        public  void PostToAPI()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44353/api/Message";

            string json = JsonConvert.SerializeObject(this);

            Task<HttpResponseMessage> response = client.PostAsJsonAsync(url, json);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {

            }
        }

        public void EditToAPI(int eDITID)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44353/api/Message";
            string json = JsonConvert.SerializeObject(this);

            //senden
            Task<HttpResponseMessage> response = client.PutAsJsonAsync(url + "/" + eDITID.ToString(), json);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {

            }
        }

        public void DeleteToAPI(string text)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44353/api/Message";

            //senden
            Task<HttpResponseMessage> response = client.DeleteAsync(url + "/" + text);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}