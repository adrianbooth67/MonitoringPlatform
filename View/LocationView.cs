using System;
using System.Data.SqlTypes;

namespace Monitoring.View
{
    public struct LocationReturnStruct
    {
        public Int32 LocationID { get; set; }
        public String LocationName { get; set; }
        public String PostCode { get; set; }
        public String AddressLine1 { get; set;  }
        public Int32 CustomerID { get; set; }
    }

    public struct LocationUpdateStruct
    {
        public Int32 LocationID { get; set; }
        public String LocationName { get; set; }
        public String PostCode { get; set; }
        public String AddressLine1 { get; set; }
        public Int32 CustomerID { get; set; }
    }


    public struct LocationStruct
    {
        public String LocationName { get; set; }
        public String PostCode { get; set; }
        public String AddressLine1 { get; set; }
        public Int32 CustomerID { get; set; }
    }

    public class LocationView
    {
        private Int32 LocationID;
        private String LocationName;
        private String PostCode;
        private String AddressLine1;
        private Int32 CustomerID; 


        public LocationView(String newLocationName, String newPostCode, String newAddressLine1, Int32 newCustomerID)
        {
            LocationID = 1;
            LocationName = newLocationName;
            PostCode = newPostCode;
            AddressLine1 = newAddressLine1;
            CustomerID = newCustomerID;
        }

        public LocationView(Int32 LocationLookupID)
        {
            LocationID = LocationLookupID;
            LocationName = "Adrian";
            PostCode = "Post code";
            AddressLine1 = "Line 1";
            CustomerID = 1;
        }

        public bool ValidLocation()
        {
            if (LocationID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(String newLocationName, String newPostCode, String newAddressLine1, Int32 newCustomerID)
        {
            if (ValidLocation() == true)
            {
                LocationName = newLocationName;
                PostCode = newPostCode;
                AddressLine1 = newAddressLine1;
                CustomerID = newCustomerID;
                return true;
            }
            else
            {
                return false;
            }

        }



        public LocationReturnStruct GetLocation()
        {
            LocationReturnStruct response = new LocationReturnStruct();
            response.LocationID = LocationID;
            response.LocationName = LocationName;
            response.PostCode = PostCode;
            response.AddressLine1 = AddressLine1;
            response.CustomerID = CustomerID;

            return response;
        }


    }


}



