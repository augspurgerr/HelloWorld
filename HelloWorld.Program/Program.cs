using HelloWorld.Contracts;
using HelloWorld.DAL;
using System;
using System.Configuration;

namespace HelloWorld.Program
{
    internal class Program
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["cnStringSQL"].ConnectionString;

        private static Lazy<IMessageDM> DataManager { get; set; }

        private static void Main(string[] args)
        {
            DataManager = new Lazy<IMessageDM>(() => new MessageDM(connStr));
            Message msg = DataManager.Value.GetMessage();
            Console.WriteLine(msg.MessageString);
            Console.ReadLine();
        }
    }
}