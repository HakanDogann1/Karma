﻿using Karma.DtoLayer.Dtos.ShoeDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface IShoeService:IGenericService<Shoe,ResultShoeDto,CreateShoeDto,UpdateShoeDto>
    {
    }
}
