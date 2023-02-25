using System;
namespace Monitoring.View
{
	public struct HomeReturnStruct
	{
        public Double energyCreated { get; set; }
        public Int32 numberOfClients { get; set; }
        public Int32 numberOfLocations { get; set; }
        public Int32 numberOfUnits { get; set; }
        public EnergyDay[] energyDays { get; set; }
    }

    public struct EnergyDay
	{
		public DateOnly energyDay { get; set;  }
		public Double energyProduced { get; set;  }

		public EnergyDay(DateOnly newDay, Double newEnergy)
		{
			energyDay = newDay;
			energyProduced = newEnergy;
		}
	}

	public class HomeView
	{
        private Double energyCreated;
		private Int32 numberOfClients;
		private Int32 numberOfLocations;
		private Int32 numberOfUnits;
		private List<EnergyDay> energyDays;

        public HomeView()
		{
			energyCreated = 1200;
			numberOfClients = 100;
			numberOfLocations = 200;
			numberOfUnits = 200;
			var tempDay = new EnergyDay(DateOnly.FromDateTime(DateTime.Now), 100);
			energyDays = new List<EnergyDay>();
            energyDays.Add(tempDay);
		}

		public HomeReturnStruct GetHomeView()
		{
			HomeReturnStruct response = new HomeReturnStruct();

            response.energyCreated = energyCreated;
            response.numberOfClients = numberOfClients;
            response.numberOfLocations = numberOfLocations;
			response.numberOfUnits = numberOfUnits;


			response.energyDays = energyDays.ToArray();

			return response;
        }

		public List<AssetTypeReturnStruct> GetAssetTypes()
		{
			List<AssetTypeReturnStruct> response = new List<AssetTypeReturnStruct>();

			AssetTypeReturnStruct newElement = new AssetTypeReturnStruct();
			newElement.AssetTypeID = 1;
			newElement.AssetTypeName = "Dummy 1";
			response.Add(newElement);
			newElement.AssetTypeID = 2;
			newElement.AssetTypeName = "Dummy 2";
			response.Add(newElement);

			return response;
		}

        public List<SupplierReturnStruct> GetSuppliers()
        {
            List<SupplierReturnStruct> response = new List<SupplierReturnStruct>();

            SupplierReturnStruct newElement = new SupplierReturnStruct();
            newElement.SupplierID = 1;
			newElement.SupplierName = "Dummy 1";

            response.Add(newElement);
            newElement.SupplierID = 2;
            newElement.SupplierName = "Dummy 2";
            response.Add(newElement);

            return response;
        }

        public List<CustomerReturnStruct> GetCustomers()
        {
            List<CustomerReturnStruct> response = new List<CustomerReturnStruct>();

            CustomerReturnStruct newElement = new CustomerReturnStruct();
            newElement.CustomerID = 1;
            newElement.CustomerName = "Dummy 1";
			newElement.PartnerID = 1;

            response.Add(newElement);
            newElement.CustomerID = 2;
            newElement.CustomerName = "Dummy 2";
			newElement.PartnerID = 1;
            response.Add(newElement);

            return response;
        }

        public List<PartnerReturnStruct> GetPartners()
        {
            List<PartnerReturnStruct> response = new List<PartnerReturnStruct>();

            PartnerReturnStruct newElement = new PartnerReturnStruct();
            newElement.PartnerID = 1;
            newElement.PartnerName = "Dummy 1";

            response.Add(newElement);
            newElement.PartnerID = 2;
            newElement.PartnerName = "Dummy 2";
            response.Add(newElement);

            return response;
        }

        public List<AssetReturnStruct> GetAssetList()
        {
            List<AssetReturnStruct> response = new List<AssetReturnStruct>();

            var tempAsset = new AssetView("XXXX", 1, DateTime.Now);
            tempAsset.Assign(1, DateTime.Now);
            tempAsset.Assign(2, DateTime.Now);

            response.Add(tempAsset.GetAsset());

            return response;
        }
    }
}


