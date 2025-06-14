using Application.Interfaces;
using Application.ViewModels.PessoaViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class PessoaController : ControllerBase
{
    
    private readonly IPessoaApplicationService _pessoaApplicationService;
    private readonly IMapper _mapper;

    public PessoaController(IPessoaApplicationService pessoaApplicationService, IMapper mapper)
    {
        _pessoaApplicationService = pessoaApplicationService;
        _mapper = mapper;
    }
    [Route("AdicionarPessoa")]
    [HttpPost]
    public ActionResult<int> AdicionarPessoa(AdicionarPessoaViewModel pPessoa)
    {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var xRetorno = _pessoaApplicationService.Adicionar(pPessoa);

                return xRetorno;
            }
            catch (Exception e)
            {
                return ValidationProblem(
                    detail: e.Message
                    , statusCode: StatusCodes.Status401Unauthorized
                    , title: nameof(AdicionarPessoa)
                    , modelStateDictionary: ModelState
                );
            }
    }
    
}