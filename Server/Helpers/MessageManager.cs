using SimpleTCP;
using System;
using System.Collections.Generic;
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
            if (!ServerMain.Instance.DBConnection.isAvailable($"Select * from Users where Username = '{MessageParts[1]}' and Password = '{MessageParts[2]}';"))
                return;

            int UserID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect($"Select * from Users where Username = '{MessageParts[1]}' and Password = '{MessageParts[2]}';").Rows[0][0].ToString());
            
            ServerMain.Instance.ConnectionManaging.Write("LoginConfirmation", ServerMain.Instance.clients.Find(x => x.UserID == UserID)._client);
        }
        public void CreateUser(string[] MessageParts)
        {
            int UserID;
            if (ServerMain.Instance.DBConnection.executenonquery($"Select * from Users where Username = '{MessageParts[1]}';"))
            {
                UserID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect($"Select * from Users where Username = '{MessageParts[1]}' and Password = '{MessageParts[2]}';").Rows[0][0].ToString());

                ServerMain.Instance.ConnectionManaging.Write("CreateUserFailed/User already exists", ServerMain.Instance.clients.Find(x => x.UserID == UserID)._client);
                return;
            }

            int NewUserID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect("Select TOP(1) UserID from Users order by USerID desc;").Rows[0][0].ToString()) + 1;

            Dictionary<string, dynamic> args = new Dictionary<string, dynamic>()
            {
                {"@UID",NewUserID},
                {"@UN",int.Parse(MessageParts[1])},
                {"@Pass",int.Parse(MessageParts[2])}
            };

            ServerMain.Instance.DBConnection.executenonquery("Insert into Users(UserID,Username,Password) Values(@UID,@UN,@Pass);", args);

            UserID = int.Parse(ServerMain.Instance.DBConnection.SQLSelect($"Select * from Users where Username = '{MessageParts[1]}' and Password = '{MessageParts[2]}';").Rows[0][0].ToString());
            ServerMain.Instance.ConnectionManaging.Write("CreateUserSuccess", ServerMain.Instance.clients.Find(x => x.UserID == UserID)._client);

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
