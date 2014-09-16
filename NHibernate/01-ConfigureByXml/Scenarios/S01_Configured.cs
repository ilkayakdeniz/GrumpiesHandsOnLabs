using System;
using GrumpiesHandsOnLabs.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace GrumpiesHandsOnLabs.Scenarios
{
    
    public static class S01_Configured
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
                cfg.Configure();
                factory = cfg.BuildSessionFactory();
                session = factory.OpenSession();
                transaction = session.BeginTransaction();
                #endregion

                Random randomGenerator = new Random();
                int random = randomGenerator.Next((int)(DateTime.Now.Ticks % (long)int.MaxValue));
                

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