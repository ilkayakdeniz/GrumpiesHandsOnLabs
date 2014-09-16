using System;
using GrumpiesHandsOnLabs.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GrumpiesHandsOnLabs.Mapping;
using NHibernate;
using NHibernate.Cfg;

namespace GrumpiesHandsOnLabs.Scenarios
{


    public static class S01_AutoMapping
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

                var mapCfg = new AutoMappingConfig();

                /*                 
                 When Automap is being used system does not know which namespaces to investigate under certain assembly.
                 This configuration helps FluentNHibernate to seach proper namespaces or else.
                 This can be modified accordign to needs.
                 
                 Always prefer writing you own mapping files.                 
                 */
                factory = Fluently.Configure()
                                    .Database(MsSqlConfiguration.MsSql2008
                                        .ConnectionString(c => c
                                            .FromConnectionStringWithKey("Connection"))
                                        .ShowSql())
                                    .Mappings(m => m
                                        .AutoMappings.Add(
                                            AutoMap.AssemblyOf<Customer>(mapCfg)))
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