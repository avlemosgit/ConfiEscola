using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ConfiEscola.Core.Interfaces;
using ConfiEscola.Core.Notifications;
using ConfiEscola.Domain.Commands;
using ConfiEscola.Domain.Interfaces.Data;
using ConfiEscola.Domain.Interfaces.Data.Repositories;
using ConfiEscola.Domain.Models;
using System.Reflection.Metadata.Ecma335;

namespace ConfiEscola.Domain.Commands
{
    public class AlunoCommandHandler : CommandHandler, IRequestHandler<AlunoCreateCommand>, IRequestHandler<AlunoUpdateCommand>, IRequestHandler<AlunoDeleteCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IHistoricoEscolarRepository _historicoEscolarRepository;


        public AlunoCommandHandler(IAlunoRepository alunoRepository, 
               IHistoricoEscolarRepository historicoEscolarRepository,
               IMediatorHandler bus,
               IUnitOfWork uow,
               INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        { 
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
            _alunoRepository = alunoRepository;
            _historicoEscolarRepository = historicoEscolarRepository;
        }

        public async Task<Unit> Handle(AlunoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                NotificationErros(request);
            else
            { 
                var alunoExistente = await _alunoRepository.GetByNome(request.Nome, request.SobreNome);
                var emailExistente = await _alunoRepository.GetByEmail(request.Email);
                if (alunoExistente.Count() > 0 || emailExistente.Count() > 0)
                    await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Registro já existente."));

                HistoricoEscolar historico = new HistoricoEscolar();
                historico.SetHitoricoEscolar(request.HistoricoEscolar.Id, request.HistoricoEscolar.Formato, request.HistoricoEscolar.Nome, request.HistoricoEscolar.Arquivo);
                
                Aluno aluno = new Aluno();
                aluno.setAluno(request.Id, request.Nome, request.SobreNome, request.Email, request.DataNascimento, request.EscolaridadeId, historico);
                _alunoRepository.Add(aluno);

                if (_notifications.HasNotifications()) await Commit(true);
                if (!_notifications.HasNotifications()) await Commit();
            }
            return Unit.Value;
        }
        public async Task<Unit> Handle(AlunoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                NotificationErros(request);
            else
            {
                var alunoExistente = await _alunoRepository.GetById(request.Id);

                if (alunoExistente == null)
                    await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Registro já existente."));

                
                alunoExistente.setAluno(request.Id, request.Nome, request.SobreNome, request.Email, request.DataNascimento, request.EscolaridadeId, request.HistoricoEscolar);
                _alunoRepository.Update(alunoExistente);

                if (_notifications.HasNotifications()) await Commit(true);
                if (!_notifications.HasNotifications()) await Commit();
            }
            return Unit.Value;
        }
        public async Task<Unit> Handle(AlunoDeleteCommand request, CancellationToken cancellationToken)
        { 
            if(!request.IsValid())
                NotificationErros(request);
            else
            {
                var alunoExistente = await _alunoRepository.GetById(request.Id);

                if (alunoExistente == null)
                    await _bus.RaiseEvent(new DomainNotification(request.MessageType, "Registro não encontrato."));

                HistoricoEscolar historicoEscolar = new HistoricoEscolar();
                historicoEscolar.Id = alunoExistente.HistoricoEscolarId;

                _historicoEscolarRepository.Remove(historicoEscolar);
                _alunoRepository.Remove(alunoExistente);

                if (_notifications.HasNotifications()) await Commit(true);
                if (!_notifications.HasNotifications()) await Commit();
            }
            return Unit.Value;
        }
    }
}
