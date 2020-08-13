using System;
using System.Collections.Generic;
using System.Text;
using SectorBuilder.Index;

namespace SectorBuilder.Build
{
    public class SectorSectionNameMap
    {
        public static readonly Dictionary<SectorSection, string> Map = new Dictionary<SectorSection, string>
        {
            [SectorSection.Color] = null,
            [SectorSection.Info] = "INFO",
            [SectorSection.Airport] = "AIRPORT",
            [SectorSection.Runway] = "RUNWAY",
            [SectorSection.VOR] = "VOR",
            [SectorSection.NDB] = "NDB",
            [SectorSection.Fix] = "FIXES",
            [SectorSection.HighAirway] = "HIGH AIRWAY",
            [SectorSection.LowAirway] = "LOW AIRWAY",
            [SectorSection.SID] = "SID",
            [SectorSection.STAR] = "STAR",
            [SectorSection.ARTCC] = "ARTCC",
            [SectorSection.ARTCCHigh] = "ARTCC HIGH",
            [SectorSection.ARTCCLow] = "ARTCC LOW",
            [SectorSection.Label] = "LABELS",
            [SectorSection.Geo] = "GEO",
            [SectorSection.Region] = "REGIONS",
            [SectorSection.Position] = "POSITIONS",
            [SectorSection.Freetext] = "FREETEXT",
            [SectorSection.SIDSTAR] = "SIDSSTARS",
            [SectorSection.Airspace] = "AIRSPACE",
            [SectorSection.Radar] = "RADAR",
            [SectorSection.Ground] = "GROUND"
        };
    }
}
