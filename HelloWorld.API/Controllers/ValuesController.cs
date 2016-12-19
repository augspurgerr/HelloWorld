using HelloWorld.Contracts;
using HelloWorld.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace HelloWorld.API.Controllers
{
    public class ValuesController : ApiController
    {
        private Lazy<IMessageDM> DM { get; set; }

        public ValuesController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["cnStringSQL"].ConnectionString;
            DM = new Lazy<IMessageDM>(() => new MessageDM(connStr));
        }

        public ValuesController(IMessageDM dm)
        {
            DM = new Lazy<IMessageDM>(() => dm);
        }

        // GET api/values
        public string Get()
        {
            Message item = DM.Value.GetMessage();
            return item.MessageString;
        }

        // GET api/values/5
        public string Get(int id)
        {
            IList<Message> list = DM.Value.GetMessages(null, id);
            if (list?.Count > 0)
                return list[0].MessageString;
            else
                return null;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            Message item = new Message { MessageString = value };
            DM.Value.Insert(item);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Message item = new Message
            {
                ID = id,
                MessageString = value
            };
            DM.Value.Update(item);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}