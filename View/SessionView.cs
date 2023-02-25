using System;
namespace Monitoring.View
{
	public class SessionView
	{
		private Int32 sessionID;
		private Int32 userID;
		private String token;
		private DateTime expiryDateTime;


        public SessionView(Int32 passedUserId)
		{
			userID = passedUserId;
			sessionID = 1;
			token = "XXXXXX";
			expiryDateTime = DateTime.Now;
			expiryDateTime.AddMinutes(30);
        }

		public String GetToken()
		{
			return token;
		}
	}
}

