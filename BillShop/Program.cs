using System;
using BillShop.Controlers;
using BillShop.DAO;
using BillShop.Services;

namespace BillShop
{
    class Program
    {
        static void Main(string[] args)
        {
         
            RootController rootController = new RootController();
            
            rootController.MakeBill(args);

        }
        
    }
}
