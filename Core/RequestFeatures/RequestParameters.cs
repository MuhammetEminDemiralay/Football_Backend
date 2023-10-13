﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
		const int _maxPageSize = 50;
        public int PageNumber { get; set; }
		private int _pageSize;

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
		}

	}
}
