using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AnimalDZ.Repositories.Interfaces;
using AnimalDZ.Model;

namespace AnimalDZ.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly IFileOperations _fileOperations;
        public Dictionary<List<string>, List<string>> animals;
        public Dictionary<string,string> animals2 = new Dictionary<string, string>();
        public IndexModel(IRepository repository, IFileOperations fileOperations)
        {
            _repository = repository;
            animals = new Dictionary<List<string>, List<string>>();
            _fileOperations = fileOperations;
        }

        public void OnGet()
        {
            animals.Add(_repository.GetName(), _repository.GetSound());
        }

        public void OnPostSaveFile(/*Dictionary<string,string> list*/)
        {
            string result = "";
            animals.Add(_repository.GetName(), _repository.GetSound());
            foreach (var item in animals)
            {
                for (int i = 0; i < item.Key.Count; i++)
                {
                    result += item.Key[i] + " : " + item.Value[i] + Environment.NewLine;
                }
            }
            /*foreach(var item in list)
            {
                result += item.Key + item.Value;
            }*/
            _fileOperations.SaveFile(result);
        }

        public void OnPostLoadFile(IFormFile uploadedFile)
        {
            animals2 = _fileOperations.LoadFile(uploadedFile);
        }
    }
}