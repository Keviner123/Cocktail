using Bartender.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender
{

    class Program
    {



        static void Main(string[] args)
        {
            DAL_DB DBConnection = new DAL_DB();
            DBConnection.FillDatabase();


        }
    }
}
