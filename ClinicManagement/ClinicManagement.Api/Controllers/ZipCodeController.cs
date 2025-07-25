using BloodDonationDataBase.Domain.IServices;
using BloodDonationDataBase.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ClinicManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ZipCodeController : ControllerBase
    {
        private readonly IAddressZipCode _addressZip;

        public ZipCodeController(IAddressZipCode addressZip)
        {
            _addressZip = addressZip;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressByZipCode(string zipCode)
        {
            // Remove caracteres não numéricos
            var cleanedZipCode = Regex.Replace(zipCode, @"[^\d]", "");

            if (cleanedZipCode.Length != 8)
                return BadRequest("CEP deve conter 8 dígitos");

            var zipCodeInfo = await _addressZip.SearchZipCode(cleanedZipCode);

            if (zipCodeInfo is null)
                return NotFound("CEP não encontrado");

            return Ok(new
            {
                street = zipCodeInfo.Logradouro,  // Mapeando para os nomes que o frontend espera
                city = zipCodeInfo.Localidade,
                state = zipCodeInfo.Uf,
                zipCode = zipCodeInfo.Cep
            });


        }
    }
}
