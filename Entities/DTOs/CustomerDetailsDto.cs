using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailsDto:IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
    }
}
