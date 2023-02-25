using System;
using System.Data.SqlTypes;

namespace Monitoring.View
{
    public struct OperatingUnitReturnStruct
    {
        public Int32 OperatingUnitID { get; set; }
        public String OperatingUnitName { get; set; }
        public Int32 LocationID { get; set; }
    }

    public struct OperatingUnitUpdateStruct
    {
        public Int32 OperatingUnitID { get; set; }
        public String OperatingUnitName { get; set; }
        public Int32 LocationID { get; set; }
    }


    public struct OperatingUnitStruct
    {
        public String OperatingUnitName { get; set; }
        public Int32 LocationID { get; set; }
    }

    public class OperatingUnitView
    {
        private Int32 OperatingUnitID;
        private String OperatingUnitName;
        private Int32 LocationID;


        public OperatingUnitView(String newOperatingUnitName, Int32 newLocationID)
        {
            OperatingUnitID = 1;
            OperatingUnitName = newOperatingUnitName;
            LocationID = newLocationID;
        }

        public OperatingUnitView(Int32 OperatingUnitLookupID)
        {
            OperatingUnitName = "Adrian";
            OperatingUnitID = OperatingUnitLookupID;
            LocationID = 1;
        }

        public bool ValidOperatingUnit()
        {
            if (OperatingUnitID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(String newOperatingUnitName, Int32 newLocationID)
        {
            if (ValidOperatingUnit() == true)
            {
                OperatingUnitName = newOperatingUnitName;
                LocationID = newLocationID;
                return true;
            }
            else
            {
                return false;
            }

        }

        

        public OperatingUnitReturnStruct GetOperatingUnit()
        {
            OperatingUnitReturnStruct response = new OperatingUnitReturnStruct();
            response.OperatingUnitID = OperatingUnitID;
            response.OperatingUnitName = OperatingUnitName;
            response.LocationID = LocationID;

            return response;
        }


    }


}

