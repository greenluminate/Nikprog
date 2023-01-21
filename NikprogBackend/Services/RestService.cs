namespace NikprogBackend.Services
{
    public class RestService
    {
        HttpClient? client;

        public RestService(string baseurl)
        {
            Init(baseurl);
        }

        private void Init(string baseurl)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                ("application/json"));

            try
            {
                client.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException)
            {
                throw new ArgumentException("Endpoint is not available!");
            }
        }

        public T? GetSingle<T>(string endpoint, string token = "")
        {
            if (token.Length > 3 && client != null)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            T? item = default(T);
            HttpResponseMessage? response = client?.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response != null && response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }

            return item;
        }
    }
}
