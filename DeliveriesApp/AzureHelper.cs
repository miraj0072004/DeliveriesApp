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
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveriesApp
{
    public class AzureHelper
    {
        public static MobileServiceClient MobileService =
            new MobileServiceClient("https://xamarindeliveriesmirajapp.azurewebsites.net");

        public static async Task<bool> Insert<T>(T objectToInsert)
        {
            try
            {
                await MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}