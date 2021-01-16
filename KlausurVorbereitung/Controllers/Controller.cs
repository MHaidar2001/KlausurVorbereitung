using KlausurVorbereitung.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace KlausurVorbereitung
{
    public class Controller
    {
        #region Eigenschaften
        private List<Models.Personen> _list;

        #endregion

        #region Accessoren/Modifier
        public List<Personen> List { get => _list; set => _list = value; }

        #endregion

        #region Konstruktoren
        public Controller()
        {
            List = new List<Personen>();
        }
        #endregion

        #region Worker
        public void LoadAllDateFromAPI()
        {
            List.Clear();
            HttpClient client = new HttpClient();

            string url = "http://localhost:44353/api/Message";


            Task<HttpResponseMessage> response = client.GetAsync(url);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return;
            }

            HttpResponseMessage result = response.Result;

            Task<string> content = result.Content.ReadAsStringAsync();

            try
            {
                content.Wait();
            }
            catch (Exception)
            {

            }

            string empfang = content.Result;

            List = (List<Models.Personen>)JsonConvert.DeserializeObject<List<Models.Personen>>(empfang).ToList();
        }

        public void AddPerson(string text1, string text2, string text3)
        {
            Models.Personen pers = new Personen(0, text1, text2, text3);
            pers.PostToAPI();
        }

        public void UpdatePerson(int eDITID, string text1, string text2, string text3)
        {
            Models.Personen pers = new Personen();
            for (int index = 0; index < List.Count; index++)
            {
                if (List[index].Id == eDITID)
                {
                    pers.Name = text1;
                    pers.Vorname = text2;
                    pers.Geburtsdatum = text3;
                }
            }
            pers.EditToAPI(eDITID);

        }

        public void DeletePerson(string text)
        {
            Personen per = new Personen();
            per.DeleteToAPI(text);
        }
        #endregion

    }
}