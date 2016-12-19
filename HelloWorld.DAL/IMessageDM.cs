using HelloWorld.Contracts;
using System.Collections.Generic;

namespace HelloWorld.DAL
{
    public interface IMessageDM
    {
        Message GetMessage();

        IList<Message> GetMessages(bool? isDeleted, int? id);

        int Insert(Message msg);

        int Update(Message msg);
    }
}