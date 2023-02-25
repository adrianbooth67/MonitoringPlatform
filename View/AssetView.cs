using System;
using System.Data.SqlTypes;

namespace Monitoring.View
{
    public struct AssetReturnStruct
    {
        public Int32 AssetID { get; set; }
        public String AssetSerialNumber { get; set; }
        public Int32 SupplierID { get; set; }
        public Int32 CurrentUnitID { get; set;  }
        public List<AssetUsageReturnStruct> UsageList { get; set;  }
    }

    public struct RegisterAssetStruct
    {
        public Int32 AssetID { get; set; }
        public Int32 UnitID { get; set; }
        public DateTime StartDate { get; set; }
    }

    public struct AssetUpdateStruct
    {
        public Int32 AssetID { get; set; }
        public String AssetSerialNumber { get; set; }
        public Int32 SupplierID { get; set; }
        public DateTime CreationDate { get; set; }
    }


    public struct AssetStruct
    {
        public String AssetSerialNumber { get; set; }
        public Int32 SupplierID { get; set; }
        public DateTime CreationDate { get; set;  }
    }

    public class AssetView
    {
        private Int32 AssetID;
        private String AssetSerialNumber;
        private Int32 SupplierID;
        private DateTime AssetCreationDate;
        private Int32? CurrentUsageID;
        private List<AssetUsageView> UsageList;


        public AssetView(String newAsset, Int32 supplier, DateTime passedCreationDate)
        {
            AssetSerialNumber = newAsset;
            AssetID = 1;
            SupplierID = supplier;
            AssetCreationDate = passedCreationDate;
            UsageList = new List<AssetUsageView>();
        }

        public AssetView(Int32 assetLookupID)
        {
            AssetSerialNumber = "Adrian";
            AssetID = 1;
            SupplierID = 1;
            AssetCreationDate = DateTime.Now;
            UsageList = new List<AssetUsageView>();
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

        public bool Update(String newSerialNumber, Int32 newSupplierID)
        {
            if (ValidAsset() == true)
            {
                AssetSerialNumber = newSerialNumber;
                SupplierID = newSupplierID;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Assign(Int32 passedUnitID, DateTime passedStartDate)
        {
            if (CurrentUsageID != null)
            {
                var CurrentUsage = new AssetUsageView(CurrentUsageID ?? 0);
                CurrentUsage.Update(passedStartDate);
            }

            var newUsage = new AssetUsageView(AssetID, passedUnitID, passedStartDate);
            CurrentUsageID = newUsage.GetID();

            return true;
        }

        public AssetReturnStruct GetAsset()
        {
            AssetReturnStruct response = new AssetReturnStruct();
            response.AssetID = AssetID;
            response.AssetSerialNumber = AssetSerialNumber;
            response.SupplierID = SupplierID;
            response.UsageList = GetUsages();
            response.CurrentUnitID = 1;

            return response;
        }

        private List<AssetUsageReturnStruct> GetUsages()
        {
            var tempUsage = new AssetUsageView(AssetID, 1, DateTime.Now);
            tempUsage.Update(DateTime.Now);

            var response = new List<AssetUsageReturnStruct>();
            response.Add(tempUsage.GetDetails());

            return response;
        }


    }


}

