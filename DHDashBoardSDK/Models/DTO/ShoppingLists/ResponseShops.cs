using System;
namespace DHDashBoardSDK.Models.DTO.ShoppingLists
{
    public struct ResponseShops
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string PostCode { get; set; }

        public double? Lat { get; set; }

        public double? Lan { get; set; }


        public DateTime? LastVisitDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
