using System;
namespace Monitoring.View
{
	public class UnitView
	{
		private Int32 UnitID;
		private Int16 UnitStatus;
		private Int32 LocationID;
        private List<EnergyView> EnergyLog;

        public UnitView(Int32 passedUnitID, Int16 passedUnitStatus, Int32 passedLocationId)
		{
			UnitID = passedUnitID;
			UnitStatus = passedUnitStatus;
			LocationID = passedLocationId;
            EnergyLog = new List<EnergyView>();
        }

        public void RecordEnergy(DateTime passedStart, DateTime passedEnd, Double passedEnergy)
        {
            EnergyView newElement = new EnergyView(UnitID, passedStart, passedEnd, passedEnergy);

            EnergyLog.Add(newElement);
        }
    }
}

