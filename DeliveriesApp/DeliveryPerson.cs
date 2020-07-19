using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeliveriesApp
{
    public class DeliveryPerson
    {
        public string Id { get; set; }

        public static async Task<DeliveryPerson> GetDeliveryPerson(string id)
        {
            DeliveryPerson deliveryPerson = new DeliveryPerson();

            deliveryPerson =
                (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(dp => dp.Id == id).ToListAsync())
                .FirstOrDefault();

            return deliveryPerson;
        }
    }
}