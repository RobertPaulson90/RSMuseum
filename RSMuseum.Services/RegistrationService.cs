using RSMuseum.Repository;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace RSMuseum.Services
{
   public class RegistrationService
    {
        private static IDbRepository _dbRepo;
        public RegistrationService(IDbRepository dbRepo) //Vi smider vores db repo som contructor så vores DI container kan instanciere den
        {
            _dbRepo = dbRepo;
        }

        public bool AddRegistration(Registration registration)
        {
            
                _dbRepo.AddTimeRegistration(registration);
                return true;
            
            
               // return false;
            
        }
    }
}
