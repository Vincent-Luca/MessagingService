using SimpleTCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Helpers
{
    public  class MessageManager
    {
        public MessageManager() 
        {
            
        }

        public void Login(string[] MessageParts)
        {
            try
            {
                int UserID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect($"Select * from Users where Username = '{MessageParts[1]}' and Password = '{MessageParts[2]}';").Rows[0][0].ToString());

                ServerMain.Instance.ConnectionManaging.Write($"LoginSuccess/{UserID}", ServerMain.Instance.clients.Find(x => x.UserID == UserID)._client);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Login Error: {e.Message}");
            }
        }
        public void CreateUser(string[] MessageParts)
        {
            try
            {
                int NewUserID = 0;

                if (ServerMain.Instance.DBConnection.isAvailable("Select TOP(1) UserID from Users order by UserID desc;"))
                {
                    NewUserID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) UserID from Users order by UserID desc;").Rows[0][0].ToString()) + 1;
                }

                string pass = MessageParts[4].ToString();

                Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
                {
                    {"@UID",NewUserID},
                    {"@UN",MessageParts[1]},
                    {"@Pass",pass},
                    {"@date",DateTime.Parse(DateTime.Now.ToShortDateString())},
                    {"@email", MessageParts[3]},
                    {"@DN", MessageParts[2]}
                };

                ServerMain.Instance.DBConnection.executenonquery("Insert into Users(UserID,Username,Password,CreationDate,Email,DisplayName) Values(@UID,@UN,@Pass,@date,@email,@DN);", args);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Create User Error: {e.Message}");
            }
        }

        public void TextMessage(string[] MessageParts)
        {
            int NewMessageID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) MessageID from Messages order by MessageID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string,dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@MID",NewMessageID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@MT","Text"},
                {"@MC",MessageParts[3]},
                {"@Date",DateTime.Now}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(MessageID, SenderID, ReceiverID,MessageType,MessageContent,SentDateTime) Values(@MID,@SID,@RID,@MT,@MC,@Date);", args);

            if (!ServerMain.Instance.clients.Any(X => X.UserID == int.Parse(MessageParts[2])))
            {
                return;
            }

            ServerMain.Instance.ConnectionManaging.Write($"NewMessage/{MessageParts[1]}/{MessageParts[3]}",ServerMain.Instance.clients.Find(x => x.UserID == int.Parse(MessageParts[2]))._client);
        }
        public void AudioMessage(string[] MessageParts)
        {
            int NewMessageID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) MessageID from Messages order by MessageID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@MID",NewMessageID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@MT","Audio"},
                {"@Date",DateTime.Now}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(MessageID, SenderID, ReceiverID,MessageType,SentDateTime) Values(@MID,@SID,@RID,@MT,@Date);", args);

            int NewAudioID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) AudioID from Videos order by AudioID desc;").Rows[0][0].ToString()) + 1;

            args.Clear();
            args.Add("@AID", NewAudioID);
            args.Add("@MID", NewMessageID);
            args.Add("@AData", MessageParts[3]);

            ServerMain.Instance.DBConnection.executenonquery("Insert into Audios(AudioID, MessageID, AudioData) Values(@AID,@MID,@AData);", args);

            if (!ServerMain.Instance.clients.Any(X => X.UserID == int.Parse(MessageParts[2])))
            {
                return;
            }

            ServerMain.Instance.ConnectionManaging.Write($"NewMessage/{MessageParts[1]}/{MessageParts[3]}", ServerMain.Instance.clients.Find(x => x.UserID == int.Parse(MessageParts[2]))._client);
        }
        public void VideoMessage(string[] MessageParts)
        {
            int NewMessageID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) MessageID from Messages order by MessageID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@MID",NewMessageID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@MT","Video"},
                {"@Date",DateTime.Now}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(MessageID, SenderID, ReceiverID,MessageType,SentDateTime) Values(@MID,@SID,@RID,@MT,@Date);", args);

            int NewVideoID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) VideoID from Videos order by VideoID desc;").Rows[0][0].ToString()) + 1;
            
            args.Clear();
            args.Add("@VID", NewVideoID);
            args.Add("@MID",NewMessageID);
            args.Add("@VData", MessageParts[3]);
            
            ServerMain.Instance.DBConnection.executenonquery("Insert into Videos(VideoID, MessageID, VideoData) Values(@VID,@MID,@VData);", args);

            if (!ServerMain.Instance.clients.Any(X => X.UserID == int.Parse(MessageParts[2])))
            {
                return;
            }

            ServerMain.Instance.ConnectionManaging.Write($"NewMessage/{MessageParts[1]}/{MessageParts[3]}", ServerMain.Instance.clients.Find(x => x.UserID == int.Parse(MessageParts[2]))._client);
        }
        public void SendFriendRequest(string[] MessageParts)
        {
            if (ServerMain.Instance.DBConnection.isAvailable($"Select * from FriendRequest where SenderID = {int.Parse(MessageParts[1])} and ReceiverID = {int.Parse(MessageParts[2])};"))
            {
                return;
            }
            

            int NewRequestID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) RequestID from FriendRequests order by RequestID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@ReID",NewRequestID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@Staus","Open"}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(RequestID, SenderID, ReceiverID,Status) Values(@ReID,@SID,@RID,@Status)", args);
        }
        public void AccpetFriendRequest(string[] MessageParts)
        {
            ServerMain.Instance.DBConnection.executenonquery($"Update FriendRequest where SenderID = {int.Parse(MessageParts[1])} and ReceiverID = {int.Parse(MessageParts[2])} Set Status = 'Accepted';");
        }
        public void DeclineFriendRequest(string[] MessageParts)
        {
            ServerMain.Instance.DBConnection.executenonquery($"Update FriendRequest where SenderID = {int.Parse(MessageParts[1])} and ReceiverID = {int.Parse(MessageParts[2])} Set Status = 'Declined';");
        }
        public void GroupChatTextMessage(string[] MessageParts)
        {
            int NewMessageID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) MessageID from Messages order by MessageID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@MID",NewMessageID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@MT","Text"},
                {"@MC",MessageParts[3]},
                {"@Date",DateTime.Now}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(MessageID, SenderID, ReceiverID, GroupID,MessageType,MessageContent,SentDateTime) Values(@MID,@SID,@RID,@GID,@MT,@MC,@Date);", args);

        }
        public void GroupChatAudioMessage(string[] MessageParts)
        {
            int NewMessageID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) MessageID from Messages order by MessageID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@MID",NewMessageID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@MT","Audio"},
                {"@Date",DateTime.Now}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(MessageID, SenderID, ReceiverID, GroupID,MessageType,MessageContent,SentDateTime) Values(@MID,@SID,@RID,@GID,@MT,@MC,@Date);", args);


            int NewAudioID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) AudioID from Videos order by AudioID desc;").Rows[0][0].ToString()) + 1;

            args.Clear();
            args.Add("@AID", NewAudioID);
            args.Add("@MID", NewMessageID);
            args.Add("@AData", MessageParts[3]);

            ServerMain.Instance.DBConnection.executenonquery("Insert into Audios(AudioID, MessageID, AudioData) Values(@AID,@MID,@AData);", args);
        }
        public void GroupChatVideoMessage(string[] MessageParts)
        {
            int NewMessageID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) MessageID from Messages order by MessageID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@MID",NewMessageID},
                {"@SID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[1])},
                {"@RID",int.Parse(MessageParts[2])},
                {"@MT","Audio"},
                {"@Date",DateTime.Now}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Messages(MessageID, SenderID, ReceiverID, GroupID,MessageType,MessageContent,SentDateTime) Values(@MID,@SID,@RID,@GID,@MT,@MC,@Date);", args);

            int NewVideoID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) VideoID from Videos order by VideoID desc;").Rows[0][0].ToString()) + 1;

            args.Clear();
            args.Add("@VID", NewVideoID);
            args.Add("@MID", NewMessageID);
            args.Add("@VData", MessageParts[3]);

            ServerMain.Instance.DBConnection.executenonquery("Insert into Videos(VideoID, MessageID, VideoData) Values(@VID,@MID,@VData);", args);
        }
        public void ChatLoadRequest(string[] MessageParts)
        {

        }
    }
}
