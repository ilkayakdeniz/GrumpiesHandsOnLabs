using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using GrumpiesHandsOnLabs.Domain;

namespace GrumpiesHandsOnLabs.Scenarios
{

    public static class S01_Configured_ConnectionStringInline
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
                cfg = new Configuration();
                
                cfg.SessionFactoryName("BuildIt");
                cfg.DataBaseIntegration(db =>
                {
                    db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    db.IsolationLevel = IsolationLevel.ReadCommitted;
                    db.Dialect<MsSql2008Dialect>();
                    db.Driver<SqlClientDriver>();

                    db.ConnectionString = @"server=localhost\SQLExpress;initial catalog=GrumpiesHandsOnLabs;Integrated Security=True";
                    db.Timeout = 10;                    

                    // enabled for testing
                    db.LogFormattedSql = true;
                    db.LogSqlInConsole = true;
                    db.AutoCommentSql = true;
                });

                cfg.AddAssembly(typeof (Customer).Assembly);
                
                factory = cfg.BuildSessionFactory();
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