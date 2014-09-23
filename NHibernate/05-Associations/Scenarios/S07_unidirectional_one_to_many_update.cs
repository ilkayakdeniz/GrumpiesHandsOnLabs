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

    public static class S07_unidirectional_one_to_many_update
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
                
                int projectId = 8;

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    
                    Contributor contributor = new Contributor();
                    contributor.Name = "Contributor_" + random.ToString();
                    contributor.Commits = random;
                    
                    Project project = session.Get<Project>(projectId); // ID might not be existing in the database
                    project.Contributors.Add(contributor);


                    session.Save(project);
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