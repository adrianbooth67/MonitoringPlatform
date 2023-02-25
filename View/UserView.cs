using System;
namespace Monitoring.View
{
	public struct NewUserStruct
	{
		public String userName { get; set; }
		public String fullName { get; set; }
        public String password { get; set; }
    }

	public struct LoginStruct
	{
		public String userName { get; set; }
		public String password { get; set; }
	}

	public struct LoginReturnStruct
	{
        public Int32 sessionID { get; set; }
        public String tokenString { get; set; }
    }

	public struct NewUserReturnStruct
	{
        public Int32 userID { get; set; }
    }

	public class UserView
	{
		private String fullName;
		private String password;
		private Int32 userID;
		private String userName;
		private DateOnly expiryDate;
		private SessionView Session; // Many in the database but only one in this state

		public UserView(String newFullName, String newPassword, string newUsername) // Create new user
		{
			fullName = newFullName;
			password = newPassword;
			userName = newUsername;
			expiryDate = DateOnly.FromDateTime(DateTime.Now);
            userID = 1;
			Session = new SessionView(userID);
		}

		public UserView(String passedUsername, String passedPassword)
		{
			userID = 1;
			fullName = "Adrian Booth";
			password = passedPassword;
			userName = passedUsername;
			Session = new SessionView(userID);
        }

		public LoginReturnStruct GetLoginDetails()
		{
			LoginReturnStruct response = new LoginReturnStruct();

			if (userID == 1)
			{
				response.sessionID = 1;
				response.tokenString = Session.GetToken();
			}

			return response;
		}

        public bool ValidPerson()
		{
			if (userID == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public NewUserReturnStruct GetUser()
		{
			NewUserReturnStruct returnStruct = new NewUserReturnStruct();
			returnStruct.userID = userID;

			return returnStruct;
		}

	}
}

