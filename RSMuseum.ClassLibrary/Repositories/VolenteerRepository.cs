using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary
{
    class VolenteerRepository : IRepository
    {
        //Henter alle vores frivillige
        public List<string> GetAllVolunteers()
        {
            //Kode ned i DAL lag
            List<string> liste = new List<string>();

            return liste;
        }

        //Henter alle vores tidsregistreringer som mangler godkendelse
        public List<string> GetAllTimeRegistrations()
        {
            //Kode ned i DAL lag
            List<string> liste = new List<string>();

            return liste;
        }

        //Opretter tidsregistrering
        public bool CreateTimeRegistration(string objektMedData)
        {
            //Kode ned i DAL lag

            // retunere true eller false alt efter om det lykkes
            return true;
        }
    }
}
