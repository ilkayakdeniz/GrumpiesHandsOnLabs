using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using GrumpiesHandsOnLabs.Domain;

namespace GrumpiesHandsOnLabs.Scenarios
{
    
    public static class S02_Configured_ConnectionStringName
    {

        public static void Run()
        {
            Configuration cfg = null;
            ISessionFactory factory = null;


            try
            {
                #region NHibernate initialize
                cfg = new Configuration();
                
                cfg.SessionFactoryName("BuildIt");
                cfg.DataBaseIntegration(db =>
                {
                    db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    db.IsolationLevel = IsolationLevel.ReadCommitted;
                    db.Dialect<MsSql2008Dialect>();
                    db.Driver<SqlClientDriver>();

                    db.ConnectionStringName = "Connection";
                    db.Timeout = 10;                    

                    // enabled for testing
                    db.LogFormattedSql = true;
                    db.LogSqlInConsole = true;
                    db.AutoCommentSql = true;
                });

                cfg.AddAssembly(typeof (Customer).Assembly);
                
                factory = cfg.BuildSessionFactory();
                #endregion

                Random randomGenerator = new Random();
                int random = randomGenerator.Next((int)(DateTime.Now.Ticks%(long)int.MaxValue));
                
                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    Customer customer = new Customer();
                    customer.Name = "Barış_" + random.ToString();
                    customer.SurName = "Akan_" + random.ToString();
                    customer.EMail = "bakan" + random.ToString() + "@innova.com.tr";
                    customer.BirthDate = DateTime.Today;

                    session.Save(customer);
                    transaction.Commit();
                    session.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}