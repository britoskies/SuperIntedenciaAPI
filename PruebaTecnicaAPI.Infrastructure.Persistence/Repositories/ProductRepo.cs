﻿using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPI.Core.Application.Interfaces.Repositories;
using PruebaTecnicaAPI.Infrastructure.Persistence.Contexts;
using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Infrastructure.Persistence.Repositories
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(ApplicationContext context) : base(context) { }
    }
}
