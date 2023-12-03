namespace Dogs.Models
{
    public class DogTag
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public Dog Dog { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
