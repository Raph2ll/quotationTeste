using System.Globalization;
using quotationT.src.Models;
using quotation.src.Services.Refit;
using quotationT.src.Services.Interfaces;
using Newtonsoft.Json;

namespace quotationT.src.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IEconomy _economyApi;
        private readonly string _namespace = "Service";

        public QuotationService(IEconomy economyApi)
        {
            _economyApi = economyApi;
        }

        public async Task<Quotation> GetCurrencyInfo()
        {
            try
            {
                var currencyInfo = await _economyApi.GetCurrencyInfo();
                var quotation = new Quotation();

                quotation.CODE = currencyInfo["USDBRL"].Code;
                quotation.Value = Convert.ToDecimal(currencyInfo["USDBRL"].High, CultureInfo.InvariantCulture);
                quotation.CreatedAt = DateTime.Now;

                string json = JsonConvert.SerializeObject(quotation);

                return quotation;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting currency information: {ex.Message}");
            }
        }
    }
}

