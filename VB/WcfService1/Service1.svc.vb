Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports ClassLibrary1

Namespace WcfService1
	Public Class Service1
		Inherits SerializableObjectLayerService
		Public Sub New()
			MyBase.New(New ObjectServiceProxy())
		End Sub
		Shared Sub New()
			Dim connectionString As String = MSSqlConnectionProvider.GetConnectionString("localhost", "ServiceDB")
			Dim dataStore As IDataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema)
			Dim dictionary As XPDictionary = New ReflectionDictionary()
			dictionary.CollectClassInfos(GetType(Customer).Assembly)
			XpoDefault.DataLayer = New ThreadSafeDataLayer(dictionary, dataStore)
			XpoDefault.Session = Nothing
		End Sub
		Public Sub New(ByVal serializableObjectLayer As ISerializableObjectLayer)
			MyBase.New(serializableObjectLayer)
		End Sub
	End Class

	Public Class ObjectServiceProxy
		Inherits SerializableObjectLayerProxyBase
		Protected Overrides Function GetObjectLayer() As SerializableObjectLayer
			Return New SerializableObjectLayer(New UnitOfWork(), True)
		End Function
	End Class
End Namespace

