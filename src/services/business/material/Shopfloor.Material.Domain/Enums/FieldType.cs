using System.ComponentModel;

namespace Shopfloor.Material.Domain.Enums;

public enum FieldType
{
    [Description("AlphaNumeric")]
    AlphaNumeric = 0,

    [Description("DropDown")]
    DropDown = 1,

    [Description("MultiSelectDropDown")]
    MultiSelectDropDown = 2,

    [Description("Date")]
    Date = 3,

    [Description("Numeric")]
    Numeric = 4,

    [Description("TextBox")]
    TextBox = 5
}