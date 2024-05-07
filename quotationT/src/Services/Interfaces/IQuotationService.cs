using System;
using System.Collections.Generic;
using System.Linq;
using quotationT.src.Models;
using quotation.src.Services.Refit;

namespace quotationT.src.Services.Interfaces
{
    public interface IQuotationService
    {
        Task<Quotation> GetCurrencyInfo();
    }
}