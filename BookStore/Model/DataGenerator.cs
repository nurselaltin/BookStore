
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class DataGenerator
    {

        //Program çalıştığında  sürekli  bağlı halde kalsın istiyoruz.

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new BookStoreInMemoryContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreInMemoryContext>>()))
            {

                if (context.Books.Any())
                {
                    //Veri varsa context çalıştırma
                    return;
                }

                if(context.Genres.Any())
                {
                    return;
                }

                if (context.Authors.Any())
                {
                    return;
                }


                  context.Authors.AddRange(
                    
                       new Author()
                      {
                           FirstName = "Philip ",
                           LastName = "Pullman",
                           Birthdate = new DateTime(1982,3,15)
                             
                      },
                       new Author()
                       {
                           FirstName = "Azra ",
                           LastName = "Kohen",
                           Birthdate = new DateTime(1990, 4, 10)

                       },
                       new Author()
                        {
                            FirstName = "Ayhan",
                            LastName = "Çakmur",
                            Birthdate = new DateTime(1999,6,1)

                        }

                    );

              

                context.Genres.AddRange(
                    
                    new Genre
                    {
                           Name = "Personal Growth",
                           IsActive = true
                         
                    },
                    new Genre
                    {
                        Name = "Science Fiction",
                        IsActive = true
                    },
                    new Genre
                    {
                        Name = "Romance",
                        IsActive = true
                    }

                    );

              

                context.Books.AddRange(
                    new Book
                    {
                        // ID =1,
                        Author = new Author()
                        {
                            FirstName = "Philip ",
                            LastName = "Pullman",
                            Birthdate = new DateTime(1982, 3, 15)

                        },
                        GenreId = 3,
                         PageCount = 340,
                         Title ="Title 1",
                     
    
                    },
                    new Book
                    {
                        //ID = 2,
                        Author = new Author()
                        {
                            FirstName = "Azra ",
                            LastName = "Kohen",
                            Birthdate = new DateTime(1990, 4, 10)

                        },
                        GenreId  = 2,
                         PageCount = 350,
                         Title = "Title 2"

                     },
                    new Book
                    {
                          
                         // ID = 3,
                          Author = new Author()
                          {
                              FirstName = "Ayhan",
                              LastName = "Çakmur",
                              Birthdate = new DateTime(1999, 6, 1)

                          },
                          GenreId = 1,
                          PageCount = 440,
                          Title = "Title 3"

                      }
                    );

                context.SaveChanges();
            }


        }






    }
}
