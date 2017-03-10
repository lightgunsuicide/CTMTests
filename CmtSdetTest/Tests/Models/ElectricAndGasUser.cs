using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class ElectricAndGasUser : IUser
    {
        public string defaultPostcode { get; set; }
        public bool hasBill { get; set; }
        public bool isGasMainSourceOfHeating { get; set; }
        public bool isElecticMainSourceOfHeating { get; set; }
        public bool hasEconomy7Meter { get; set; }
        public string measureElectricalUseIn { get; set; }
        public int electricalUsesageValue { get; set; }
        public string electricalUseageIncrement { get; set; }
        public string measureGasUseIn { get; set; }
        public int gasUsesageValue { get; set; }
        public string gasUseageIncrement { get; set; }
        public string emailAddress { get; set; }
        public string supplier { get; set; }
        public string paymentMethod { get; set; }

        public ElectricAndGasUser() {
            //Define default values for all fields
            defaultPostcode = "PE2 6YS";
            hasBill = false;
            isGasMainSourceOfHeating = false;
            isElecticMainSourceOfHeating = true;
            hasEconomy7Meter = false;
            measureElectricalUseIn = "kWh";
            electricalUseageIncrement = "Annually";
            measureGasUseIn = "pound";
            gasUsesageValue = 199;
            electricalUsesageValue = 201;
            gasUseageIncrement = "Monthly";
            emailAddress = "beenUpAllNight@thistask.org";
        }
    }
}
