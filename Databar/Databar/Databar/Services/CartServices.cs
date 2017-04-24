using Databar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databar.Services
{
    public class CartServices
    {
        ObservableCollection<TempProd> list = new ObservableCollection<TempProd>();

        //denne skal hente fra sql
        public ObservableCollection<TempProd> getCartList()
        {
            //var list = new ObservableCollection<TempProd>
            list.Add(new TempProd
            {
                ID = 1,
                Name = "H-Melk Tine 1,5L DENNE VAR VELDIG LANG!!!",
                Discount = 20,
                DiscountType = "%",
                UnitCost = 112120.00m
            } );



            list.Add(new TempProd
            {
                ID = 1,
                Name = "H-Melk Tine 1,5L DENNE VAR VELDIG LANG!!!",
                Discount = 20,
                DiscountType = "%",
                UnitCost = 20.00m
            });

            /*    {
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
                };*/

            return list; 
        }

        public void Add(TempProd e)
        {
            list.Add(e);
        }

        public void RemoveProduct(TempProd t)
        {
            list.Remove(t);
        }

        public decimal Sum()
        {
            decimal sum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                Debug.WriteLine("HEI");
                Debug.WriteLine(list.Count);

                if (list[i].Discount == 0)
                {
                    Debug.WriteLine("INN EN");
                    sum += list[i].UnitCost;
                }
                else
                {
                    Debug.WriteLine("INN TO");
                    // sum += (list[i].UnitCost * (list[i].Discount / 100));
                    sum += (list[i].UnitCost);
                }
            }
            Debug.WriteLine("HEI");
            Debug.WriteLine(sum.ToString());
            return sum;
        }

    }
}
