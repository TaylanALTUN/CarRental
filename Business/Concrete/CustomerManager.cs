using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<CustomerDetailsDto>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetCustomerDetails(), Messages.CustomerListed);
            }
            catch
            {
                return new ErrorDataResult<List<CustomerDetailsDto>>(Messages.CustomerCantList);
            }
        }

        public IDataResult<List<Customer>> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.Id == id), Messages.CustomerListed);
            }
            catch
            {
                return new ErrorDataResult<List<Customer>>(Messages.CustomerCantList);
            }
        }

        public IResult Add(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
                return new SuccessResut(Messages.CustomerAdded);

            }
            catch
            {
                return new ErrorResult(Messages.CustomerCantAdd);
            }
        }

        public IResult Update(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new SuccessResut(Messages.CustomerUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.CustomerCantUpdate);
            }
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResut(Messages.CustomerDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.CustomerCantDelete);
            }
        }
    }
}
