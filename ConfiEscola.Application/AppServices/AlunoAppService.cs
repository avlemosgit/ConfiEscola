using AutoMapper;
using ConfiEscola.Application.Interfaces;
using ConfiEscola.Application.ViewModels;
using ConfiEscola.Core.Interfaces;
using ConfiEscola.Domain.Commands;
using ConfiEscola.Domain.Interfaces.Data;
using ConfiEscola.Domain.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiEscola.Application.AppServices
{
    public class AlunoAppService : IAlunoAppService
    {

        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IEscolaridadeRepository _escolaridadeRepository;
        private readonly IAlunoRepository _repository;

        public AlunoAppService(IMapper mapper, IMediatorHandler bus, IAlunoRepository repository, IEscolaridadeRepository escolaridadeRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
            _escolaridadeRepository = escolaridadeRepository;
        }

        public async Task Create(AlunoViewModel model)
        {
            var command = _mapper.Map<AlunoCreateCommand>(model);
            await _bus.SendCommand(command);
        }

        public async Task Delete(int id)
        {
            var command = new AlunoDeleteCommand(id);            
            await _bus.SendCommand(command);
        }

        public async Task Update(AlunoViewModel model)
        {
            var command = _mapper.Map<AlunoUpdateCommand>(model);
            await _bus.SendCommand(command);

        }
        public async Task<IEnumerable<AlunoViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<AlunoViewModel>>(await _repository.Get());
        }
        public async Task<AlunoViewModel> GetById(int id)
        {
            return _mapper.Map<AlunoViewModel>(await _repository.GetById(id));
        }
        public async Task<IEnumerable<EscolaridadeViewModel>> GetEscolaridade()
        {
            return _mapper.Map<IEnumerable<EscolaridadeViewModel>>(await _escolaridadeRepository.Get());
        }
    }
}
