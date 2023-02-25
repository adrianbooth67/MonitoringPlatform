using System;
namespace Monitoring.View
{
    public struct CustomerReturnStruct
    {
        public Int32 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int32 PartnerID { get; set; }
    }

    public struct CustomerUpdateStruct
    {
        public Int32 CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Int32 PartnerID { get; set; }
    }

    public struct CustomerStruct
    {
        public String CustomerName { get; set; }
        public Int32 PartnerID { get; set;  }
    }

    public class CustomerView
    {
        private Int32 CustomerID;
        private String CustomerName;
        private Int32 PartnerID;


        public CustomerView(String newName, Int32 partner)
        {
            CustomerName = newName;
            CustomerID = 1;
            PartnerID = partner;
        }

        public CustomerView(Int32 customerLookupID)
        {
            CustomerName = "Adrian";
            CustomerID = 1;
            PartnerID = 1;
        }

        public bool ValidCustomer()
        {
            if (CustomerID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(String newName, Int32 newPartnerID)
        {
            if (ValidCustomer() == true)
            {
                CustomerName = newName;
                PartnerID = newPartnerID;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public CustomerReturnStruct GetCustomer()
        {
            CustomerReturnStruct response = new CustomerReturnStruct();
            response.CustomerID = CustomerID;
            response.CustomerName = CustomerName;
            response.PartnerID = PartnerID;

            return response;
        }

        
    }


}



