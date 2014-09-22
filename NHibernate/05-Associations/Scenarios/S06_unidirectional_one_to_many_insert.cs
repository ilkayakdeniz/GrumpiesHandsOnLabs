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
                    contributor.Nickname = "Contributor_" + random.ToString();
                    contributor.Commits= random;


                    Contributor contributor2 = new Contributor();
                    contributor2.Nickname = "Contributor2_" + random.ToString();
                    contributor2.Commits = random +2;


                    project.Contributors = new List<Contributor>();
                    project.Contributors.Add(contributor);
                    project.Contributors.Add(contributor2);
                    

                    session.Save(project);
                    transaction.Commit();

                    projectId = project.Id;


                    #region FURTHER TRIAL

                    // CHANGEProjectID column as NOT NULLABLE on Contributor Table
                    
                    
                    /*
                     * SOLUTION #1
                    NHibernate doesn't support this mapping when you have a not-null constraint on your foreign key. If you remove that constraint, you'll see that NHibernate inserts the Comments with a null PostId, then updates them with the Id of the new Post.

                    You either need to:

                    Remove the not-null constraint and the Inverse call
                    Keep the constraint, and map the other side of the relationship (making this a bi-directional relationship, and allowing Inverse to work correctly)
                    This is covered in the NHibernate documentation for one-to-many's, see the Very Important Note at the end.
                    
                     * http://stackoverflow.com/questions/554674/fluent-nhibernate-one-to-many-uni-directional-mapping
                     * http://www.nhforge.org/doc/nh/en/index.html#collections-onetomany
                    */


                    /*
                        SOLUTION #2 (Unidirectional yapıyı korumak istiyorsanız)
                     
                     * Edit: as Hazzik has rightly pointed out, this has changed in NHibernate 3 and above. The docs sadly haven't been updated, so here's Hazzik:
                       [If you] set inverse="false" and not-null on <key>, NH3 and above will perform only two inserts insead of insert-insert-update.
                     *
                     * http://stackoverflow.com/questions/4466153/nhibernate-configuration-for-uni-directional-one-to-many-relation
                     * 
                     */

                    #endregion
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