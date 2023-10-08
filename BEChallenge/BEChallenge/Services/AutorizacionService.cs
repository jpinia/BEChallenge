using BEChallenge.Interfaces;
using BEChallenge.Models;
using DB;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BEChallenge.Services
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly BancoContext _context;
        private readonly IConfiguration _configuration;

        public AutorizacionService(BancoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerarToken(string PIN) {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, PIN));


            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credencialesToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;
        }

        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var tarjeta_encontrada = _context.Tarjetas.FirstOrDefault(x =>
            x.nroTarjeta == autorizacion.nroTarjeta &&
            x.PIN == autorizacion.PIN &&
            x.estaBloqueada == false
            );           

            if (tarjeta_encontrada == null) {

                var tarjeta_encontrada_pin_erroneo = _context.Tarjetas.FirstOrDefault(x =>
                x.nroTarjeta == autorizacion.nroTarjeta &&
                x.estaBloqueada == false
                );

                if (tarjeta_encontrada_pin_erroneo != null)
                {
                    if (tarjeta_encontrada_pin_erroneo.intentosFallidos < 4)
                        tarjeta_encontrada_pin_erroneo.intentosFallidos = tarjeta_encontrada_pin_erroneo.intentosFallidos + 1;

                    if (tarjeta_encontrada_pin_erroneo.intentosFallidos == 4)
                        tarjeta_encontrada_pin_erroneo.estaBloqueada = true;

                    _context.Tarjetas.Update(tarjeta_encontrada_pin_erroneo);
                    _context.SaveChanges();
                }
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(tarjeta_encontrada.PIN.ToString());

            return new AutorizacionResponse() { token= tokenCreado , resultado=true, msj="Ok"};
        }
    }
}
