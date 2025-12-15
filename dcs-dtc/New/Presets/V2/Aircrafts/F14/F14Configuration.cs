using DTC.New.Presets.V2.Aircrafts.F14.Systems;
using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.F14;

public class F14Configuration : Configuration
{
    public string Aircraft = "F14";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new UploadSystem();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new WaypointCaptureSystem();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new WaypointSystem();

    [System("CMS")]
    public CMSystem CMS { get; set; } = new CMSystem();

    [System("Radios")]
    public Base.Systems.RadioSystem Radios { get; set; } = new Base.Systems.RadioSystem();

    [System("Misc")]
    public MiscSystem Misc { get; set; } = new MiscSystem();

    public override void AfterLoadFromJson()
    {
    }

    public override string GetAircraftName()
    {
        return this.Aircraft;
    }

    protected override Type GetConfigurationType()
    {
        return typeof(F14Configuration);
    }
}
