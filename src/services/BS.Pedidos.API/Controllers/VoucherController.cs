using BS.Pedidos.Application.DTOs;
using BS.Pedidos.Application.Queries;
using BS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BS.Pedidos.API.Controllers
{
    public class VoucherController(IVoucherQueries voucherQueries) : MainController
    {
        private readonly IVoucherQueries _voucherQueries = voucherQueries;


        [HttpGet("voucher/{codigo}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return NotFound(); 

            var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

            return voucher is null ? NotFound() : CustomResponse(voucher);
        }
    }
}
