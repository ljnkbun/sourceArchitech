namespace Shopfloor.FileStorage.Application.Definations
{
    public static class Folder
    {
        public const string Unspecified = "unspecified";
        public const string Masterial = "masterial";
        public const string Ied = "ied";
        public const string Barcode = "barcode";

        public static bool Contains(string folder)
        {
            var lower = folder.ToLower();
            return lower is Unspecified
                or Masterial
                or Ied
                or Barcode;
        }
    }
}
