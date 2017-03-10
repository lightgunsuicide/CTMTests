using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    interface IUser
    {
         string defaultPostcode { get; set; }
         bool hasBill { get; set; }
         bool isGasMainSourceOfHeating { get; set; }
         bool isElecticMainSourceOfHeating { get; set; }
         bool hasEconomy7Meter { get; set; }
         string measureElectricalUseIn { get; set; }
         int electricalUsesageValue { get; set; }
         string electricalUseageIncrement { get; set; }
         string measureGasUseIn { get; set; }
         int gasUsesageValue { get; set; }
         string gasUseageIncrement { get; set; }
         string emailAddress { get; set; }
         string supplier { get; set; }
        string paymentMethod { get; set; }
    }
}
