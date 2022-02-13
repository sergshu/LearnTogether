namespace WebAppAutorization.Models
{
    public class CreateStudentModel
    {
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Deleted { get; set; }

        public decimal Price { get; set; }
    }
}
