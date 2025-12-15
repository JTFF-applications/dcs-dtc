using DTC.Utilities;
using DTC.New.Presets.V2.Aircrafts.F14;
using DTC.New.Uploader.Base;
using DTC.Utilities.Extensions;

namespace DTC.New.Uploader.Aircrafts.F14;

public partial class F14Uploader : Base.Uploader
{
    private F14Configuration config;

    public F14Uploader(F14Aircraft ac, F14Configuration cfg) : base(ac, Settings.HornetCommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute()
    {
        this.BuildWaypointsAndSequences();
        this.BuildCMS();
        this.BuildRadios();
        this.BuildMisc();
        this.Send();
    }

    private void Coord(string coord)
    {
        // var (direction, (numbers, _)) = coord.Replace("°", "").Replace("’", "").Replace("”", "").Split(' ');
        // var (coordDegMin, (coordDecimal, _)) = numbers.Split('.');
        // if (coordDegMin.StartsWith('0')) coordDegMin = coordDegMin.Substring(1);
        // if (coordDecimal.Length == 1)
        // {
        //     coordDecimal += '5';
        // }

        // if (direction == "N")
        // {
        //     Cmd(UFC.D2);
        // }
        // else if (direction == "S")
        // {
        //     Cmd(UFC.D8);
        // }
        // else if (direction == "E")
        // {
        //     Cmd(UFC.D6);
        // }
        // else if (direction == "W")
        // {
        //     Cmd(UFC.D4);
        // }

        // Cmd(Digits(UFC, coordDegMin));
        // Cmd(UFC.ENT);
        // Cmd(Wait());
        // Cmd(Wait());
        // Cmd(Wait());
        // Cmd(Digits(UFC, coordDecimal));
        // Cmd(UFC.ENT);
        // Cmd(Wait());
        // Cmd(Wait());
        // Cmd(Wait());
    }
}