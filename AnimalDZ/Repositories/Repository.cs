using AnimalDZ.Model;
using AnimalDZ.Repositories.Interfaces;

namespace AnimalDZ.Repositories
{
    public class Repository : IRepository
    {
        private readonly IEnumerable<Animal> _animals;

        private List<string> ListName { get; set; } = new List<string>();
        private List<string> ListSound { get; set; } = new List<string>();

        public Repository(IEnumerable<Animal> animals)
        {
            _animals = animals;
        }

        public List<string> GetName()
        {
            foreach(var name in _animals)
            {
                ListName.Add(name.Name);
            }
            return ListName;
        }

        public List<string> GetSound()
        {
            foreach (var sound in _animals)
            {
                ListSound.Add(sound.Sound);
            }
            return ListSound;
        }
    }
}
