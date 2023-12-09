namespace Dogs.Models
{
    public class FCICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Dog> Dogs { get; set; }

    }
}
