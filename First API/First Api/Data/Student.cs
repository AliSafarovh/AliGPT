namespace First_Api.Data
{
    public class Student
    {public int Id { get; set; }
     public string Name { get; set; }
     public string Fullname { get; set; }
        public Student(int id, string name, string fullname)
        {
            Id = id; 
            Name = name;
            Fullname = fullname;    
            
        }
    }
}
