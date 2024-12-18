namespace colaboradorApi.Models;

public class Colaborador
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Setor { get; set; }
    public double? Salario { get; set; }
    public string? Cargo { get; set; }
    public string? Email { get; set; } 
    public int? Idade { get; set; }
    public string? Telefone { get; set; }
    public string? CPF { get; set; }
    public string? DataNascimento { get; set; }
    public string? Endereco { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Cep { get; set; }
    public bool? TransporteEmpresa { get; set; }
    public bool? Ativo { get; set; }
}

