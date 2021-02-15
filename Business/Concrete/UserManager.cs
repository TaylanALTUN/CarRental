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
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
            }
            catch
            {
                return new ErrorDataResult<List<User>>(Messages.UserCantList);
            }
        }

        public IDataResult<List<User>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(c => c.Id == id), Messages.UserListed);
            }
            catch
            {
                return new ErrorDataResult<List<User>>(Messages.UserCantList);
            }
        }

        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResut(Messages.UserAdded);

            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.UserCantAdd);
            }
        }

        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResut(Messages.UserUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.UserCantUpdate);
            }
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResut(Messages.UserDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.UserCantDelete);
            }
        }
    }
}
