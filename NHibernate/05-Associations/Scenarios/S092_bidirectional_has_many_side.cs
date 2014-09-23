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
    public class S092_bidirectional_has_many_side
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
                    book.Author = author; //now tho side knows the relation. You can try to remove this relation and see what happens

                    /*
                    exec sp_executesql N'INSERT INTO [Author] (Name, Age) VALUES (@p0, @p1); select SCOPE_IDENTITY()',N'@p0 nvarchar(4000),@p1 int',@p0=N'Author_1392447771',@p1=50
                    go
                    exec sp_executesql N'INSERT INTO [Book] (Name, Price, ISBN, AuthorId) VALUES (@p0, @p1, @p2, @p3); select SCOPE_IDENTITY()',N'@p0 nvarchar(4000),@p1 float,@p2 nvarchar(4000),@p3 int',@p0=N'Book_1392447771',@p1=100,@p2=N'ISBN_1392447771',@p3=69
                    go
                     
                     */

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
