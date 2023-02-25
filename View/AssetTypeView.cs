using System;
namespace Monitoring.View
{
	public struct AssetTypeReturnStruct
	{
		public Int32 AssetTypeID { get; set; }
		public String AssetTypeName { get; set;  }
	}

	public struct AssetTypeStruct
	{
		public String AssetTypeName { get; set; }
	}

	public class AssetTypeView
	{
		private Int32 AssetTypeID;
		private String AssetTypeName;


        public AssetTypeView(String newName)
		{
			AssetTypeName = newName;
			AssetTypeID = 1;
		}

		public bool ValidType()
		{
			if (AssetTypeID == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public AssetTypeReturnStruct GetAssetType()
		{
			AssetTypeReturnStruct response = new AssetTypeReturnStruct();
			response.AssetTypeID = AssetTypeID;
			response.AssetTypeName = AssetTypeName;

			return response;
		}
	}
}

