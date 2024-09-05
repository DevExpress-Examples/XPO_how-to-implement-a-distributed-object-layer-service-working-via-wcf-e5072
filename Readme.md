<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128586009/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5072)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Customer.cs](./CS/ClassLibrary1/Customer.cs) (VB: [Customer.vb](./VB/ClassLibrary1/Customer.vb))
* [Program.cs](./CS/ConsoleApplication1/Program.cs) (VB: [Program.vb](./VB/ConsoleApplication1/Program.vb))
* **[Service1.svc.cs](./CS/WcfService1/Service1.svc.cs) (VB: [Service1.svc.vb](./VB/WcfService1/Service1.svc.vb))**
* [Web.config](./CS/WcfService1/Web.config) (VB: [Web.config](./VB/WcfService1/Web.config))
<!-- default file list end -->
# How to implement a distributed object layer service working via WCF


<p><strong>Scenario</strong></p>
<p>In this example we will implement a distributed <a href="http://documentation.devexpress.com/#XPO/CustomDocument9857"><u>object layer</u></a> service (<strong>IObjectLayer/ISerializableObjectLayer</strong>) working via WCF. A distributed services layer relies on lower layers, but hides the details of these layers from upper layers that contain the application and business logic layers. This arrangement allows the application developer to work at a higher level of abstraction layers.</p>
<p><strong>Steps to implement:</strong></p>
<p><strong>1.</strong> Create a new <strong>Class Library</strong> project and add a <strong>Customer</strong> class via the <strong>DevE</strong><strong>xpress v1X.X ORM </strong><strong>P</strong><strong>ersistent Object</strong> item template. You can see the source code of this class in the <em>Customer.</em><em>xx</em> file.</p>
<p><strong>2.</strong> Create a new <strong>WCF Service Application</strong> project and remove files with auto-generated interfaces for the service.</p>
<p><strong>3.</strong> Add reference to the newly created class library.</p>
<p><strong>4.</strong> Modify the <strong>Service</strong> class as shown in the <em>Service.</em><em>xx</em> file to create a data provider and data layer.</p>
<p><strong>5.</strong> Modify binding properties as shown in the example's <em>web.config</em> file. At this stage, the service part is ready to work and we need to implement a client to consume data from our data store service (for demonstration purposes, we will create a Console Application).</p>
<p><strong>6.</strong> Add a <strong>Co</strong><strong>nsole </strong><strong>A</strong><strong>pplication</strong> into solution and add reference to the newly created class library.</p>
<p><strong>7.</strong> Modify the <strong>Main</strong> method in the same manner as the <em>Program.</em><em>xx</em> file to connect to our service using the <strong>web.config</strong> configuration.</p>
<p><strong>8.</strong> The final step is to add the <strong>App.config</strong> file to our client application and modify it as shown in the example's <em>App.config</em> file.</p>
<p>If you run the client application, you will see the following output:<br /> <img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-implement-a-distributed-object-layer-service-working-via-wcf-e5072/13.1.9+/media/ac218f54-bb4f-402d-8dba-109d3a4e99e8.png"></p>
<p><strong>Important notes:</strong><br /> Please note that the <strong>port number</strong> in the connection string may be different. You can check it in the properties of the service project in the <strong>Solution Explorer</strong>: <br /> <img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-implement-a-distributed-object-layer-service-working-via-wcf-e5072/13.1.9+/media/ab6d0938-3ac5-4fd3-b5e2-1428988c698b.png"></p>
<p> </p>
<p><strong>Troubleshooting</strong><br />1. If WCF throws the "<em>Entity is too large</em>" error, you can apply a standard solution from StackOverFlow: <a href="http://stackoverflow.com/questions/10122957/">http://stackoverflow.com/questions/10122957/</a><br />2. If WCF throws the "<em>The maximum string content length quota (8192) has been exceeded while reading XML data.</em>" error, you can extend bindings in the following manner:</p>


```xml
<bindings>
      <basicHttpBinding>
        <binding name="ServicesBinding" maxBufferPoolSize="2147483647" maxReceivedMessageSize="2147483647" maxBufferSize="2147483647" transferMode="Streamed" >
          <readerQuotas maxDepth="2147483647"
            maxArrayLength="2147483647"
            maxStringContentLength="2147483647"/>
        </binding>
      </basicHttpBinding>
</bindings>

```


<p> </p>
<p> </p>
<p>See <a href="http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x">The maximum string content length quota (8192) has been exceeded while reading XML data</a></p>
<p><strong>See also:</strong><br /> <a href="http://documentation.devexpress.com/#XPO/CustomDocument10018"><u>Transferring Data via WCF Services</u></a><u><br /> </u><a href="https://www.devexpress.com/Support/Center/p/AK3911">How to use XPO with a Web Service</a><u><a href="https://www.devexpress.com/Support/Center/p/E4930">How to connect to a remote data service instead of using a direct database connection</a> <br /></u></p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XPO_how-to-implement-a-distributed-object-layer-service-working-via-wcf-e5072&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XPO_how-to-implement-a-distributed-object-layer-service-working-via-wcf-e5072&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
