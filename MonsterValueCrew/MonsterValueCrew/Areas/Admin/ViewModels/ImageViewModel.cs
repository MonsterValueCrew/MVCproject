namespace MonsterValueCrew.Areas.Admin.ViewModels
{
    public class ImageViewModel
    {
        public string Name { get; set; }

        public byte[] ImageInBase64 { get; set; }

        public int Order { get; set; }
    }
}