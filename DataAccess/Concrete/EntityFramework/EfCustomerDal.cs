using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, CarRentalContex>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
            using (CarRentalContex context = new CarRentalContex())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.Id
                    select new CustomerDetailsDto
                    {
                        Id = c.Id,
                        CompanyName = c.CompanyName,
                        UserName = u.FirstName+" "+u.LastName

                    };
                return result.ToList();
            }
        }
    }
}
