using System.Linq;
using System.Threading.Tasks;

namespace DeliveriesModels
{
    public class DeliveryPerson
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async Task<bool> Login(string email, string password)
        {
            bool result = false;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                result = false;
            }
            else
            {
                var deliveryPerson = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(u => u.Email == email).ToListAsync())
                    .FirstOrDefault();

                if (deliveryPerson.Password == password)
                {
                    result = true;
                }
                else
                    result = false;

            }

            return result;
        }

        public static async Task<bool> Register(string email, string password, string confirmPassword)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(password))
            {
                if (password == confirmPassword)
                {
                    var deliveryPerson = new DeliveryPerson
                    {
                        Email = email,
                        Password = password
                    };

                    //await AzureHelper.MobileService.GetTable<User>().InsertAsync(user);
                    //using the generic helper method
                    await AzureHelper.Insert(deliveryPerson);
                    result = true;
                }

            }

            return result;
        }

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