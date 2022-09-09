using AnimalDZ.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace AnimalDZ.Repositories
{
    public class FileOperations : IFileOperations
    {
        private IWebHostEnvironment env;
        public FileOperations(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Dictionary<string, string> LoadFile(IFormFile uploadedFile)
        {
            string path = env.WebRootPath + "/Files/" + uploadedFile.FileName;
            var regex = new Regex(@"[a-zA-Z]+");
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach(var items in File.ReadAllLines(path))
            {
                if (regex.IsMatch(items))
                {
                    var str = items.Split(':');
                    result[str[0]] = str[1];
                }
            }

            return result;
        }

        public void SaveFile(string text)
        {
            string path = env.WebRootPath + "/Files/test.txt";
            File.WriteAllText(path, text);
        }
    }
}