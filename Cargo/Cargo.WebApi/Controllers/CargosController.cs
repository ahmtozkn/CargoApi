using Cargo.Business.Dtos;
using Cargo.Business.Services;
using Cargo.Data.Enums;
using Cargo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : Controller
    {
        private readonly ICargoService _cargoService;
        public CargosController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpPost]
        public IActionResult Add(AddCargoRequest addCargoRequest)
        {
            Random rnd = new Random();
           
            var addCargoDto = new AddCargoDto()
            {
                SenderAddress = addCargoRequest.SenderAddress,
                SenderCity = addCargoRequest.SenderCity,
                SenderDistrict = addCargoRequest.SenderDistrict,
                SenderFirstName = addCargoRequest.SenderFirstName,
                SenderLastName = addCargoRequest.SenderLastName,
                SenderTelNo = addCargoRequest.SenderTelNo,
                ShippingPrice = addCargoRequest.ShippingPrice,
                Status = addCargoRequest.Status,
                CargoNo = rnd.Next(1000,9999).ToString(),
                Contents = addCargoRequest.Contents,
                EmployeeId = addCargoRequest.EmployeeId,
                PaymentBy = addCargoRequest.PaymentBy,
                ProductName = addCargoRequest.ProductName,
                RecieverAddress = addCargoRequest.RecieverAddress,
                RecieverDistrict = addCargoRequest.RecieverDistrict,
                RecieverCity = addCargoRequest.RecieverCity,
                RecieverFirstName = addCargoRequest.RecieverFirstName,
                RecieverLastName = addCargoRequest.RecieverLastName,
                RecieverTcNo = addCargoRequest.RecieverTcNo,
                RecieverTelNo = addCargoRequest.RecieverTelNo,
                Weight = addCargoRequest.Weight,

            };
            var result = _cargoService.AddCargo(addCargoDto);

            if (result)
                return Ok();
            else
                return StatusCode(500);

        }

        [HttpGet]
        public IActionResult GetCargos()
        {
            var getCargosDtos = _cargoService.GetCargoList();

            var response = getCargosDtos.Select(x => new GetCargoResponse
            {
                Id = x.Id,
                SenderAddress = x.SenderAddress,
                SenderCity = x.SenderCity,
                SenderDistrict = x.SenderDistrict,
                SenderFirstName = x.SenderFirstName,
                SenderLastName = x.SenderLastName,
                SenderTelNo = x.SenderTelNo,
                ShippingPrice = x.ShippingPrice,
               PaymentBy=x.PaymentBy,
                Status = x.Status,
                CargoNo = x.CargoNo,
                Contents = x.Contents,
                EmployeeId = x.EmployeeId,
               
                ProductName = x.ProductName,
                RecieverAddress = x.RecieverAddress,
                RecieverCity = x.RecieverCity,
                RecieverDistrict = x.RecieverDistrict,
                RecieverFirstName = x.RecieverFirstName,
                RecieverLastName = x.RecieverLastName,
                RecieverTcNo = x.RecieverTcNo,
                RecieverTelNo = x.RecieverTelNo,
                Weight = x.Weight,


            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargo(int id)
        {
            var getCargoDto = _cargoService.GetCargo(id);

            if (getCargoDto is null)
                return NotFound();

            var response = new GetCargoResponse()
            {
                Id = id,
                CargoNo = getCargoDto.CargoNo,
                Contents = getCargoDto.Contents,
                SenderCity = getCargoDto.SenderCity,
                SenderAddress = getCargoDto.SenderAddress,
                SenderDistrict = getCargoDto.SenderDistrict,
                SenderFirstName = getCargoDto.SenderFirstName,
                SenderLastName = getCargoDto.SenderLastName,
                SenderTelNo = getCargoDto.SenderTelNo,
                ShippingPrice = getCargoDto.ShippingPrice,
                Status = getCargoDto.Status,
                EmployeeId = getCargoDto.EmployeeId,
                PaymentBy = getCargoDto.PaymentBy,
                ProductName = getCargoDto.ProductName,
                RecieverAddress = getCargoDto.RecieverAddress,
                RecieverCity = getCargoDto.RecieverCity,
                RecieverFirstName = getCargoDto.RecieverFirstName,
                RecieverDistrict = getCargoDto.RecieverDistrict,
                RecieverLastName = getCargoDto.RecieverLastName,
                RecieverTelNo = getCargoDto.RecieverTelNo,
                RecieverTcNo = getCargoDto.RecieverTcNo,
                Weight = getCargoDto.Weight,

            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCargo(int id,UpdateCargoRequest request)
        {

            var updateCargoDto = new UpdateCargoDto()
            {
                Id = id,
                CargoNo = request.CargoNo,
                SenderAddress = request.SenderAddress,
                SenderCity = request.SenderCity,
                SenderDistrict = request.SenderDistrict,
                SenderFirstName = request.SenderFirstName,
                SenderLastName = request.SenderLastName,
                SenderTelNo = request.SenderTelNo,
                ShippingPrice = request.ShippingPrice,
                Status = request.Status,
                Contents = request.Contents,
                EmployeeId = request.EmployeeId,
                PaymentBy = request.PaymentBy,
                ProductName = request.ProductName,
                RecieverAddress = request.RecieverAddress,
                RecieverCity = request.RecieverCity,
                RecieverDistrict = request.RecieverDistrict,
                RecieverFirstName = request.RecieverFirstName,
                RecieverLastName = request.RecieverLastName,
                RecieverTcNo = request.RecieverTcNo,
                RecieverTelNo = request.RecieverTelNo,
                Weight = request.Weight,
            };
            var result = _cargoService.UpdateCargo(updateCargoDto);
            if (result == 0)
                return NotFound();
            else if (result == 1)
                return Ok();
            else 
                return StatusCode(500);

                
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result=_cargoService.DeleteCargo(id);
            if (result == 0)
                return BadRequest();
            else if (result == 1)
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
