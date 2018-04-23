using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;


namespace ConsoleApplication1 {
    class Program {
        static IObjectLayer ObjectLayer;
        static void Main() {
            ISerializableObjectLayer serializableObjectLayer =
                new SerializableObjectLayerServiceClient("BasicHttpBinding_ObjectLayer");
            serializableObjectLayer.CanLoadCollectionObjects.ToString();
            XpoDefault.DataLayer = null;
            XpoDefault.Session = null;
            ObjectLayer = new SerializableObjectLayerClient(serializableObjectLayer);
            using(UnitOfWork uow = new UnitOfWork(ObjectLayer)) {
                using(XPCollection<Customer> customers = new XPCollection<Customer>(uow)) {
                    foreach(Customer customer in customers) {
                        Console.WriteLine("Company Name = {0}; ContactName = {1}",
                               customer.CompanyName, customer.ContactName);
                    }
                }
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
