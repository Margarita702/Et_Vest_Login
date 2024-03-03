using System;
using System.ComponentModel.DataAnnotations;

namespace ET_Vest.Models
{
    public class Sale
    {
        [Key]
        public int SalesId { get; set; }

        public DateTime DateOfSale { get; set; }

        public int PrintedEditionId { get; set; }
        public PrintedEdition PrintedEdition { get; set; }

        public int TradeObjectId { get; set; }
        public TradeObject TradeObject { get; set; }

        public double SoldQuantity { get; set; }

        public double SalePrice { get; set; }

        public double Sum
        {
            get
            {
                return SoldQuantity * SalePrice;
            }
        }
    }
}
