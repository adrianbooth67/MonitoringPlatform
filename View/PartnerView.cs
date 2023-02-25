using System;
namespace Monitoring.View
{
    public struct PartnerReturnStruct
    {
        public Int32 PartnerID { get; set; }
        public String PartnerName { get; set; }
    }

    public struct PartnerUpdateStruct
    {
        public Int32 PartnerID { get; set; }
        public String PartnerName { get; set; }
    }

    public struct PartnerStruct
    {
        public String PartnerName { get; set; }
    }

    public class PartnerView
    {
        private Int32 PartnerID;
        private String PartnerName;


        public PartnerView(String newName)
        {
            PartnerName = newName;
            PartnerID = 1;
        }

        public PartnerView(Int32 partnerLookupID)
        {
            PartnerName = "Adrian";
            PartnerID = partnerLookupID;
        }

        public bool ValidPartner()
        {
            if (PartnerID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(String newName)
        {
            if (ValidPartner() == true)
            {
                PartnerName = newName;
                return true;
            }
            else
            {
                return false;
            }

        }

        public PartnerReturnStruct GetPartner()
        {
            PartnerReturnStruct response = new PartnerReturnStruct();
            response.PartnerID = PartnerID;
            response.PartnerName = PartnerName;

            return response;
        }


    }


}

