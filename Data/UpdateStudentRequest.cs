namespace StudentGradingAPI.Data
{
    public class UpdateStudentRequest
    {
        public String Name { get; set; }
        public String Gender { get; set; }
        public String BOD { get; set; }
        public String Subject { get; set; }
        public int Mark { get; set; }
        public String Grade { get; set; }
        public String Remark { get; set; }
    }
}
