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
    public ActionResult<int> AdicionarPessoa([FromBody] AdicionarPessoaViewModel pPessoa)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var xRetorno = _pessoaApplicationService.Adicionar(pPessoa);

        
        return xRetorno;
    }
    
}