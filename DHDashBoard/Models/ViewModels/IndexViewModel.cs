using System;
using System.Collections.Generic;
using DHDashBoardSDK.Models.DTO.ShoppingLists;

namespace DHDashBoard.Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
        }

        public List<ResponseShops> Shops { get; set; }
    }
}
