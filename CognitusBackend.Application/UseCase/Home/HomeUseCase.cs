using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Domain.Exceptions;
using CognitusBackend.Domain.Repositories;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CognitusBackend.Application.UseCase.Home
{
    public class HomeUseCase
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IUserRepository _userRepository;

        public HomeUseCase(ISearchRepository searchRepository, IUserRepository userRepository)
        {
            _searchRepository = searchRepository;
            _userRepository = userRepository;
        }

        public async Task<ActionResult<HomeResponse>> executeHome(Guid Id)
        {

            var user = await _userRepository.getByIdAsync(Id);

            if (user == null)
            {
                throw new Exception("Error ao retornar suas pesquisas!");
            }

            var DataUserLastSearch = await _searchRepository.GetUserSearchAsync(Id);

            var listLastSearch = DataUserLastSearch.Select(s=>s.LastSearch).ToList();

            if (DataUserLastSearch == null)
            {
                return new HomeResponse(user.Name, "Você não tem pesquisas recentes", listLastSearch);
            }

            return new HomeResponse(user.Name, "Sucesso!" ,listLastSearch);
        }
    }

}