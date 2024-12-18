using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using colaboradorApi.Models;
using colaboradorApi.Services.Interfaces;

namespace colaboradorApi.Controllers;


[ApiController]
[Route("api/[controller]")]


public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _colaboradorService;

    public ColaboradorController(IColaboradorService colaboradorService)
    {
        _colaboradorService = colaboradorService;
    }


    // Get
    [HttpGet]
    public async Task<ActionResult> GetAllColaboradores()
    {
        var colaboradores = await _colaboradorService.GetColaboradorsAsync();
        return Ok(colaboradores);
    }


    // Get id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetColaboradorById(int id)
    {
        var colaborador = await _colaboradorService.GetColaboradorAsync(id);
        if (colaborador == null)
        {
            return NotFound("Nenhum Colaborador foi encontrado");
        }

        return Ok(colaborador);
    }


    [HttpGet("search/nome")]
    public async Task<IActionResult> SearchColaboradores([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("A consulta não pode estar vazia.");

        var colaboradores = await _colaboradorService.SearchColaboradoresAsync(query);
        if (colaboradores == null || !colaboradores.Any())
            return NotFound("Nenhum colaborador encontrado para a consulta.");

        return Ok(colaboradores);
    }


    [HttpGet("search/idade")]
    public async Task<IActionResult> SearchIdadeColaboradores([FromQuery] int idade)
    {
        var colaboradores = await _colaboradorService.SearchIdadeColaboradores(idade);
        if (colaboradores == null || !colaboradores.Any())
            return NotFound("Nenhum colaborador encontrado para a consulta.");

        return Ok(colaboradores);

    }


    [HttpGet("search/idades")]
    public async Task<IActionResult> SeachIntervaloIdadesColaboradores([FromQuery] int idadeMin, int idadeMax)
    {
        var colaboradores = await _colaboradorService.SerachIntervaloIdadeColaboradores(idadeMin, idadeMax);
        if (colaboradores == null || !colaboradores.Any())
            return NotFound("Nenhum colaborador encontrado no intervalo de idades para a consulta.");

        return Ok(colaboradores);
    }


    [HttpGet("search/setor")]
    public async Task<IActionResult> SeachSetor([FromQuery] string setor)
    {
        var colaboradoresSetor = await _colaboradorService.SearchSetor(setor);
        if (colaboradoresSetor == null || !colaboradoresSetor.Any())
        {
            return NotFound("Nenhum setor encontrado para a consulta.");
        }

        return Ok(colaboradoresSetor);
    }



    [HttpGet("search/salarios")]
    public async Task<IActionResult> SeachSalarios([FromQuery] double salarioMin, double salarioMax)
    {
        var colaboradoresSalarios = await _colaboradorService.SearchSalarios(salarioMin, salarioMax);
        if (colaboradoresSalarios == null || !colaboradoresSalarios.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }

        return Ok(colaboradoresSalarios);
    }





    [HttpGet("search/cargos")]
    public async Task<IActionResult> SeachCargos([FromQuery] string query)
    {
        var colaboradores = await _colaboradorService.SearchCargos(query);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }
        
        return Ok(colaboradores);  
    }



    [HttpGet("search/bairro")]
    public async Task<IActionResult> SeachBairro([FromQuery] string bairro)
    {
        var colaboradores = await _colaboradorService.SearchBairro(bairro);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }
        
        return Ok(colaboradores);  
    }



    [HttpGet("search/cidade")]
    public async Task<IActionResult> SearchCidade([FromQuery] string cidade)
    {
        var colaboradores = await _colaboradorService.SearchCidade(cidade);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }
        
        return Ok(colaboradores);  
    }


    [HttpGet("search/estado")]
    public async Task<IActionResult> SearchEstado([FromQuery] string estado)
    {
        var colaboradores = await _colaboradorService.SearchEstado(estado);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }
        return Ok(colaboradores);  
    }


    [HttpGet("search/transporte")]
    public async Task<IActionResult> SeachTransporte([FromQuery] bool transporte)
    {
        var colaboradores = await _colaboradorService.SearchTransporte(transporte);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }
        return Ok(colaboradores);  

    }


    [HttpGet("search/ativo")]
    public async Task<IActionResult> SearchAtivo([FromQuery] bool ativo)
    {
        var colaboradores = await _colaboradorService.SearchAtivo(ativo);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado para a consulta.");
        }
        return Ok(colaboradores);  
    }



    [HttpGet("search/setor-cargo")]
    public async Task<IActionResult> SearchSetorCargo([FromQuery] string setor, string cargo)
    {
        var colaboradores = await _colaboradorService.SearchSetorCargo(setor, cargo);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado pela consulta");
        }

        return Ok(colaboradores);
    }


    [HttpGet("quantidade-por-setor/{setor}")]
    public async Task<IActionResult> GetQuantidadePorSetor(string setor)
    {
        var colaboradores = await _colaboradorService.SearchQuantSetor(setor);
        if (colaboradores == null || !colaboradores.Any())
        {
            return NotFound("Nenhum colaborador encontrado no setor");
        } 
        return Ok(colaboradores);
    }


    [HttpGet("salario-medio-por-setor/{setor}")]
    public async Task<IActionResult> AvgSalarioSetor(string setor)
    {
        var resultado = await _colaboradorService.AvgSalarioSetor(setor);
        if (resultado == null || !resultado.Any())
        {
            return NotFound("Nenhum colaborador encontrado no setor");
        }
        return Ok(resultado);
    }


    [HttpGet("idade-media-por-setor/{setor}")]
    public async Task<IActionResult> IdadeMediaSetor(string setor)
    {
        var resultado = await _colaboradorService.IdadeMediaSetor(setor);
        if (resultado == null || !resultado.Any())
        {
            return NotFound();
        }
        return Ok(resultado);
    }
    
    
    
    
    

    // Post
    [HttpPost]
    public async Task<IActionResult> PostColaborador(Colaborador colaborador)
    {
        await _colaboradorService.CreateColaboradorAsync(colaborador);
        return CreatedAtAction(nameof(GetColaboradorById), new { id = colaborador.Id }, colaborador);
    }


    // Put
    [HttpPut("{id}")]
    public async Task<IActionResult> PutColaborador(int id, Colaborador colaborador)
    {
        if (id != colaborador.Id)
        {
            return BadRequest("Id nao corresponde com o id da url");
        }

        try
        {
            await _colaboradorService.UpdateColaboradorAsync(id, colaborador);
            return NoContent();

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    
    // Put nome
    [HttpPut("atualiza-nome/{id}/{nome}")]
    public async Task<IActionResult> PutNomeColaborador(int id, string nome)
    {
        try
        {
            await _colaboradorService.UpdateNomeColaborador(id, nome);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
    
    
    // Put setor
    [HttpPut("atualiza-setor/{id}/{setor}")]
    public async Task<IActionResult> PutSetorColaborador(int id, string setor)
    {
        await _colaboradorService.UpdateSetorColaborador(id, setor);
        return NoContent();
    }

    
    // Put salario
    [HttpPut("atualiza-salario/{id}/{salario}")]
    public async Task<IActionResult> PutSalarioColaborador(int id, double salario)
    {
        await _colaboradorService.UpdateSalarioColaborador(id, salario);
        return NoContent();
    }

    
    // Put cargo
    [HttpPut("atualiza-cargo/{id}/{cargo}")]
    public async Task<IActionResult> PutCargoColaborador(int id, string cargo)
    {
        await _colaboradorService.UpdateCargoColaborador(id, cargo);
        return NoContent();
    }
    
    
    // Put email
    [HttpPut("atualiza-email/{id}/{email}")]
    public async Task <IActionResult> PutEmailColaborador(int id, string email)
    {
        await _colaboradorService.UpdateEmailColaborador(id, email);
        return NoContent();
    }
    
    
    // Put idade
    [HttpPut("atualiza-idade/{id}/{idade}")]
    public async Task<IActionResult> PutIdadeColaborador(int id, int idade)
    {
        await _colaboradorService.UpdateIdadeColaborador(id, idade);
        return NoContent();
    }

    
    // Put telefone
    [HttpPut("atualiza-telefone/{id}/{telefone}")]
    public async Task<IActionResult> PutTelefoneColaborador(int id, string telefone)
    {
        
        telefone = FormatTelefone(telefone);

        
        await _colaboradorService.UpdateTelefoneColaborador(id, telefone);
        return NoContent();
    }

    
    // Put Cpf
    [HttpPut("atualiza-cpf/{id}/{cpf}")]
    public async Task<IActionResult> PutCpfColaborador(int id, string cpf)
    {

        cpf = FormatCpf(cpf);
        
        await _colaboradorService.UpdateCpfColaborador(id, cpf);
        return NoContent();
    }

    
    // Put DataNascimento
    [HttpPut("atualiza-dataNascimento/{id}/{dataNascimento}")]
    public async Task<IActionResult> PutDataNascimentoColaborador(int id, string dataNascimento)
    {
        var formattedDate = DateTime.ParseExact(dataNascimento, "ddMMyyyy", CultureInfo.InvariantCulture);
        var formattedDateString = formattedDate.ToString("dd/MM/yyyy");

        await _colaboradorService.UpdateDataNascimentoColaborador(id, formattedDateString);
        return NoContent();
    }
    
    
    // Put Endereco
    [HttpPut("atualiza-endereco/{id}/{endereco}")]
    public async Task<IActionResult> PutEnderecoColaborador(int id, string endereco)
    {
        await _colaboradorService.UpdateEnderecoColaborador(id, endereco);
        return NoContent(); 
    }
    
    
    // Put Bairro
    [HttpPut("atualiza-bairro/{id}/{bairro}")]
    public async Task<IActionResult> PutBairroColaborador(int id, string bairro)
    {
        await _colaboradorService.UpdateBairroColaborador(id, bairro);
        return NoContent();
    }

    
    // Put Cidade
    [HttpPut("atualiza-cidade/{id}/{cidade}")]
    public async Task<IActionResult> PutCidadeColaborador(int id, string cidade)
    {
        await _colaboradorService.UpdateCidadeColaborador(id, cidade);
        return NoContent();
    }

    
    
    // Put Estado
    [HttpPut("atualiza-estado/{id}/{estado}")]
    public async Task<IActionResult> PutEstadoColaborador(int id, string estado)
    {
        await _colaboradorService.UpdateEstadoColaborador(id, estado);
        return NoContent();
    }
    
    
    // Put Cep
    [HttpPut("atualiza-cep/{id}/{cep}")]
    public async Task<IActionResult> PutCepColaborador(int id, string cep)
    {

        cep = FormatCep(cep);
        await _colaboradorService.UpdateCepColaborador(id, cep);
        return NoContent();
    }
    
    
    // Put Transporte
    [HttpPut("atualiza-transporte/{id}/{transporte}")]
    public async Task<IActionResult> PutTransporteColaborador(int id, bool transporte)
    {
        await _colaboradorService.UpdateTransporteColaborador(id, transporte);
        return NoContent();
    }
    
    
    // Put Ativo/Desativo
    [HttpPut("atualiza-ativo/{id}/{ativo}")]
    public async Task<IActionResult> PutAtivoColaborador (int id, bool ativo)
    {
        await _colaboradorService.UpdateAtivoColaborador(id, ativo);
        return NoContent();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // Delete id 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColaborador(int id)
    {
        await _colaboradorService.DeleteColaboradorAsync(id);
        return NoContent(); 
    }
    
    
    
    // Formata o telefone
    private string FormatTelefone(string telefone)
    {
        telefone = new string(telefone.Where(char.IsDigit).ToArray());

        if (telefone.Length == 10)
        {
            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 4)}-{telefone.Substring(6, 4)}";
        }
        else if (telefone.Length == 11)
        {
            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
        }

        return telefone;
    }
    
    
    // Formata o cpf
    private string FormatCpf(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length == 11)
        {
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        return cpf;
    }


    // Formata o Cep
    private string FormatCep(string cep)
    {
        cep = new string (cep.Where(char.IsDigit).ToArray());
        if (cep.Length == 8)
        {
            return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
        }

        return cep;
    }
    
    
    
   
}


