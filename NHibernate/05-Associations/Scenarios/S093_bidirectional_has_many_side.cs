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
    public class S093_bidirectional_has_many_side
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


                int authorId = 0;


                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {


                    Author author = new Author();
                    author.Name = "Author_" + random.ToString();
                    author.Age = 50;
                    author.Books = new List<Book>();


                    Book book = new Book();
                    book.Name = "Book_" + random.ToString();
                    book.ISBN = "ISBN_" + random.ToString();
                    book.Price = 100;



                    author.Books.Add(book);

                    //book.Author = author;

                    session.Save(author);//session saved with author.
                    transaction.Commit();

                    authorId = author.Id;

                    #region FURTHER TRIAL


                    #endregion
                }

                using (var session = factory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    Author author = session.Get<Author>(authorId);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
