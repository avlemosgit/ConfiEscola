using AutoMapper;
using ConfiEscola.Application.ViewModels;
using ConfiEscola.Domain.Commands;
using ConfiEscola.Domain.Models;

namespace ConfiEscola.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AlunoViewModel, AlunoCreateCommand>();                
            CreateMap<AlunoViewModel, AlunoUpdateCommand>();
            CreateMap<RemoveAlunoViewModel, AlunoDeleteCommand>();
            CreateMap<HistoricoEscolarViewModel, HistoricoEscolar>();


        }
    }
}
