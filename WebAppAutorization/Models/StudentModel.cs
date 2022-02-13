namespace WebAppAutorization.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Deleted { get; set; }

        public decimal Price { get; set; }

        public string FullName { get; set; }
    }
}
