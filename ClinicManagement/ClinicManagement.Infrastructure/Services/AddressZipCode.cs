
using BloodDonationDataBase.Domain.IServices;
using BloodDonationDataBase.Domain.Models.CepResponse;
using Newtonsoft.Json;

namespace BloodDonationDataBase.Infrastructure.Services
{
    public class AddressZipCode : IAddressZipCode
    {
        public async Task<ViaCepResponse> SearchZipCode(string zipCode)
        {
            using var client = new HttpClient();
            var url = $"https://viacep.com.br/ws/{zipCode}/json/";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ViaCepResponse>(json);
            }
            else
            {
                return null;
            }
        }
    }
}
