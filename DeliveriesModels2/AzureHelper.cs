using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveriesModels
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