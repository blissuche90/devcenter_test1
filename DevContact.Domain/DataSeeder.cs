using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevContact.Domain.Concrete;
using DevContact.Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace DevContact.Domain
{
    public class DataSeeder
    {
        readonly SQLDBContext _context;


        public DataSeeder(SQLDBContext context)
        {
            _context = context;

        }

        public void SeedEveryThing()
        {

             SeedInitialData();
        }

        void SeedInitialData()
        {
            if (!_context.Cars.Any())
            {
                var car1 = new Car
                {
                    Ownername = "Adedeji Obi",
                    Registration = "AB-4568-OKJ",
                   // Id = "5675ff78t757577",
                    Type = 1
                };

                var car2 = new Car
                {
                    Ownername = "Curator Uche",
                    Registration = "LG-6765-IKJ",
                   // Id = "54647478t757577",
                    Type = 2
                };
               
                _context.Cars.Add(car1);
                _context.Cars.Add(car2);
                _context.SaveChanges();
                
            }

            if (!_context.DevContacts.Any())
            {




                var dev1 = new Entities.DevContact
                {
                    Fullname = "Adedeji Obi",
                    Email = "uchenna@gmail.com",
                    Address = "7 Opebi Ikeja",
                    //Id = "5675ff78t757577",
                    Type = 1
                };
                var dev2 = new Entities.DevContact
                {
                    Fullname = "Curator Uche",
                    Email = "uchenna@gmail.com",
                    Address = "7 Opebi Ikeja",
                   // Id = "54647478t757577",
                    Type = 2
                };
                _context.DevContacts.Add(dev1);
                _context.DevContacts.Add(dev2);
                _context.SaveChanges();

            }
        }

        

    }
}

