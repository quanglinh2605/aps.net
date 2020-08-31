﻿using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
