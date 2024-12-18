using colaboradorApi.Models;
using colaboradorApi.Services.Interfaces;
using colaboradorApi.Infra.DataBase;
using Microsoft.EntityFrameworkCore;


namespace colaboradorApi.Services.Implementations;

public class ColaboradorService : IColaboradorService
{
    private readonly ConnectionContext _context;

    public ColaboradorService(ConnectionContext context)
    {
        _context = context;
    }

    // Service de trazer todos os colaboradores
    public async Task<IEnumerable<Colaborador>> GetColaboradorsAsync()
    {
        return await _context.Colaboradores.ToListAsync();
    }

    // Service de trazer um colaborador pelo id
    public async Task<Colaborador?> GetColaboradorAsync(int id)
    {
        return await _context.Colaboradores.FindAsync(id);
    }


    // Service de procurar um colaborador (pela letra ou nome)
    public async Task<List<Colaborador>> SearchColaboradoresAsync(string query)
    {
        query = query.Trim().ToLower();

        if (query.Length == 1)
        {
            return await _context.Colaboradores
                .Where(c => c.Nome.ToLower().StartsWith(query))
                .ToListAsync();
        }

        return await _context.Colaboradores
            .Where(c => c.Nome.ToLower() == query)
            .ToListAsync();
    }



    public async Task<List<Colaborador>> SearchIdadeColaboradores(int idade)
    {
        return await _context.Colaboradores.Where(c => c.Idade == idade).ToListAsync();
    }


    public async Task<List<Colaborador>> SerachIntervaloIdadeColaboradores(int idadeMin, int idadeMax)
    {
        return await _context.Colaboradores
            .Where(c => c.Idade >= idadeMin && c.Idade <= idadeMax)
            .ToListAsync();
    }



    public async Task<List<Colaborador>> SearchSetor(string setor)
    {
        return await _context.Colaboradores
            .Where(c => c.Setor == setor)
            .ToListAsync();
    }


    public async Task<List<Colaborador>> SearchSalarios(double salarioMin, double salarioMax)
    {
        return await _context.Colaboradores
            .Where(c => c.Salario >= salarioMin && c.Salario <= salarioMax)
            .ToListAsync();
    }


    public async Task<List<Colaborador>> SearchCargos(string query)
    {
        query = query.Trim().ToLower();

        if (query.Length == 1)
        {
            return await _context.Colaboradores
                .Where(c => c.Cargo.ToLower().StartsWith(query))
                .ToListAsync();
        }

        return await _context.Colaboradores
            .Where(c => c.Cargo.ToLower().StartsWith(query))
            .ToListAsync();
    }

    public async Task<List<Colaborador>> SearchBairro(string bairro)
    {
        bairro = bairro.Trim().ToLower();
        return await _context.Colaboradores.Where(c => c.Bairro.ToLower().StartsWith(bairro)).ToListAsync();
    }


    public async Task<List<Colaborador>> SearchCidade(string cidade)
    {
        cidade = cidade.Trim().ToLower();
        return await _context.Colaboradores
            .Where(c => c.Cidade
                .ToLower().StartsWith(cidade))
            .ToListAsync();
    }



    public async Task<List<Colaborador>> SearchEstado(string estado)
    {
        estado = estado.Trim().ToLower();
        return await _context.Colaboradores
            .Where(c => c.Estado.ToLower().StartsWith(estado))
            .ToListAsync();
    }


    public async Task<List<Colaborador>> SearchTransporte(bool transporte)
    {
        return await _context.Colaboradores.Where(c => c.TransporteEmpresa == transporte).ToListAsync();    
    }


    public async Task<List<Colaborador>> SearchAtivo(bool ativo)
    {
        return await _context.Colaboradores.Where(c => c.Ativo == ativo).ToListAsync();
    }




    public async Task<List<Colaborador>> SearchSetorCargo(string setor, string cargo)
    {
        setor = setor.Trim().ToLower();
        cargo = cargo.Trim().ToLower();

        return await _context.Colaboradores
            .Where(c => 
                EF.Functions.Like(c.Setor.ToLower(), $"{setor}%") &&
                EF.Functions.Like(c.Cargo.ToLower(), $"{cargo}%"))
            .ToListAsync();

    }


    public async Task<List<QuantidadePorSetorDto>> SearchQuantSetor(string setor)
    {
        
        setor = setor.Trim().ToLower();

        var resultado = await _context.Colaboradores
            .Where(c => c.Setor.ToLower().Contains(setor)) 
            .GroupBy(c => c.Setor)
            .Select(g => new QuantidadePorSetorDto
            {
                Setor = g.Key,
                QuantidadeColaboradores = g.Count()
            })
            .ToListAsync();

        return resultado;
    }



