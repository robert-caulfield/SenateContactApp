using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace SenateContactApp
{
    public class SenatorDataProvider
    {

        //URL of data source
        const string XML_URL = "https://www.senate.gov/general/contact_information/senators_cfm.xml";

        /// <summary>
        /// Asynchronously fetches and deserializes senator data from source
        /// </summary>
        /// <returns>List of senators</returns>
        public static async Task<List<Senator>> RetrieveSenatorData()
        {
            try
            {
                // Download XML file from the URL
                string xmlStringData = await DownloadXmlFile(XML_URL);

                if (xmlStringData == null) return null;

                // Deserialize to list of senator objects 
                SenatorListContainer senatorListContainer = DeserializeXMLString(xmlStringData);


                if (senatorListContainer != null)
                {
                    //Testing async data fetch
                    //await Task.Delay(3000);
                    return senatorListContainer.SenatorList;
                }
                return null;
            }
            catch (Exception ex)
            {
                DisplayException(ex);
                return null;
            }
            
        }
        /// <summary>
        /// Deserializes a given string to senator list container object
        /// </summary>
        /// <param name="xmlStringData">XML string data to be deserialized</param>
        /// <returns>SenatorList container that contains senator data</returns>
        private static SenatorListContainer DeserializeXMLString(string xmlStringData)
        {

            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(xmlStringData);
                if (xmlStringData != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream(byteArray))
                    {

                        XmlSerializer serializer = new XmlSerializer(typeof(SenatorListContainer));
                        SenatorListContainer senatorListContainer = (SenatorListContainer)serializer.Deserialize(memoryStream);

                        return senatorListContainer;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                DisplayException(ex);
                return null;
            }

        }
        /// <summary>
        /// Async method that downloads xml data from a url and returns it as a string
        /// </summary>
        /// <param name="url">The URL path to download the xml data</param>
        /// <returns>A string value of xml data</returns>
        private static async Task<string> DownloadXmlFile(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                DisplayException(ex);
                return null;
            }
            
        }
        /// <summary>
        /// Displays a messagebox that describes the exception
        /// </summary>
        /// <param name="ex">Exception to be displayed</param>
        private static void DisplayException(Exception ex)
        {
            string errorMessage = $"An error occurred: {ex.Message}\n\n{ex.StackTrace}";

            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }
    }
}
