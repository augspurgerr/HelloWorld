using HelloWorld.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HelloWorld.DAL
{
    public class MessageDM : IMessageDM
    {
        public MessageDM(string connectionString)
        {
            _connectionString = connectionString;
        }

        public enum FieldIDs
        {
            MessageID = 0,
            MessageString = 1,
            IsDeleted = 2,
            CreatedDate = 3,
            ModifiedDate = 4,
            Max = 5,
        }

        private string _connectionString { get; set; }

        /// <summary>
        /// Reads first message from table.
        /// </summary>
        /// <returns>message object</returns>
        public Message GetMessage()
        {
            Message msg = new Message();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("dbo.MessageGet", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 30;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.IsClosed)
                        return null;

                    if (reader.Read())
                    {
                        msg.MessageString = reader["MessageString"] as string;
                    }
                }
            }

            return msg;
        }

        public IList<Message> GetMessages(bool? isDeleted, int? id)
        {
            IList<Message> list = new List<Message>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("dbo.MessageGet", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 30;
                if (id.HasValue)
                {
                    SqlParameter parm1 = new SqlParameter("@MessageID", id.Value);
                    command.Parameters.Add(parm1);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.IsClosed)
                        return null;

                    while (reader.Read())
                    {
                        Message msg = new Message();

                        msg.ID = reader.GetInt32((int)FieldIDs.MessageID);
                        msg.MessageString = reader.GetString((int)FieldIDs.MessageString);
                        msg.IsDeleted = reader.GetBoolean((int)FieldIDs.IsDeleted);
                        msg.CreatedDate = reader.GetDateTime((int)FieldIDs.CreatedDate);

                        if (reader.IsDBNull((int)FieldIDs.ModifiedDate))
                            msg.ModifiedDate = null;
                        else
                            msg.ModifiedDate = reader.GetDateTime((int)FieldIDs.ModifiedDate);

                        list.Add(msg);
                    }
                }
            }

            return list;
        }

        public int Insert(Message msg)
        {
            throw new NotImplementedException();
        }

        public int Update(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}