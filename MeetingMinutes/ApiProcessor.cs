using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace MeetingMinutes
{
    public class ApiProcessor
    {
        static string mainUrl = "http://localhost";
        public static async Task<List<string>> LoadMeetingTypes()
        {
            string url = mainUrl + "/meeting-type/get-all";

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

        public static async Task<List<GetMeetingItemsDto>> GetPreviousMeetingItems(string meetingType)
        {
            string url = mainUrl + "/previous-meeting-items/get-all?meetingType=" + meetingType;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<GetMeetingItemsDto> model = JsonConvert.DeserializeObject<List<GetMeetingItemsDto>>(jsonResponse);
                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<string>> LoadStatuses()
        {
            string url = mainUrl + "/status/get-all";

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

        public static async Task<List<string>> LoadPerson()
        {
            string url = mainUrl + "/person/get-all";

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
