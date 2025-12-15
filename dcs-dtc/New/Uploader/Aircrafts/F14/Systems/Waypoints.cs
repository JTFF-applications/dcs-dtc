using DTC.New.Presets.V2.Aircrafts.F14.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.F14;

public partial class F14Uploader
{
    private bool CheckWaypoints()
    {
        if (config.Upload.Waypoints == false ||
            config.Waypoints == null ||
            config.Waypoints.Waypoints == null ||
            config.Waypoints.Waypoints.Count == 0)
        {
            return false;
        }

        return true;
    }

    private void BuildWaypointsAndSequences()
    {
        var doWaypoints = CheckWaypoints();
        var doSequences = false;
        var doBullseye = false;
        var hideMapHSI = false;
        var blimTac = false;
        var baroWarn = false;
        var radarWarn = false;

        if (config.Upload.Misc && config.Misc != null)
        {
            if (config.Misc.BullseyeToBeUpdated) doBullseye = true;
            if (config.Misc.HideMapOnHSI) hideMapHSI = true;
            if (config.Misc.BlimTac) blimTac = true;
            if (config.Misc.BaroToBeUpdated) baroWarn = true;
            if (config.Misc.RadarToBeUpdated) radarWarn = true;
        }

        if (!doWaypoints && !doSequences && !doBullseye && !hideMapHSI && !blimTac && !baroWarn && !radarWarn)
        {
            return;
        }

        // Loop(RightMFDSUPT(), RMFD.OSB18);
        // Cmd(RMFD.OSB02); //HSI

        // if (hideMapHSI)
        // {
        //     Cmd(RMFD.OSB03); //Mode
        //     IfElse(MapBoxed(), new[] { RMFD.OSB03 }, new[] { RMFD.OSB01 });
        // }

        // Cmd(RMFD.OSB10); //Data
        // Cmd(RMFD.OSB06); //A/C
        
        // if (blimTac)
        // {
        //     If(IsBankLimitOnNav(), RMFD.OSB04); //BLIM
        // }
        // if (baroWarn)
        // {
        //     Cmd(RMFD.OSB20);
        //     Cmd(Digits(UFC, config.Misc.BaroWarn.ToString()));
        //     Cmd(UFC.ENT);
        // }
        // if (radarWarn)
        // {
        //     Cmd(RMFD.OSB19);
        //     Cmd(Digits(UFC, config.Misc.RadarWarn.ToString()));
        //     Cmd(UFC.ENT);
        // }

        // if (doWaypoints)
        // {
        //     Cmd(RMFD.OSB06); //AC
        //     If(IsLatLongNotDecimal(), RMFD.OSB15);
        //     Cmd(RMFD.OSB07); //WYPT
        //     If(IsPreciseNotSelected(), RMFD.OSB19);
        //     Loop(SequencesDeselected(), RMFD.OSB15, Wait());

        //     foreach (var wpt in config.Waypoints.Waypoints)
        //     {
        //         Cmd(GoToWaypoint(wpt.Sequence));
        //         Cmd(RMFD.OSB05); //UFC
        //         Cmd(UFC.OPT1);
        //         Cmd(Wait());
        //         Coord(wpt.Latitude);
        //         Coord(wpt.Longitude);
        //         Cmd(UFC.OPT3);
        //         Cmd(Wait());
        //         Cmd(UFC.OPT1);
        //         Cmd(Digits(UFC, wpt.Elevation.ToString()));
        //         Cmd(UFC.ENT);

        //         if (doBullseye)
        //         {
        //             if (wpt.Sequence == config.Misc.BullseyeWP)
        //             {
        //                 If(IsNotBullseye(), RMFD.OSB02);
        //                 doBullseye = false;
        //             }
        //         }
        //     }
        // }

        // if (doBullseye)
        // {
        //     Cmd(RMFD.OSB07); //WYPT
        //     Loop(SequencesDeselected(), RMFD.OSB15, Wait());
        //     Cmd(GoToWaypoint(config.Misc.BullseyeWP));
        //     If(IsNotBullseye(), RMFD.OSB02);
        // }

        // if (doWaypoints || doBullseye)
        // {
        //     Cmd(GoToWaypoint(1));
        // }

        // if (doSequences)
        // {
        //     Cmd(RMFD.OSB07); //WYPT

        //     if (config.Sequences.EnableUpload1)
        //     {
        //         Loop(IsSequenceSelected(1), RMFD.OSB15, Wait());
        //         Cmd(RMFD.OSB01); // SEQUFC
        //         ClearSequence();
        //         InputSequence(config.Sequences.Seq1);
        //     }
        //     if (config.Sequences.EnableUpload2)
        //     {
        //         Loop(IsSequenceSelected(2), RMFD.OSB15, Wait());
        //         Cmd(RMFD.OSB01); // SEQUFC
        //         ClearSequence();
        //         InputSequence(config.Sequences.Seq2);
        //     }
        //     if (config.Sequences.EnableUpload3)
        //     {
        //         Loop(IsSequenceSelected(3), RMFD.OSB15, Wait());
        //         Cmd(RMFD.OSB01); // SEQUFC
        //         ClearSequence();
        //         InputSequence(config.Sequences.Seq3);
        //     }
        // }

        // Cmd(UFC.CLR);

        // Loop(RightMFDSUPT(), RMFD.OSB18);
        // Cmd(RMFD.OSB15); //FCS
    }

    private Condition IsBankLimitOnNav()
    {
        return new Condition($"IsBankLimitOnNav()");
    }

    private Condition IsLatLongNotDecimal()
    {
        return new Condition($"IsLatLongNotDecimal()");
    }

    private Condition IsNotBullseye()
    {
        return new Condition($"NotBullseye()");
    }

    private Condition IsSequenceSelected(int sequence)
    {
        return new Condition($"SequenceSelected('{sequence}')");
    }

    private Condition IsInSequence(int wpt)
    {
        return new Condition($"InSequence('{wpt}')");
    }

    private CustomCommand GoToWaypoint(int sequence)
    {
        var delay = (Settings.HornetCommandDelayMs * 2).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"GoToWaypoint({sequence}, '', '', '', {delay})");
    }
}
