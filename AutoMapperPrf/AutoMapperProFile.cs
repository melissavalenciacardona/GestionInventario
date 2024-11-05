using AutoMapper;
using LabSoft.Data;
using LabSoft.DTOs;

namespace LabSoft.AutoMapperPrf
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioRequestDTO, Usuario>(); //Saca los datos de UsuarioRequestDTO y los mapea a Usuario
            CreateMap<Usuario, UsuarioResponseDTO>(); //Saca los datos de Usuario y los mapea a UsuarioResponseDTO
            CreateMap<Direccion, DireccionResponseDTO>(); //Saca los datos de Direccion y los mapea a DireccionResponseDTO
            CreateMap<Preferencia, PreferenciaResponseDTO>(); //Saca los datos de Preferencia y los mapea a PreferenciaResponseDTO
            CreateMap<ProductoRequestDTO, Producto>(); //Saca los datos de PreferenciaRequestDTO y los mapea a Preferencia
            CreateMap<Producto, ProductoResponseDTO>(); //Saca los datos de Producto y los mapea a ProductoResponseDTO
            CreateMap<ProveedorRequestDTO, Proveedor>(); //Saca los datos de ProveedorRequestDTO y los mapea a Proveedor
            CreateMap<Proveedor, ProveedorResponseDTO>(); //Saca los datos de Proveedor y los mapea a ProveedorResponseDTO
            CreateMap<Movimiento, MovimientooResponseDTO>(); //Saca los datos de Movimiento y los mapea a MovimientoResponseDTO
        }
    }
}