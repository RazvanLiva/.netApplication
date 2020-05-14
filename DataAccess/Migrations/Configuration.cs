namespace DataAccess.Migrations
{
    using DataAccess.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.RazvanLivadariuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Context.RazvanLivadariuDbContext context)
        {
            var BotosaniCountyAddress = new Address
            {
                Id = Guid.Parse("07a05b57-f68c-4a7c-bd58-7056dec6a2c9"),
                StreetName = "47.7407° N, 26.6658° E",

            };

            var BotosaniCounty = new County
            {
                Id = Guid.Parse("84125b45-406a-48b4-b062-c8ecb12858da"),
                Name = "Botosani",
                Address = BotosaniCountyAddress
            };

            var IasiCountyAddress = new Address
            {
                Id = Guid.Parse("07a05b57-f68c-4a7c-bd58-7056dec6a2c9"),
                StreetName = "47.1585° N, 27.6014° E",
            };

            var IasiCounty = new County
            {
                Id = Guid.Parse("9d81d338-784a-4a93-9f46-0ad85156c292"),
                Name = "Iasi",
                Address = IasiCountyAddress
            };
            var BucurestiCountyAddress = new Address
            {
                Id = Guid.Parse("9a7ed5bc-625f-41fa-b3ef-c8658581eab3"),
                StreetName = "47.1585° N, 27.6014° E",
            };

            var bucurestiCounty = new County
            {
                Id = Guid.Parse("354D0FE7-DAFD-4352-BD0C-80DB55371BE6"),
                Name = "Bucuresti",
                Address = BucurestiCountyAddress
            };

            var infoBloodTypes = new List<BloodType>
            {
                new BloodType
                {
                    Id = Guid.Parse("d31f0a4a-6ab7-4058-8dbb-4bcb2be56ed8"),
                    Name = "A"
                },
                new BloodType
                {
                    Id = Guid.Parse("cdaa9bc2-7f22-47b1-8144-20e5c8b76297"),
                    Name = "B"
                },
                   new BloodType
                {
                    Id = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                    Name = "AB"
                },
                      new BloodType
                {
                    Id = Guid.Parse("c26a4180-65aa-42ec-a945-5fd21dec0538"),
                    Name = "0"
                }
            };



            //Nu am apucat sa rezolv partea cu seed, astfel baza de date este goala la Hospital si la BloodTypes, astfel nu le v-a afisa.
           


            //var spiridonHospitals = new List<Hospital>
            //{
            //    new Hospital
            //    {
            //        Id = Guid.Parse("051c7237-2a82-49eb-9ad7-9157e27c5972"),
            //        Email = "spiridon@yahoo.com",
            //        Name="Sfantul Spiridon",
            //        PhoneNumber = "0231443232",
            //        BloodTypes = infoBloodTypes
            //    }
            //};

            //var RecuperareHospitals = new List<Hospital>
            //{
            //    new Hospital
            //    {
            //        Id = Guid.Parse("46f746ed-11d6-4cf7-820b-f31fa56e991a"),
            // 
            //        Email = "recuperare@yahoo.com",
            //        Name="Recuperare",
            //       PhoneNumber = "0231123921",
            //        BloodTypes= infoBloodTypes
            //    }
            //};
            //var recuperarePersons = new List<Person> {
            //    new Person
            //    {
            //        Id = Guid.Parse("68fd5f60-527a-4147-b20d-6127010741ee"),
            //        Age = 34,
            //        Email = "ion.ionescu@yahoo.com",
            //        FirstName = "Ionnescu",
            //        LastName = "Ion",
            //        BloodTypes = infoBloodTypes
            //    },
            //    new Person
            //    {
            //       Id = Guid.Parse("bd5f07b6-dcb7-46ce-9324-3bfb72fa2499"),
            //        Age = 24,
            //        Email = "razvan.livadariu@yahoo.com",
            //        FirstName = "Livadariu",
            //        LastName = "Razvan",
            //       BloodTypes = infoBloodTypes
            //    }};
            //var spiridonPersons = new List<Person> {
            //    new Person
            //    {
            //        Id = Guid.Parse("cc063822-53dd-429a-b9a8-85307068383b"),
            //        Age = 19,
            //        Email = "andreipopescu@yahoo.com",
            //        FirstName = "Popescu",
            //        LastName = "Andrei",
            //        BloodTypes= infoBloodTypes
            //    },
            //    new Person
            //    {
            //        Id = Guid.Parse("998b7bcc-06d6-45f4-b8a0-9ff7768a804a"),
            //        Age = 44,
            //        Email = "vasileion@email.com",
            //        FirstName = "Vasile",
            //        LastName = "Ion",
            //        BloodTypes = infoBloodTypes
            //    }};
            //var spiridonCity = new City
            // {
            //   Id = Guid.Parse("64f7b886-fc04-400d-aee0-be28f243dc43"),
            //    Name = "Iasi",
            //    Hospitals = spiridonHospitals,
            //    Persons = spiridonPersons,
            //   County = IasiCounty
            //};
            //var recuperareCity = new City
            //{
            //    Id = Guid.Parse("5aac3c1f-9ae8-4104-926a-b83e1550fe9e"),
            //    Name = "Botosani",
            //    Hospitals = RecuperareHospitals,
            //    Persons = recuperarePersons,
            //    County = BotosaniCounty
            //};





            context.Counties.AddOrUpdate(BotosaniCounty, IasiCounty);
            context.Counties.AddOrUpdate(bucurestiCounty);
            

        }
    }
}
