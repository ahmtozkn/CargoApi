using Cargo.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Business.Services
{
  public interface ICargoService
    {
        bool AddCargo(AddCargoDto addCargoDto);

        List<ListCargoDto> GetCargoList();

        GetCargoDto GetCargo(int id);

        int DeleteCargo(int id);   

        int UpdateCargo(UpdateCargoDto updateCargoDto);


    }
}
