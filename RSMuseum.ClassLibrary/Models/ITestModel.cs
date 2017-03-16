namespace RSMuseum.ClassLibrary.Models
{
    public interface ITestModel
    {
        int Age { get; set; }
        int Id { get; set; }
        string Name { get; set; }

        int PrintAge();


    }
}