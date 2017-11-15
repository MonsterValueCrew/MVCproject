namespace MonsterValueCrew.Data.DataModels
{
    public class ImageViewModel
    {
        public string Name { get; set; }

        public byte[] ImageInBase64 { get; set; }

        public int Order { get; set; }

        public string ImageUrl { get; set; }
    }
}