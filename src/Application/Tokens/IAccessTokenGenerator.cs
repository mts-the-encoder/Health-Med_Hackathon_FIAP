using Domain.Entities;

namespace Application.Tokens;

public interface IAccessTokenGenerator
{
	string Generate(Usuario user);
}