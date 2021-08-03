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

                context.Books.AddRange(
                    new Book
                    { 
                    // ID =1,
                     Author ="Yazar1",
                     GenreId = 3,
                     PageCount = 340,
                     Title ="Title 1",
                     
    
                    },
                    new Book
                     {
                         //ID = 2,
                         Author = "Yazar2",
                         GenreId  = 4,
                         PageCount = 350,
                         Title = "Title 2"

                     },
                    new Book
                      {
                         // ID = 3,
                          Author = "Yazar3",
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
