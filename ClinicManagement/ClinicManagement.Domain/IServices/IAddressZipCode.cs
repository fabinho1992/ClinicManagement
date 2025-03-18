using BloodDonationDataBase.Domain.Models.CepResponse;

namespace BloodDonationDataBase.Domain.IServices
{
    public interface IAddressZipCode
    {
        Task<ViaCepResponse> SearchZipCode(string zipCode);
    }
}
