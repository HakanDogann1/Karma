using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        private readonly IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void TAdd(ImageFile entity)
        {
            _imageFileDal.Add(entity);
        }

        public void TDelete(ImageFile entity)
        {
           _imageFileDal.Delete(entity);
        }

        public ImageFile TGetById(int id)
        {
            return _imageFileDal.GetById(id);
        }

        public List<ImageFile> TGetList()
        {
            return _imageFileDal.GetList();
        }

        public void TUpdate(ImageFile entity)
        {
            _imageFileDal.Update(entity);
        }
    }
}
