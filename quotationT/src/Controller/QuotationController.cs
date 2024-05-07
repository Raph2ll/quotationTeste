using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using quotationT.src.Services.Interfaces;
using quotationT.src.Models;

namespace quotationT.src.Controller
{
    [Route("api")]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [HttpGet]
        public async Task<ActionResult<Quotation>> Get()
        {
            try
            {
                var res = await _quotationService.GetCurrencyInfo();
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}