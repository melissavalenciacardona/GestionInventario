using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LabSoft.Data
{
    public class JwtToken
    {
        private readonly JwtConfig _jwtConfig;

        public JwtToken(IOptions<JwtConfig> jwtConfig){
            _jwtConfig = jwtConfig.Value;
        }

        // Metodo para generar el token
        public string GenerarToken(ApplicationUser user, List<string> userRoles)
        {
            //clase responsable de crear y escribir el token JWT.
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            
            //Se obtiene la clave secreta para la firma del token desde la configuración (_jwtConfig.Secret)
            // y se convierte a un arreglo de bytes utilizando Encoding.UTF8.GetBytes(). 
            //Esta clave se utilizará para firmar el token y garantizar su autenticidad.
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            try
            {
                /*
                    Aquí se define una lista de claims, que son las afirmaciones sobre el usuario que se incluirán en el token. 
                        Los claims son las partes del token que contienen los datos sobre el usuario, como su identidad, roles y otros metadatos.

                    Id: El identificador único del usuario.
                    Sub (Subject): Normalmente, es el "sujeto" del token. En este caso, se usa el correo electrónico del usuario.
                    Email: El correo electrónico del usuario, se usa como un claim adicional.
                    Jti (JWT ID): Un identificador único para el token. 
                        Se genera usando Guid.NewGuid() para asegurar que cada token tenga un identificador único.
                    Iat (Issued At): La fecha y hora en la que el token fue emitido. Se establece como la hora actual en formato UTC.
                */
                var authClaims = new List<Claim>
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                };

                /*
                    Se recorren los roles del usuario (obtenidos previamente de userRoles) y se agregan como claims adicionales del tipo ClaimTypes.Role.
                    Esto es importante porque los roles se utilizarán en el proceso de autorización 
                    para determinar si un usuario tiene permisos para acceder a ciertos recursos.
                */
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                /*
                    Aquí se define el descriptor del token, que especifica cómo se generará el token.
                        Este descriptor contiene la siguiente información:

                    Subject: Se establece el ClaimsIdentity con la lista de claims (authClaims). 
                        Este es el conjunto de declaraciones sobre el usuario que se incluirán en el token.
                    Expires: Define la fecha de expiración del token. En este caso, el token expirará una hora después de su emisión
                        (DateTime.UtcNow.AddHours(1)).
                    Issuer: El emisor del token. Se obtiene de la configuración (_jwtConfig.ValidIssuer). 
                        Es una cadena que representa quién emite el token (por ejemplo, una URL o nombre de la empresa/servicio).
                    Audience: El destinatario del token. Similar al emisor, se obtiene de la configuración (_jwtConfig.ValidAudience).
                        Puede ser el nombre de la API o servicio que consume el token.
                    SigningCredentials: Las credenciales de firma para asegurar el token. 
                        Se usa una clave simétrica (SymmetricSecurityKey) que se genera a partir de la clave secreta (key) y el algoritmo de firma HmacSha256.
                */
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(authClaims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _jwtConfig.ValidIssuer,
                    Audience = _jwtConfig.ValidAudience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                //Con el descriptor de seguridad creado (tokenDescriptor), se llama a CreateToken para generar un objeto JwtSecurityToken que contiene todos los datos 
                //(claims, expiración, emisor, etc.).
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                //Esta función convierte el objeto JwtSecurityToken en una cadena JWT, que es lo que realmente se envía al cliente
                return jwtTokenHandler.WriteToken(token);

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        internal string GenerarToken(Usuario usuario, List<string> userRoles)
        {
            throw new NotImplementedException();
        }
    }
}
