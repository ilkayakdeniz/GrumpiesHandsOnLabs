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

    public static class S04_unidirectional_many_to_one_insert
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


                int departmentId = 0;


                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {

                    
                    Department dep = new Department();
                    dep.Name = "Dep_" + random.ToString();


                    Developer developer = new Developer();
                    developer.Name = "Barış_" + random.ToString();
                    developer.SurName = "Akan_" + random.ToString();
                    developer.Department = dep; //Add department to developer


                    session.Save(developer);
                    transaction.Commit();

                    departmentId = dep.Id;

                }

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    Department dep = session.Get<Department>(departmentId);
                }


                //// Change FK to nullable and run
                /// //INSERT INSERT UPDATE

                //int developerId = 0;

                //using (var session = factory.OpenSession())
                //using (var transaction = session.BeginTransaction())
                //{

                //    Developer developer = new Developer();
                //    developer.Name = "Barış_" + random.ToString();
                //    developer.SurName = "Akan_" + random.ToString();


                //    Department dep = new Department();
                //    dep.Name = "Dep_" + random.ToString();
                //    dep.Developers = new List<Developer>();
                //    dep.Developers.Add(developer); //Add developer to department


                //    session.Save(dep);
                //    transaction.Commit();

                //    developerId = developer.Id;

                //}

                //using (var session = factory.OpenSession())
                //using (var transaction = session.BeginTransaction())
                //{
                //    Developer developer = session.Get<Developer>(developerId);
                //}


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}