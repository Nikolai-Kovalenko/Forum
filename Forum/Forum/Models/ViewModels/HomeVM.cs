namespace Forum.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Topic> Topics { get; set; }
        public IEnumerable<Section> Sections { get; set; }
    }
}
