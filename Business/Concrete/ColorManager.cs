using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager :IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
            }
            catch
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorCantList);
            }
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.Id == id), Messages.CarListed);
            }
            catch
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorCantList);
            }

        }

        public IResult Add(Color color)
        {
            try
            {
                _colorDal.Add(color);
                return new SuccessResut(Messages.ColorAdded);

            }
            catch
            {
                return new ErrorResult(Messages.ColorCantAdd);
            }


        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessResut(Messages.ColorUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.ColorCantUpdate);
            }
        }

        public IResult Delete(Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResut(Messages.ColorDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.ColorCantDelete);
            }
        }
    }
}
