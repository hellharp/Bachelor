using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    public class CartServices
    {

        //denne skal hente fra sql
        public ObservableCollection<TempProd> getCartList()
        {
            var list = new ObservableCollection<TempProd>
            {
                new TempProd
            {
                ID=1, Name="H-Melk Tine 1,5L DENNE VAR VELDIG LANG!!!", Discount=20, DiscountType="%", UnitCost=10.00m
            },
             new TempProd
            {
                ID=2, Name="H-Melk Tine 1,5L",Discount=0, DiscountType="", UnitCost=12.50m
            }, new TempProd
            {
                ID=3, Name="Brød Kneip", Discount=50, DiscountType="%", UnitCost=16.00m
            }, new TempProd
            {
                ID=4, Name="Kaviar Mills", Discount=0, DiscountType="", UnitCost=29.70m
            },
            };
            return list;
        }
    }
}
