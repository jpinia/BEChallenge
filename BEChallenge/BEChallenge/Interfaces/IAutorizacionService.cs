using BEChallenge.Models;

namespace BEChallenge.Interfaces
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);
    }
}
