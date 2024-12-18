using colaboradorApi.Models;



namespace colaboradorApi.Services.Interfaces;

public interface IColaboradorService
{
    // Metodos de busca por todos colaboradores
    Task <IEnumerable<Colaborador>> GetColaboradorsAsync();
    
    // Busca pelo id do colaborador
    Task <Colaborador?> GetColaboradorAsync(int id);
    
    // Busca pela inicial ou nome do colaborador
    Task <List<Colaborador>> SearchColaboradoresAsync(string query);
    
    
    // Busca pela idade de colaborades
    Task <List<Colaborador>> SearchIdadeColaboradores (int idade);
    
    // Busca pelo intervalo de idade
    Task<List<Colaborador>> SerachIntervaloIdadeColaboradores (int idadeMin, int idadeMax);
    
    // Busca por Setor
    Task<List<Colaborador>> SearchSetor(string setor);
    
    // Busca por salario
    Task <List<Colaborador>> SearchSalarios(double salarioMin, double salarioMax);
    
    
    // Busca por Cargos
    Task<List<Colaborador>> SearchCargos(string query);
    
    
    // Busca pelo Bairro
    Task<List<Colaborador>> SearchBairro(string bairro);
    
    // Busca pela cidade
    Task <List<Colaborador>> SearchCidade(string cidade);
    
    // Busca pelo estado
    Task <List<Colaborador>> SearchEstado(string estado);
    
    
    // Busca pelo transporte
    Task<List<Colaborador>> SearchTransporte(bool transporte);
    
    
    // Busca pelo colaborador ativo ou nao
    Task<List<Colaborador>> SearchAtivo(bool ativo);
    
    
    // Busca de setor + cargo 
    Task <List<Colaborador>> SearchSetorCargo(string setor, string cargo);
    
    // Busca pela quant de colaboradores por setor
    Task<List<QuantidadePorSetorDto>> SearchQuantSetor(string setor);
    
    // Busca pela media salarial do setor
    Task <List<SalarioMedioPorSetorDto>> AvgSalarioSetor (string setor);

    // Busca pela idade media do setor
    Task<List<IdadeMediaPorSetorDto>> IdadeMediaSetor(string setor);
    
    
    
    
    
    // Metodo de criacao de um colaborador
    Task CreateColaboradorAsync(Colaborador colaborador);
    
    // Metodos de atualizacao completa do colaborador
    Task UpdateColaboradorAsync(int id, Colaborador colaborador);
    
    // Atualiza nome do colaborador
    Task UpdateNomeColaborador(int id, string nome);
    
    // Atualiza o setor do colaborador
    Task UpdateSetorColaborador(int id, string setor);
    
    // Atualiza o salario 
    Task UpdateSalarioColaborador(int id, double salario);
    
    // Att cargo
    Task UpdateCargoColaborador(int id, string cargo);
    
    // Att email
    Task UpdateEmailColaborador (int id, string email);
    
    // Att idade
    Task UpdateIdadeColaborador (int id, int idade);
    
    // Att tel
    Task UpdateTelefoneColaborador (int id, string telfone);
    
    // Att cpf
    Task UpdateCpfColaborador (int id, string cpf);
    
    // Att dn
    Task UpdateDataNascimentoColaborador (int id, string dataNascimento);
    
    // Att endereco
    Task UpdateEnderecoColaborador (int id, string endereco);
    
    //att bairro
    Task UpdateBairroColaborador (int id, string bairro);
    
    //att cidade
    Task UpdateCidadeColaborador (int id, string cidade);
    
    // att estado
    Task UpdateEstadoColaborador (int id, string estado);
    
    // att cep
    Task UpdateCepColaborador (int id, string cep);
    
    // att transporte (se utiliza rota ou nao)
    Task UpdateTransporteColaborador (int id, bool transporte);
    
    // att status (se esta empregado ou nao)
    Task UpdateAtivoColaborador (int id, bool ativo);   
    
    // Metodo de deletar um colaborador
    Task DeleteColaboradorAsync(int id);    
}