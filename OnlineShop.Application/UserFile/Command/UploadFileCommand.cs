using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OnlineShop.Application.Common.Interface;
using OnlineShop.Application.UserFile.ModelDto;
using OnlineShop.Common.Enum;
using OnlineShop.Common.ImageProcessor;
using OnlineShop.Common.Options;
using OnlineShop.Common.Result;
using NotImplementedException = System.NotImplementedException;

namespace OnlineShop.Application.UserFile.Command
{
    public class UploadFileCommand : IRequest<Result<List<FileUploadDto>>>
    {
        public List<IFormFile> Files { get; set; }
        public string Type { get; set; }
        public UploadType? UploadType { get; set; }
    }

    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Result<List<FileUploadDto>>>
    {
        private readonly ICmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageProcessorService _imageProcessorService;
        private readonly IWebHostEnvironment _env;
        private readonly ImageSetting _imageSetting;

        public UploadFileCommandHandler(ICmsDbContext context, IMapper mapper, IImageProcessorService imageProcessorService, IWebHostEnvironment env, IOptions<ImageSetting> imageSetting)
        {
            _context = context;
            _mapper = mapper;
            _imageProcessorService = imageProcessorService;
            _env = env;
            _imageSetting = imageSetting.Value;
        }

        public async Task<Result<List<FileUploadDto>>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {

            var result = new List<FileUploadDto>();
            foreach (var item in request.Files)
            {
                var tempPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", item.FileName)/*Path.Combine(ApplicationStaticPath.Images, )*/;
                var fileName = Path.GetFileNameWithoutExtension(tempPath);
                var extension = Path.GetExtension(tempPath);
                var uniqueId = Guid.NewGuid().ToString("N");
                var newName = $"{uniqueId}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", newName);

                await using var fileStream = new FileStream(filePath, FileMode.Create);
                item.CopyTo(fileStream);

                if (request.UploadType.HasValue)
                    switch (request.UploadType)
                    {
                        case UploadType.SlideShow:
                            var mainSlideShow = _imageProcessorService.Crop(item, _imageSetting.MainSlideShow.Width, _imageSetting.MainSlideShow.Height);
                            var mediumSlideShow = _imageProcessorService.Crop(item, _imageSetting.MediumSlideShow.Width, _imageSetting.MediumSlideShow.Height);

                            _imageProcessorService.Save(mainSlideShow, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_n{extension}"), $"{fileName}_n", _imageSetting.MainSlideShow.Quality);
                            _imageProcessorService.Save(mediumSlideShow, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_m{extension}"), $"{fileName}_m", _imageSetting.MediumSlideShow.Quality);

                            break;
                        case UploadType.Blog:
                            var mainImageBlog = _imageProcessorService.Crop(item, _imageSetting.MainBlog.Width, _imageSetting.MainBlog.Height);

                            var mediumImageBlog = _imageProcessorService.Crop(item, _imageSetting.MediumBlog.Width, _imageSetting.MediumBlog.Height);

                            var thumbnailImageBlog = _imageProcessorService.Crop(item, _imageSetting.ThumbnailBlog.Width, _imageSetting.ThumbnailBlog.Height);

                            _imageProcessorService.Save(mainImageBlog, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_n{extension}"), $"{fileName}_m", _imageSetting.MainBlog.Quality);

                            _imageProcessorService.Save(mediumImageBlog, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_m{extension}"), $"{fileName}_n", _imageSetting.MediumBlog.Quality);

                            _imageProcessorService.Save(thumbnailImageBlog, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_t{extension}"), $"{fileName}_t", _imageSetting.ThumbnailBlog.Quality);


                            break;
                        case UploadType.Brand:
                            var mainBrand = _imageProcessorService.Crop(item, _imageSetting.MainBrandCoverImage.Width, _imageSetting.MainBrandCoverImage.Height);
                            var mediumBrand = _imageProcessorService.Crop(item, _imageSetting.MediumBrandCoverImage.Width, _imageSetting.MediumBrandCoverImage.Height);
                            var thumbnailBrand = _imageProcessorService.Crop(item, _imageSetting.ThumbnailBrandCoverImage.Width, _imageSetting.ThumbnailBrandCoverImage.Height);

                            _imageProcessorService.Save(mainBrand, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_n{extension}"), $"{fileName}_n", _imageSetting.MainSquareImage.Quality);

                            _imageProcessorService.Save(mediumBrand, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_m{extension}"), $"{fileName}_m", _imageSetting.MediumSquareImage.Quality);

                            _imageProcessorService.Save(thumbnailBrand, Path.Combine(_env.ContentRootPath, ApplicationStaticPath.Images, $"{uniqueId}_t{extension}"), $"{fileName}_t", _imageSetting.ThumbnailSquareImage.Quality);

                            break;

                        case UploadType.Guitar:
                            break;
                        case UploadType.Square:
                            break;
                        case UploadType.Product:
                            break;
                        case null:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }


                else
                {
                    using var image = Image.FromStream(item.OpenReadStream());
                    if (image.Height == image.Width)
                    {
                        var mainSquare = _imageProcessorService.Crop(item, _imageSetting.MainSquareImage.Width, _imageSetting.MainSquareImage.Height);
                        var mediumSquare = _imageProcessorService.Crop(item, _imageSetting.MediumSquareImage.Width, _imageSetting.MediumSquareImage.Height);
                        var thumbnailSquare = _imageProcessorService.Crop(item, _imageSetting.ThumbnailSquareImage.Width, _imageSetting.ThumbnailSquareImage.Height);

                        _imageProcessorService.Save(mainSquare, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_n{extension}"), $"{fileName}_n", _imageSetting.MainSquareImage.Quality);

                        _imageProcessorService.Save(mediumSquare, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_m{extension}"), $"{fileName}_m", _imageSetting.MediumSquareImage.Quality);

                        _imageProcessorService.Save(thumbnailSquare, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_t{extension}"), $"{fileName}_t", _imageSetting.ThumbnailSquareImage.Quality);

                    }

                    else if (image.Height > image.Width)
                    {
                        var mainImageProduct = _imageProcessorService.Crop(item, _imageSetting.MainProduct.Width, _imageSetting.MainProduct.Height);
                        var mediumImageProduct = _imageProcessorService.Crop(item, _imageSetting.MediumProduct.Width, _imageSetting.MediumProduct.Height);
                        var thumbnailImageProduct = _imageProcessorService.Crop(item, _imageSetting.ThumbnailProduct.Width, _imageSetting.ThumbnailProduct.Height);


                        _imageProcessorService.Save(mainImageProduct, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_n{extension}"), $"{fileName}_n", _imageSetting.MainProduct.Quality);

                        _imageProcessorService.Save(mediumImageProduct, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_m{extension}"), $"{fileName}_m", _imageSetting.MediumProduct.Quality);

                        _imageProcessorService.Save(thumbnailImageProduct, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_t{extension}"), $"{fileName}_t", _imageSetting.ThumbnailProduct.Quality);

                    }

                    else if (image.Height < image.Width)
                    {
                        var mainImageProduct = _imageProcessorService.Crop(item, _imageSetting.MainProduct.Height, _imageSetting.MainProduct.Width);
                        var mediumImageProduct = _imageProcessorService.Crop(item, _imageSetting.MediumProduct.Height, _imageSetting.MediumProduct.Width);
                        var thumbnailImageProduct = _imageProcessorService.Crop(item, _imageSetting.ThumbnailProduct.Height, _imageSetting.ThumbnailProduct.Width);


                        _imageProcessorService.Save(mainImageProduct, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_n{extension}"), $"{fileName}_n", _imageSetting.MainProduct.Quality);

                        _imageProcessorService.Save(mediumImageProduct, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_m{extension}"), $"{fileName}_m", _imageSetting.MediumProduct.Quality);

                        _imageProcessorService.Save(thumbnailImageProduct, Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\uploads\images\", $"{uniqueId}_t{extension}"), $"{fileName}_t", _imageSetting.ThumbnailProduct.Quality);

                    }
                }

                var fileUrl = $"{ApplicationStaticPath.Images}/{newName}";

                var userFile = new Domain.Entities.UserManagement.UserFile
                {
                    Name = fileName,
                    Size = item.Length,
                    UniqueId = uniqueId,
                    Url = fileUrl,
                    MediaType = item.ContentType,
                    Path = Path.Combine(ApplicationStaticPath.Images, newName),
                };


                await _context.UserFiles.AddAsync(userFile, cancellationToken);
                var dto = _mapper.Map<FileUploadDto>(userFile);
                result.Add(dto);

            }

            return Result<List<FileUploadDto>>.SuccessFull(result);
        }
    }
}