using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace IOTBartendBotAPI.Controllers
{
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactPie(string message)
        {
            //var message = "test";
            var connectionstring = "m23.cloudmqtt.com";
            var port = 18349;
            var username = "xaomhmru";
            var password = "iVoh5GvDKPRK";

            var client = new MqttClient(connectionstring, port, false, MqttSslProtocols.None, null, null);

           

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId, username, password);

            var result = client.Publish("pie/testing", Encoding.UTF8.GetBytes(message), 
                            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);          

            
            return new OkObjectResult(result);
        }
    }
}