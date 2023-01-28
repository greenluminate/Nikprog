namespace NikprogServerClient.Services.TransformerServices
{
    public class FileToBase64StringTransformer
    {
        public string ConvertFileToBase64String(string base64String, string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }
    }
}
