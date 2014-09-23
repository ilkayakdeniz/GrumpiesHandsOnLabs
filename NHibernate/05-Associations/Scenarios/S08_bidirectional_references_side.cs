using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GrumpiesHandsOnLabs.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace GrumpiesHandsOnLabs.Scenarios
{
    public class S08_bidirectional_references_side
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


                int bookId = 0;


                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {

                    Book book = new Book();
                    book.Name = "Book_" + random.ToString();
                    book.ISBN = "ISBN_" + random.ToString();
                    book.Price = 100;

                    Author author = new Author();
                    author.Name = "Author_" + random.ToString();
                    author.Age = 50;

                    book.Author = author;

                    session.Save(book); //session saved wihb books
                    transaction.Commit();

                    bookId = book.Id;

                    #region FURTHER TRIAL

  
                    #endregion
                }

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    Book book = session.Get<Book>(bookId);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
