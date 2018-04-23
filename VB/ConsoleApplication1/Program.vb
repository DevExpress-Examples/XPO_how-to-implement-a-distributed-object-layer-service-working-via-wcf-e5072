Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports ClassLibrary1
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB


Namespace ConsoleApplication1
	Friend Class Program
		Private Shared ObjectLayer As IObjectLayer
		Shared Sub Main()
			Dim serializableObjectLayer As ISerializableObjectLayer = New SerializableObjectLayerServiceClient("BasicHttpBinding_ObjectLayer")
			serializableObjectLayer.CanLoadCollectionObjects.ToString()
			XpoDefault.DataLayer = Nothing
			XpoDefault.Session = Nothing
			ObjectLayer = New SerializableObjectLayerClient(serializableObjectLayer)
			Using uow As New UnitOfWork(ObjectLayer)
				Using customers As New XPCollection(Of Customer)(uow)
					For Each customer As Customer In customers
						Console.WriteLine("Company Name = {0}; ContactName = {1}", customer.CompanyName, customer.ContactName)
					Next customer
				End Using
			End Using
			Console.WriteLine("Press any key...")
			Console.ReadKey()
		End Sub
	End Class
End Namespace
