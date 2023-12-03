namespace Dogs.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DogTag> DogTags { get; set; }
    }
}
