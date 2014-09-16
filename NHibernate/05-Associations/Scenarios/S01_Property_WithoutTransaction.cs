using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using GrumpiesHandsOnLabs.Domain;
using GrumpiesHandsOnLabs.Mapping;

namespace GrumpiesHandsOnLabs.Scenarios
{

    public static class S01_Property_WithoutTransaction
    {
        public static void Run()
        {
            Configuration cfg = null;
            ISessionFactory factory = null;

            try
            {
                #region NHibernate initialize

                factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .FromConnectionStringWithKey("Connection"))
                        .ShowSql())
                    .Mappings(m => m
                        .FluentMappings.AddFromAssemblyOf<Customer>())
                    .BuildSessionFactory();

                #endregion

                Random randomGenerator = new Random();
                int random = randomGenerator.Next((int)(DateTime.Now.Ticks % (long)int.MaxValue));


                using (var session = factory.OpenSession())
                {                    
                    Customer customer = new Customer();
                    customer.Name = "Barış_" + random.ToString();
                    customer.SurName = "Akan_" + random.ToString();
                    customer.EMail = "bakan" + random.ToString() + "@innova.com.tr";
                    customer.BirthDate = DateTime.Today;
                        
                    session.Save(customer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}