using System;
namespace Monitoring.View
{
    public struct SupplierReturnStruct
    {
        public Int32 SupplierID { get; set; }
        public String SupplierName { get; set; }
    }

    public struct SupplierStruct
    {
        public String SupplierName { get; set; }
    }

    public class SupplierView
    {
        private Int32 SupplierID;
        private String SupplierName;


        public SupplierView(String newName)
        {
            SupplierName = newName;
            SupplierID = 1;
        }

        public bool ValidType()
        {
            if (SupplierID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SupplierReturnStruct GetSupplier()
        {
            SupplierReturnStruct response = new SupplierReturnStruct();
            response.SupplierID = SupplierID;
            response.SupplierName = SupplierName;

            return response;
        }
    }

    
}

