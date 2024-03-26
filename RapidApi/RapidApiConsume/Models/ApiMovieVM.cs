namespace RapidApiConsume.Models
{
    public class ApiMovieVM
    {
        //prop isimleri RapidApi sitesindeki Results kısmındaki Body içindeki parametrelerle birebir aynı olması gerekir.

        public int rank { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string big_image { get; set; }
        public int year { get; set; }
    }
}
