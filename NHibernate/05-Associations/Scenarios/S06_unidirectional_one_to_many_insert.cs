﻿using System;
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

    public static class S06_unidirectional_one_to_many_insert
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


                int projectId = 0;


                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {


                    Project project = new Project();
                    project.Name = "Project_" + random.ToString();
                    project.StartDate = DateTime.Now;
                    project.EndDate = DateTime.Now.AddDays(50);


                    Contributor contributor = new Contributor();
                    contributor.Name = "Contributor_" + random.ToString();
                    contributor.Commits= random;


                    Contributor contributor2 = new Contributor();
                    contributor2.Name = "Contributor2_" + random.ToString();
                    contributor2.Commits = random +2;


                    project.Contributors = new List<Contributor>();
                    project.Contributors.Add(contributor);
                    project.Contributors.Add(contributor2);
                    

                    session.Save(project);
                    transaction.Commit();

                    projectId = project.Id;

                   
                }

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    Project prj = session.Get<Project>(projectId);
                }    

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}