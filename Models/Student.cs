namespace StudentGradingAPI.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public String Name { get; set; }
        public String Gender { get; set; }
        public String BOD { get; set; }
        public String Subject { get; set; }
        public int Mark { get; set; }
        public String Grade { get; set; }
        public String Remark { get; set; }
    }
}
