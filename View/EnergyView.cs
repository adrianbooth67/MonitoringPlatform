using System;
namespace Monitoring.View
{
	public class EnergyView
	{
		private Int32 EnergyID;
		private Int32 UnitID;
		private DateTime StartDateTime;
		private DateTime EndDateTime;
		private Double EnergyCreated;

        public EnergyView(Int32 passedUnitID, DateTime PassedStart, DateTime passedEnd, Double passedEnergy)
		{
			EnergyID = 1;
			UnitID = passedUnitID;
			StartDateTime = PassedStart;
			EndDateTime = passedEnd;
			EnergyCreated = passedEnergy;
		}
	}
}

