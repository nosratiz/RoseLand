using OnlineShop.Common.Options.ImageOption;

namespace OnlineShop.Common.Options
{
    public class ImageSetting
    {
        public MainSlideShow MainSlideShow { get; set; }

        public MediumSlideShow MediumSlideShow { get; set; }

        public MainProduct MainProduct { get; set; }

        public MediumProduct MediumProduct { get; set; }

        public ThumbnailProduct ThumbnailProduct { get; set; }

        public MainBlog MainBlog { get; set; }

        public MediumBlog MediumBlog { get; set; }

        public ThumbnailBlog ThumbnailBlog { get; set; }

        public MainSquareImage MainSquareImage { get; set; }

        public MediumSquareImage MediumSquareImage { get; set; }

        public ThumbnailSquareImage ThumbnailSquareImage { get; set; }

        public MainBrandCoverImage MainBrandCoverImage { get; set; }

        public MediumBrandCoverImage MediumBrandCoverImage { get; set; }

        public ThumbnailBrandCoverImage ThumbnailBrandCoverImage { get; set; }
    }
}