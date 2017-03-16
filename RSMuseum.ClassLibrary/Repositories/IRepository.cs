using System.Collections.Generic;

namespace RSMuseum.ClassLibrary
{
    interface IRepository
    {
        bool CreateTimeRegistration(string objektMedData);
        List<string> GetAllTimeRegistrations();
        List<string> GetAllVolunteers();
    }
}