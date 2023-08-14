using ConfiEscola.Application.AppServices;
using ConfiEscola.Application.Interfaces;
using ConfiEscola.Core.Interfaces;
using ConfiEscola.Core.Notifications;
using ConfiEscola.Domain.Commands;
using ConfiEscola.Domain.Interfaces.Data;
using ConfiEscola.Domain.Interfaces.Data.Repositories;
using ConfiEscola.Domain.Models;
using ConfiEscola.Infra.Bus;
using ConfiEscola.Infra.Data.Configuration;
using ConfiEscola.Infra.Data.Context;
using ConfiEscola.Infra.Data.EventSourcing;
using ConfiEscola.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConfiEscola.Infa.IoC
{
    public class NativeInjector
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            // Domain - Commands
            //services.AddScoped<IRequestHandler<UsuarioCreateCommand, Unit>, UsuarioCommandHandler>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStore, EventStore>();
            services.AddDbContext<ConfiEscolaContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IRequestHandler<AlunoCreateCommand, Unit>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<AlunoUpdateCommand, Unit>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<AlunoDeleteCommand, Unit>, AlunoCommandHandler>();

            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IHistoricoEscolarRepository, HistoricoEscolarRepository>();
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
        }
    }
}