    public async Task<List<SalarioMedioPorSetorDto>> AvgSalarioSetor(string setor)
    {
        
        setor = setor.Trim().ToLower();

        var resultado = await _context.Colaboradores
            .Where(c => c.Setor.ToLower().Contains(setor)) 
            .GroupBy(c => c.Setor) 
            .Select(g => new SalarioMedioPorSetorDto
            {
                Setor = g.Key,
                SalarioMedio = g.Average(c => (c.Salario.HasValue ? c.Salario.Value : 0)) // Tratamento de valores nulos
            })
            .ToListAsync(); 

        return resultado;
    }


    public async Task<List<IdadeMediaPorSetorDto>> IdadeMediaSetor(string setor)
    {
        setor = setor.Trim().ToLower();

        var resultado = await _context.Colaboradores
            .Where(c => c.Setor.ToLower().Contains(setor)) 
            .GroupBy(c => c.Setor) 
            .Select(g => new IdadeMediaPorSetorDto
            {
                Setor = g.Key,
                IdadeMedia = g.Average(c => c.Idade ?? 0) // Ignora valores nulos e trata como 0
            })
            .ToListAsync();

        return resultado;
    }



















// Service de CRIAR um colaborador
    public async Task CreateColaboradorAsync(Colaborador colaborador)
    {
        await _context.Colaboradores.AddAsync(colaborador);
        await _context.SaveChangesAsync();
    }


    // Service de ATUALIZAR um colaborador
    public async Task UpdateColaboradorAsync(int id, Colaborador colaborador)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            return;
        }

        // atualiza os atributos do colaborador
        colaboradorExistente.Nome = colaborador.Nome;
        colaboradorExistente.Setor = colaborador.Nome;
        colaboradorExistente.Salario = colaborador.Salario;
        colaboradorExistente.Cargo = colaborador.Cargo;
        colaboradorExistente.Email = colaborador.Email;
        colaboradorExistente.Idade = colaborador.Idade;
        colaboradorExistente.Telefone = colaborador.Telefone;
        colaboradorExistente.CPF = colaborador.CPF;
        colaboradorExistente.DataNascimento = colaborador.DataNascimento;
        colaboradorExistente.Endereco = colaborador.Endereco;
        colaboradorExistente.Bairro = colaborador.Bairro;
        colaboradorExistente.Cidade = colaborador.Cidade;
        colaboradorExistente.Estado = colaborador.Estado;
        colaboradorExistente.Cep = colaborador.Cep;
        colaboradorExistente.TransporteEmpresa = colaborador.TransporteEmpresa;
        colaboradorExistente.Ativo = colaborador.Ativo;
    }


    public async Task UpdateNomeColaborador(int id, string nome)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador não encontrado.");
        }

        colaboradorExistente.Nome = nome;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateSetorColaborador(int id, string setor)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador não encontrado.");
        }

        colaboradorExistente.Setor = setor;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateSalarioColaborador(int id, double salario)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.Salario = salario;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateCargoColaborador(int id, string cargo)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.Cargo = cargo;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateEmailColaborador(int id, string email)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.Email = email;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIdadeColaborador(int id, int idade)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.Idade = idade;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTelefoneColaborador(int id, string telefone)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.Telefone = telefone;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateCpfColaborador(int id, string cpf)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.CPF = cpf;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDataNascimentoColaborador(int id, string dataNascimento)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.DataNascimento = dataNascimento;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEnderecoColaborador(int id, string endereco)
    {
        var colaboradorExistente = await _context.Colaboradores.FindAsync(id);
        if (colaboradorExistente == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaboradorExistente.Endereco = endereco;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateBairroColaborador(int id, string bairro)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaborador.Bairro = bairro;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateCidadeColaborador(int id, string cidade)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaborador.Cidade = cidade;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateEstadoColaborador(int id, string estado)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaborador.Estado = estado;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateCepColaborador(int id, string cep)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaborador.Cep = cep;
        await _context.SaveChangesAsync();
    }


    public async Task UpdateTransporteColaborador(int id, bool transporte)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaborador.TransporteEmpresa = transporte;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAtivoColaborador(int id, bool ativo)
    {
        var colaborador = await _context.Colaboradores.FindAsync(id);
        if (colaborador == null)
        {
            throw new KeyNotFoundException("Colaborador nao encontrado");
        }

        colaborador.Ativo = ativo;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteColaboradorAsync(int id)
    {
        var colaboradorToDelete = await _context.Colaboradores.FindAsync(id);
        if (colaboradorToDelete == null)
        {
            return;
        }

        _context.Colaboradores.Remove(colaboradorToDelete);
        await _context.SaveChangesAsync();
    }
}