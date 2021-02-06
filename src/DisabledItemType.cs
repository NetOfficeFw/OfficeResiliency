using System;

namespace NetOffice.Tools
{
    public enum DisabledItemType
    {
        None = 0,
        AddInByFilename = 1,
        DocumentByPath = 2,
        OpenFailedFilename = 2,
        Workpane = 3,
        COMObject = 4,
        COMDEPObject = 5,
        AddInByDEPFilename = 6,
        Printer = 7,
        PrintTicket = 8,
        AppSpecificItems = 0x40000000,
        OutlookDisablePreviewPane = 0x40000000,
        OutlookAddinAutoDisabledByFileName = 1073741825
    }
}
