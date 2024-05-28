using BlazorApp1.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace BlazorApp1
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        Usuario usuarioAutenticado;
        public CustomAuthStateProvider()
        {
        }

        public void MarkUserAsAuthenticated(Usuario unUsuario)
        {
            usuarioAutenticado = unUsuario;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void MarkUserAsLoggedOut()
        {
            usuarioAutenticado = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = usuarioAutenticado == null
                ? new ClaimsIdentity()
                : new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioAutenticado.UserGuid.ToString()),
                    new Claim(ClaimTypes.Email, usuarioAutenticado.Email),
                    new Claim(ClaimTypes.Name, usuarioAutenticado.Nombre),
                    new Claim(ClaimTypes.Surname, usuarioAutenticado.Apellido),
                }, "apiauth_type");
            
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
