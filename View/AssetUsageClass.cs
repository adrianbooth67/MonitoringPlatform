using System;
namespace Monitoring.View
{
    public struct AssetUsageReturnStruct
    {
        public Int32 AssetUsageID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int32 UnitID { get; set; }
    }

    public class AssetUsageView
    {
        private Int32 AssetUsageID;
        private Int32 AssetID;
        private Int32 UnitID;
        private DateTime StartDate;
        private DateTime EndDate;


        public AssetUsageView(Int32 passedAssetID, Int32 passedUnitID, DateTime passedStartDate)
        {
            AssetUsageID = 1;
            AssetID = passedAssetID;
            UnitID = passedUnitID;
            StartDate = passedStartDate;

        }

        public AssetUsageView(Int32 assetLookupID)
        {
            AssetID = 1;
            UnitID = 1;
            AssetUsageID = assetLookupID;
            StartDate = DateTime.Now;
        }

        public bool ValidAsset()
        {
            if (AssetID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Int32 GetID()
        {
            return AssetUsageID;
        }

        public bool Update(DateTime passedEndDate)
        {
            if (ValidAsset() == true)
            {
                EndDate = passedEndDate;
                return true;
            }
            else
            {
                return false;
            }

        }

        public AssetUsageReturnStruct GetDetails()
        {
            var response = new AssetUsageReturnStruct();
            response.AssetUsageID = AssetUsageID;
            response.StartDate = StartDate;
            response.EndDate = EndDate;
            response.UnitID = UnitID;

            return response;
    }


    }


}



