using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.F14;

public class F14Aircraft : Aircraft
{
    public override string Name => "F-14";

    public override Type GetAircraftConfigurationType()
    {
        return typeof(F14Configuration);
    }

    public override string GetAircraftModelName()
    {
        return "F14";
    }

    public override Configuration NewConfiguration()
    {
        return new F14Configuration();
    }

    public override int GetMaxWaypointElevation()
    {
        return 25000;
    }
}
