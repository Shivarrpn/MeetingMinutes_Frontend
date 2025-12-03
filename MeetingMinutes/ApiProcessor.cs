using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MeetingMinutes
{
    public class ApiProcessor
    {
        static string mainUrl = "http://localhost";

        public static async Task<string> TestApi()
        {
            try
            {
                string url = mainUrl + "/test/get";

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string model = await response.Content.ReadAsStringAsync();
                return model;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return null;
        }
        public static async Task<List<string>> LoadMeetingTypes()
        {
            try
            {
                string url = mainUrl + "/meeting-type/get-all";

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                List<string> model = await response.Content.ReadAsAsync<List<string>>();
                return model;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return null;
        }

        public static async Task<List<GetMeetingItemsDto>> GetPreviousMeetingItems(string meetingType)
        {
            try
            {
                string url = mainUrl + "/previous-meeting-items/get-all?meetingType=" + meetingType;

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<GetMeetingItemsDto> model = JsonConvert.DeserializeObject<List<GetMeetingItemsDto>>(jsonResponse);
                return model;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return null;
        }

        public static async Task<List<string>> LoadStatuses()
        {
            try
            {
                string url = mainUrl + "/status/get-all";

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                List<string> model = await response.Content.ReadAsAsync<List<string>>();
                return model;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return null;
        }

        public static async Task<List<string>> LoadPerson()
        {
            try
            {
                string url = mainUrl + "/person/get-all";

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                List<string> model = await response.Content.ReadAsAsync<List<string>>();
                return model;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return null;
        }

        public static async Task<CreateMeetingDto> CreateMeeting(string meetingType, DateTime meetingDateTime)
        {
            try
            {
                string url = mainUrl + "/meeting/create?meetingType=" + meetingType + "&meetingDateTime=" + meetingDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                CreateMeetingDto model = await response.Content.ReadAsAsync<CreateMeetingDto>();
                return model;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return null;
        }

        public static async Task EndMeeting(EndMeetingDto endMeetingDto)
        {
            try
            {
                string url = mainUrl + "/meeting/end";

                string json = JsonConvert.SerializeObject(endMeetingDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Meeting items saved!");
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Please start the API then open the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
    }
}
