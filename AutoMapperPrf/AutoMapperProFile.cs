using AutoMapper;
using LabSoft.Data;
using LabSoft.DTOs;

namespace LabSoft.AutoMapperPrf
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClienteRequestDTO, Cliente>(); //Saca los datos de ClienteRequestDTO y los mapea a Cliente
            CreateMap<Cliente, ClienteResponseDTO>(); //Saca los datos de Cliente y los mapea a ClienteResponseDTO
            CreateMap<Direccion, DireccionResponseDTO>(); //Saca los datos de Direccion y los mapea a DireccionResponseDTO
            CreateMap<Preferencia, PreferenciaResponseDTO>(); //Saca los datos de Preferencia y los mapea a PreferenciaResponseDTO
        }
    }
}