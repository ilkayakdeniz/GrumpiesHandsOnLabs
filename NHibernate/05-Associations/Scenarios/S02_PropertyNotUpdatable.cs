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

    public static class S02_PropertyNotUpdatable
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
                using (var transaction = session.BeginTransaction())
                {
                    Adress adress = new Adress();
                    adress.Name = "Ev_" + random.ToString();
                    adress.Street = "Street_" + random.ToString();
                    adress.PostCode = "PC_" + random.ToString();

                    session.Save(adress);
                    // SQLProfiler  INSERT

                    Adress dbAdress = session.Get<Adress>(adress.Id);
                    dbAdress.Name = "Updated_EV_" + random.ToString();
                    dbAdress.PostCode = "Updated_PC_" + random.ToString();
                    //SQLProfiler  you don't see select !?!?! plase check further scenarios related with sesssion
                    //Where is the select?

                    session.Update(dbAdress);
                    transaction.Commit();

                    //SQLProfiler UPDATE Check UPDATE statement if postcode is being updated
                    //Check mapping of the Adress Class!
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}