namespace OnlineShop.Common.Options.ImageOption
{

    public class MainImage
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Quality { get; set; }
    }
    public class MainSlideShow : MainImage { }

    public class MediumSlideShow : MainImage { }

    public class MainBlog : MainImage { }

    public class MediumBlog : MainImage { }

    public class ThumbnailBlog : MainImage { }

    public class MainProduct : MainImage { }

    public class MediumProduct : MainImage { }

    public class ThumbnailProduct : MainImage { }

    public class MainSquareImage : MainImage { }

    public class MediumSquareImage : MainImage { }

    public class ThumbnailSquareImage : MainImage { }

    public class MainBrandCoverImage : MainImage { }

    public class MediumBrandCoverImage : MainImage { }

    public class ThumbnailBrandCoverImage : MainImage { }




}