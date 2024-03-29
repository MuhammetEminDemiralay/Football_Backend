﻿using Core.DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IClubDal : IEntityRepository<Club>
    {
        Task<List<ClubDetailDto>> GetClubDetailAsync(Expression<Func<ClubDetailDto, bool>> filter = null);
        Task<ClubDetailDto> GetClubDetailByClubIdAsync(Expression<Func<ClubDetailDto, bool>> filter);
    }
}
