using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeetingMinutes
{
    public class MeetingTypeProcessor
    {
        public static async Task<List<string>> LoadMeetingTypes()
        {
            string url = "http://localhost/meeting-type/get-all";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<string> model = await response.Content.ReadAsAsync<List<string>>();

                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
