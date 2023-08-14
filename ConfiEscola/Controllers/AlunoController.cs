using MediatR;
using Microsoft.AspNetCore.Mvc;
using ConfiEscola.Application.Interfaces;
using ConfiEscola.Application.ViewModels;
using ConfiEscola.Core.Interfaces;
using ConfiEscola.Core.Notifications;
using ConfiEscola.Web.Controllers;

namespace ConfiEscola.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AlunoController : ApiController
    {
        private readonly IAlunoAppService _appService;
    
        public AlunoController(IAlunoAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoViewModel postViewModel)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(postViewModel);
                }
                await _appService.Create(postViewModel);
                return Response();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.InnerException.Message);
                return HandleException(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AlunoViewModel postViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(postViewModel);
                }
                await _appService.Update(postViewModel);
                return Response();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return HandleException(ex);
            }
        }
        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response();
                }

                IEnumerable<AlunoViewModel> response = await _appService.Get();

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response();
                }

                AlunoViewModel response = await _appService.GetById(id);

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet]
        [Route("GetEscolaridade")]
        public async Task<IActionResult> GetEscolaridade()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response();
                }

                IEnumerable<EscolaridadeViewModel> response = await _appService.GetEscolaridade();

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{alunoId:int}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(alunoId);
                }
                await _appService.Delete(alunoId);
                return Response();
            }
            catch (Exception ex) 
            {
                return HandleException(ex);
            }
        }


    }
}
