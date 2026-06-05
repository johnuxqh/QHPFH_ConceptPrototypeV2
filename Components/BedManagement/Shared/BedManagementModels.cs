namespace QHPFH_ConceptPrototype.Components.BedManagement.Shared;

public enum BedManagementLevel
{
    Statewide,
    Hhs,
    Facility,
    Ward
}

public enum BedManagementVersion
{
    V1DataInsights,
    V2Balanced,
    V3Operational
}

public sealed record BedManagementOption(string Value, string Label);

public sealed record BedManagementReference(
    BedManagementLevel Level,
    BedManagementVersion Version,
    string Purpose,
    string ReferenceFile);
