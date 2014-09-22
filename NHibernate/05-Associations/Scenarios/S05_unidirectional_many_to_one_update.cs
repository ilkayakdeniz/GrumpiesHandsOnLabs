using System;
using System.Collections.Generic;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using GrumpiesHandsOnLabs.Domain;
using GrumpiesHandsOnLabs.Mapping;

namespace GrumpiesHandsOnLabs.Scenarios
{

    public static class S05_unidirectional_many_to_one_update
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

                    
                    Department dep = new Department();
                    dep.Name = "Updated_Dep_" + random.ToString();

                    Developer developer = session.Get<Developer>(1); //ID can be different within database         
                    developer.Department = dep;
                    
                    session.Save(developer);
                    transaction.Commit();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}