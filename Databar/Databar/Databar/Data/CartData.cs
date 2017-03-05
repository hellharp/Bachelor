using System.Collections.ObjectModel;


//Denne skal erstattes med informasjonen som ligger i databasen.


namespace Databar.Data
{

    public class TempProd
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public decimal UnitCost { get; set; }
    }


    public class CartData
    {

        public static ObservableCollection<TempProd> ProductList = new ObservableCollection<TempProd>
        {
            new TempProd
            {
                ID=1, Name="H-Melk Tine 1,5L", Discount=20, UnitCost=10.00m
            },
             new TempProd
            {
                ID=2, Name="H-Melk Tine 1,5L",Discount=0, UnitCost=12.50m
            }, new TempProd
            {
                ID=3, Name="Brød Kneip", Discount=50, UnitCost=16.00m
            }, new TempProd
            {
                ID=4, Name="Kaviar Mills", Discount=0, UnitCost=29.70m
            }
        };

        public static decimal Sum()
        {
            decimal sum = 0;

            for(int i = 0; i < ProductList.Count; i++)
            {
                sum += ProductList[i].Discount;
            }

            return sum;
        }

    }

}

