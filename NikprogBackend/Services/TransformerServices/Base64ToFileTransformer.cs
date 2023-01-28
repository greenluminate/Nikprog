namespace NikprogServerClient.Services.TransformerServices
{
    public class Base64ToFileTransformer
    {
        public byte[] ConvertBase64StringToByteArray(string base64String, string path) // With it we lost 30% of the image size.
        {
            string filePath = path;
            return Convert.FromBase64String(base64String);
            //ToDo: method to write it: File.WriteAllBytes(filePath, Convert.FromBase64String(base64String));
        }
    }
}
