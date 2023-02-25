using System;
namespace Monitoring.View
{
	public struct DeviceSetupStruct
	{
		public String DeviceSerialNumber { get; set; }
	}

	public struct AllocateDeviceStruct
	{
		public Int32 DeviceID { get; set; }
		public Int32 UnitID { get; set; }
	}

	public struct SetLiveDeviceStruct
	{
        public String DeviceSerialNumber { get; set; }
    }

	public struct DeviceReturnStruct
	{
        public Int32 DeviceID { get; set; }
        public String DeviceSerialNumber { get; set; }
        public Int16 DeviceStatus { get; set; }
        public Int32? UnitID { get; set; }
    }
	public class DeviceView
	{
		private Int32 DeviceID;
		private String DeviceSerialNumber;
		private Int16 DeviceStatus; // 0 – Created, 1 – Deployed, 2 – Live, 3 - Fault, 4 - Shutdown
        private Int32? UnitID;
		


        public DeviceView(String newSerialNumber)
		{
			DeviceID = 1;
			DeviceSerialNumber = newSerialNumber;
			DeviceStatus = 0;
		}

		public DeviceView(Int32 currentDeviceID)
		{
            DeviceID = currentDeviceID;
            DeviceSerialNumber = "Dummy";
            DeviceStatus = 0;
        }

		public void AllocateDevice(Int32 newUnitID)
		{
			UnitID = newUnitID;
			DeviceStatus = 1;
		}

		public void SetLive()
		{
			DeviceStatus = 2;
		}

		public void SetFault()
		{
			DeviceStatus = 3;
		}

		public void DeAllocateDevice()
		{
			DeviceStatus = 0;
		}

		public DeviceReturnStruct GetDevice()
		{
			DeviceReturnStruct response = new DeviceReturnStruct();

			response.DeviceID = DeviceID;
			response.DeviceSerialNumber = DeviceSerialNumber;
			response.DeviceStatus = DeviceStatus;
			response.UnitID = UnitID;

			return response;
		}

		public bool ValidDevice()
		{
			if (DeviceID == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		

    }
}

