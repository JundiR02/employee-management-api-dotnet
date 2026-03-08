namespace DTOs
{
    public class EmployeeCreateDto
    {
        public required string Name { get; set; }
        public required string Position { get; set; }
        public decimal Salary { get; set; }
    }
}