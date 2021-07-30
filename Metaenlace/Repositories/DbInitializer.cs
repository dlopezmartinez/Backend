using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Models;

namespace Metaenlace.Repositories
{
    public class DbInitializer
    {

        public static void Initialize(BDContext context)
        {
            context.Database.EnsureCreated();


            


            Console.WriteLine("Ésto se ejecuta");
        }


    }
}
