using System.IdentityModel.Tokens.Jwt;
using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Domain.Repositories;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CognitusBackend.Application.UseCase.Search
{
    public class AddSearchUseCase
    {
        private readonly ISearchRepository _searchRepository;

        public AddSearchUseCase(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<ActionResult<MessageResponse>> executeAddSearch(SearchRequest request)
        {
            var newDataSearch = new UserSearch
            {
                UserId = request.UserId,
                LastSearch = request.LastSearch

            };

            try
            {
                await _searchRepository.setLastSearch(newDataSearch);
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao salvar a sua ultima pesquisa!", ex);
            }

            return new MessageResponse("Nova Search adicionada!");
        }
    }
}
