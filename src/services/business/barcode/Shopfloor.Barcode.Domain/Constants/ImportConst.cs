namespace Shopfloor.Barcode.Domain.Constants
{

    public enum ImportStatus : byte { Processing = 0, Completed = 1, TransfertoWFX = 2 }
    public enum ImportType : byte
    {
        ImportPO = 0,
        ImportTransferToSite = 1
    }

    public static class FlexFieldConstant
    {
        public const string GRADE = "Grade";
        public const string MICRONAIRE = "Micronaire";
        public const string ORIGIN = "Origin";
        public const string STAPLE = "Staple";
        public const string STRENGTH = "Strength";
    }
}
