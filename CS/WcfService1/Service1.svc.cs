using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using ClassLibrary1;

namespace WcfService1 {

    public class Service1 : SerializableObjectLayerService {
        public Service1()
            : base(new ObjectServiceProxy()) {
        }
        static Service1() {
            string connectionString = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB");
            IDataStore dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema);
            XPDictionary dictionary = new ReflectionDictionary();
            dictionary.CollectClassInfos(typeof(Customer).Assembly);
            XpoDefault.DataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
            XpoDefault.Session = null;
        }
        public Service1(ISerializableObjectLayer serializableObjectLayer)
            : base(serializableObjectLayer) {
        }
    }

    public class ObjectServiceProxy : SerializableObjectLayerProxyBase {
        protected override SerializableObjectLayer GetObjectLayer() {
            return new SerializableObjectLayer(new UnitOfWork(), true);
        }
    }
}

