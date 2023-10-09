using Cargo.Business.Dtos;
using Cargo.Business.Services;
using Cargo.Data.Entities;
using Cargo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Business.Managers
{
    public class CargoManager : ICargoService
    {
        private readonly IRepository<CargoEntity> _cargoRepository;
        public CargoManager(IRepository<CargoEntity> cargoRepository )
        {
            _cargoRepository = cargoRepository;
                
        }
        public bool AddCargo(AddCargoDto addCargoDto)
        {

            var entity = new CargoEntity()
            {
                CargoNo = addCargoDto.CargoNo,
                Contents = addCargoDto.Contents,
                RecieverAddress = addCargoDto.RecieverAddress,
                ProductName = addCargoDto.ProductName,
                PaymentBy = addCargoDto.PaymentBy,
                SenderCity = addCargoDto.SenderCity,
                RecieverCity = addCargoDto.RecieverCity,
                SenderAddress = addCargoDto.SenderAddress,
                SenderDistrict = addCargoDto.SenderDistrict,
                SenderFirstName = addCargoDto.SenderFirstName,
                SenderLastName = addCargoDto.SenderLastName,
                SenderTelNo = addCargoDto.SenderTelNo,
                ShippingPrice = addCargoDto.ShippingPrice,
                Status = addCargoDto.Status,
                EmployeeId = addCargoDto.EmployeeId,
                RecieverDistrict = addCargoDto.RecieverDistrict,
                RecieverFirstName = addCargoDto.RecieverFirstName,
                RecieverLastName = addCargoDto.RecieverLastName,
                RecieverTcNo = addCargoDto.RecieverTcNo,
                Weight = addCargoDto.Weight,
                RecieverTelNo = addCargoDto.RecieverTelNo


            };
            try
            {
                _cargoRepository.Add(entity);
                return true;
            }
            catch (Exception) 
            {
                return false;
            
            }
        }

        public int DeleteCargo(int id)
        {
            var entity=_cargoRepository.GetById(id);
            if (entity is null)
                return 0;
            try
            {
                _cargoRepository.Delete(entity);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }

        public GetCargoDto GetCargo(int id)
        {
            var entity= _cargoRepository.GetById(id);
            if (entity is null)
             return null;




            var getCargoDto = new GetCargoDto()
            {
                SenderAddress = entity.SenderAddress,
                SenderCity = entity.SenderCity,
                SenderDistrict = entity.SenderDistrict,
                SenderFirstName = entity.SenderFirstName,
                SenderLastName = entity.SenderLastName,
                SenderTelNo = entity.SenderTelNo,
                ShippingPrice = entity.ShippingPrice,
                Status = entity.Status,
                CargoNo = entity.CargoNo,
                Contents = entity.Contents,
                EmployeeId = entity.EmployeeId,
                PaymentBy = entity.PaymentBy,
                ProductName = entity.ProductName,
                RecieverAddress= entity.RecieverAddress,    
                RecieverDistrict= entity.RecieverDistrict,
                RecieverCity= entity.RecieverCity,
                Id = entity.Id,
                RecieverFirstName= entity.RecieverFirstName,
                RecieverLastName= entity.RecieverLastName,
                RecieverTcNo= entity.RecieverTcNo,
                RecieverTelNo= entity.RecieverTelNo,
                Weight= entity.Weight,
                



            };
            return getCargoDto;
        }

        public List<ListCargoDto> GetCargoList()
        {
            var cargoListDto = _cargoRepository.GetAll().Select(x => new ListCargoDto()
            {

                SenderAddress = x.SenderAddress,
                SenderCity = x.SenderCity,
                SenderDistrict = x.SenderDistrict,
                SenderFirstName = x.SenderFirstName,
                SenderLastName = x.SenderLastName,
                SenderTelNo = x.SenderTelNo,
                ShippingPrice = x.ShippingPrice,
                Status = x.Status,
                CargoNo = x.CargoNo,
                Contents = x.Contents,
                EmployeeId = x.EmployeeId,
                PaymentBy = x.PaymentBy,
                ProductName = x.ProductName,
                RecieverAddress = x.RecieverAddress,
                RecieverDistrict = x.RecieverDistrict,
                RecieverCity = x.RecieverCity,
                Id = x.Id,
                RecieverFirstName = x.RecieverFirstName,
                RecieverLastName = x.RecieverLastName,
                RecieverTcNo = x.RecieverTcNo,
                RecieverTelNo = x.RecieverTelNo,
                Weight = x.Weight,
            }).ToList();
            return cargoListDto;
        }

        public int UpdateCargo(UpdateCargoDto updateCargoDto)
        {
            var cargoEntity=_cargoRepository.GetById(updateCargoDto.Id);

            if (cargoEntity is null)
                return 0;

            cargoEntity.PaymentBy = updateCargoDto.PaymentBy;   
            
            cargoEntity.SenderCity = updateCargoDto.SenderCity;
            cargoEntity.SenderDistrict = updateCargoDto.SenderDistrict;
            cargoEntity.SenderFirstName= updateCargoDto.SenderFirstName;
            cargoEntity.SenderLastName= updateCargoDto.SenderLastName;
            cargoEntity.SenderAddress= updateCargoDto.SenderAddress;    
            cargoEntity.SenderTelNo= updateCargoDto.SenderTelNo;
            cargoEntity.RecieverAddress = updateCargoDto.RecieverAddress;
            cargoEntity.RecieverCity=updateCargoDto.RecieverCity;
            cargoEntity.RecieverDistrict = cargoEntity.RecieverDistrict;
            
            cargoEntity.ShippingPrice= updateCargoDto.ShippingPrice;
            cargoEntity.RecieverFirstName= updateCargoDto.RecieverFirstName;
            cargoEntity.RecieverLastName= updateCargoDto.RecieverLastName;
            cargoEntity.CargoNo= updateCargoDto.CargoNo;
            cargoEntity.Contents= updateCargoDto.Contents;
            cargoEntity.RecieverTcNo = updateCargoDto.RecieverTcNo;
            cargoEntity.RecieverTelNo = updateCargoDto.RecieverTelNo;
            cargoEntity.Status= updateCargoDto.Status;
            cargoEntity.ProductName= updateCargoDto.ProductName;
            cargoEntity.EmployeeId= updateCargoDto.EmployeeId;
            cargoEntity.Weight= updateCargoDto.Weight;

            try
            {
                _cargoRepository.Update(cargoEntity);
                return 1;
            }

            catch (Exception )
            {

                return -1;
            }


        }
    }
}
