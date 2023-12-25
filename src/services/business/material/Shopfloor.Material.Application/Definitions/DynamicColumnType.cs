namespace Shopfloor.Material.Application.Definitions
{
    public static class DynamicColumnType
    {
        public static readonly string[] FabricDc = { "TCFNO", "GSM", "NoOfEnds", "SpinningMethod", "Certificate", "Gauge", "StitchLength", "YarnComposition", "CutWidth", "Structure" };

        public static readonly string[] TrimsDc = { "ButtonType", "ButtonHole", "ElasticType", "RivetType", "ZipperType", "Layer", "Brand", "Tex" };

        public static readonly string[] YarnDc = { "SpinningMethod", "CountType", "Certificate", "SpinningProcess", "Pattern", "Twist" };
    }
}