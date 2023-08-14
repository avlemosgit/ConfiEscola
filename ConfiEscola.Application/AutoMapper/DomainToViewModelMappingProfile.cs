using AutoMapper;
using ConfiEscola.Application.ViewModels;
using ConfiEscola.Domain.Models;

namespace ConfiEscola.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() 
        {
            CreateMap<Aluno, AlunoViewModel>();                
            CreateMap<HistoricoEscolar, HistoricoEscolarViewModel>();
            CreateMap<Escolaridade, EscolaridadeViewModel>();
        }
    }
}
