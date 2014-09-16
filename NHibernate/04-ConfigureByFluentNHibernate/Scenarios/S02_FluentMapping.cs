using System;
using GrumpiesHandsOnLabs.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GrumpiesHandsOnLabs.Mapping;
using NHibernate;
using NHibernate.Cfg;
using GrumpiesHandsOnLabs.Domain;

namespace GrumpiesHandsOnLabs.Scenarios
{

    public static class S02_FluentMapping
    {
        public static void Run()
        {
            Configuration cfg = null;
            ISessionFactory factory = null;
            ISession session = null;
            ITransaction transaction = null;

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

                session = factory.OpenSession();

                transaction = session.BeginTransaction();
                #endregion

                Random randomGenerator = new Random();
                int random = randomGenerator.Next((int)(DateTime.Now.Ticks%(long)int.MaxValue));
                

                Customer customer = new Customer();
                customer.Name = "Barış_" + random.ToString();
                customer.SurName = "Akan_" + random.ToString();
                customer.EMail = "bakan"+ random.ToString() +"@innova.com.tr" ;
                customer.BirthDate = DateTime.Today;

                session.Save(customer);
                transaction.Commit();
                session.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                session.Close();
            }
        }
    }
}