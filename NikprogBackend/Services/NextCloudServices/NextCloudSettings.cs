using Newtonsoft.Json;
using NextcloudApi;

namespace NikprogServerClient.Services.NextCloudServices
{
    public class NextCloudSettings : ISettings
    {
        public Uri ServerUri => new Uri("http://localhost:8080");

        public string ApplicationName => "NextCloudNikprog";

        public Uri RedirectUri { get; set; }

        public string RedirectAfterLogin { get; set; }

        public string PageToSendAfterLogin { get; set; }

        public int LoginExpiryTime { get; set; } = 90 * 90 * 90;

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpires { get; set; }
        public string User { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public TimeSpan RefreshTokenIfDueToExpireBefore { get; set; } = new TimeSpan(1, 0, 0, 0);

        public int LogRequest { get; set; }

        public int LogResult { get; set; }

        [JsonIgnore]
        public string Filename;

        public static Settings Load()
        {
            string dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NextcloudApi");
            Directory.CreateDirectory(dataPath);
            string filename = Path.Combine(dataPath, "Settings.json");
            Settings settings = new Settings();
            settings.Load(filename);
            return settings;
        }

        public virtual void Load(string filename)
        {
            if (System.IO.File.Exists(filename))
                using (StreamReader s = new StreamReader(filename))
                    JsonConvert.PopulateObject(s.ReadToEnd(), this);
            this.Filename = filename;
        }

        public virtual void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Filename));
            using (StreamWriter w = new StreamWriter(Filename))
                w.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
        }

        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (ServerUri == null)
            {
                errors.Add("ServerUri missing");
            }
            if (string.IsNullOrEmpty(ApplicationName))
            {
                errors.Add("ApplicationName missing");
            }
            return errors;
        }
    }
}
