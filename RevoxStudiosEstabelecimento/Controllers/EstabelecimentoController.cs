using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using RevoxStudios.Databases;
using RevoxStudios.Domain.Databases;
using RevoxStudios.Infra;
using RevoxStudios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoxStudiosEstabelecimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly Conexão _conexao;
        private IConfiguration _config;
        public EstabelecimentoController(Conexão conexao, IConfiguration config)
        {
            _conexao = conexao;
            _config = config;
        }

        [HttpPost("CadastarEstabelecimento")]
        /*[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]*/

        public async Task<ActionResult<string>> CadastarEstabelecimento(EstabelecimentoClasse dados)
        {
            var mensagem = "";
            try
            {
                if (string.IsNullOrWhiteSpace(dados.nomeEstab) || string.IsNullOrWhiteSpace(dados.telefoneEstab)
                    || string.IsNullOrWhiteSpace(dados.endereçoEstab) || string.IsNullOrWhiteSpace(dados.bairroEstab)
                    || string.IsNullOrWhiteSpace(dados.cepEstab) || string.IsNullOrWhiteSpace(dados.numeroEstab)
                    || string.IsNullOrWhiteSpace(dados.donoEstab) || string.IsNullOrWhiteSpace(dados.cpfDono)
                    || string.IsNullOrWhiteSpace(dados.dtNascimento.ToString()) || string.IsNullOrWhiteSpace(dados.telefoneDono)
                    || string.IsNullOrWhiteSpace(dados.emailDono) || string.IsNullOrWhiteSpace(dados.senhaEstab))
                {
                    mensagem = "Preencha todos os campos.";
                }
                else
                {
                    var validação = _conexao.Controle_De_Acesso.FirstOrDefault(d => d.Login.Equals(dados.emailDono));
                    if (validação == null)
                    {
                        //var teste = _conexao.Clientes.FirstOrDefault();
                        var entidade = new Estabelecimentos();
                        entidade.nomeEstab = dados.nomeEstab;
                        entidade.cnpjEstab = dados.cnpjEstab;
                        entidade.telefoneEstab = dados.telefoneEstab;
                        entidade.endereçoEstab = dados.endereçoEstab;
                        entidade.bairroEstab = dados.bairroEstab;
                        entidade.cepEstab = dados.cepEstab;
                        entidade.numeroEstab = dados.numeroEstab;
                        entidade.donoEstab = dados.donoEstab;
                        entidade.cpfDono = dados.cpfDono;
                        entidade.dtNascimento = dados.dtNascimento;
                        entidade.telefoneDono = dados.telefoneDono;
                        entidade.emailDono = dados.emailDono;
                        entidade.senhaEstab = dados.senhaEstab;
                        await _conexao.Estabelecimentos.AddAsync(entidade);
                        await _conexao.SaveChangesAsync();

                        var controleAcesso = new Controle_de_Acesso();
                        controleAcesso.Login = dados.emailDono;
                        controleAcesso.Senha = dados.senhaEstab;
                        controleAcesso.idStatus = 2;
                        await _conexao.Controle_De_Acesso.AddAsync(controleAcesso);
                        await _conexao.SaveChangesAsync();


                        mensagem = "Estabelecimento cadastrado com sucesso.";
                    }
                    else
                    {
                        mensagem = "Email já cadastrado";
                    }
                }
            }
            catch (Exception e)
            {
                mensagem = "Erro ao cadastrar.";
            }



            return mensagem;
        }

        [HttpDelete("DeletarEstabelecimento")]
        public async Task<ActionResult<string>> DeletarEstabelecimento(int idEstab)
        {
            var mensagem = "";
            var estabelecimentos = new Estabelecimentos();
            try
            {
                estabelecimentos = _conexao.Estabelecimentos.FirstOrDefault(d => d.idEstab.Equals(idEstab));
                if (estabelecimentos == null)
                {
                    mensagem = "Estabelecimento não encontrado.";
                }
                else
                {
                    _conexao.Estabelecimentos.Remove(estabelecimentos);
                    _conexao.SaveChanges();
                    mensagem = "Removido com sucesso.";
                }

            }

            catch (Exception e)
            {
                return "Erro ao remover.";
            }

            return mensagem;
        }

        [HttpPut("EditarEstabelecimento")]
        public async Task<ActionResult<string>> EditarEstabelecimento(EstabelecimentoClasse dados)
        {
            var mensagem = "";
            var estabelecimento = new Estabelecimentos();
            estabelecimento = _conexao.Estabelecimentos.FirstOrDefault(d => d.idEstab.Equals(dados.idEstab));
            try

            {
                if (string.IsNullOrWhiteSpace(dados.nomeEstab) || string.IsNullOrWhiteSpace(dados.telefoneEstab)
                    || string.IsNullOrWhiteSpace(dados.endereçoEstab) || string.IsNullOrWhiteSpace(dados.bairroEstab)
                    || string.IsNullOrWhiteSpace(dados.cepEstab) || string.IsNullOrWhiteSpace(dados.numeroEstab)
                    || string.IsNullOrWhiteSpace(dados.donoEstab) || string.IsNullOrWhiteSpace(dados.cpfDono)
                    || string.IsNullOrWhiteSpace(dados.dtNascimento.ToString()) || string.IsNullOrWhiteSpace(dados.telefoneDono)
                    || string.IsNullOrWhiteSpace(dados.senhaEstab) || string.IsNullOrWhiteSpace(dados.cnpjEstab))
                {
                    mensagem = "Preencha todos os campos.";
                }
                else
                {
                    estabelecimento.nomeEstab = dados.nomeEstab;
                    estabelecimento.telefoneEstab = dados.telefoneEstab;
                    estabelecimento.endereçoEstab = dados.endereçoEstab;
                    estabelecimento.bairroEstab = dados.bairroEstab;
                    estabelecimento.cepEstab = dados.cepEstab;
                    estabelecimento.numeroEstab = dados.numeroEstab;
                    estabelecimento.donoEstab = dados.donoEstab;
                    estabelecimento.cpfDono = dados.cpfDono;
                    estabelecimento.dtNascimento = dados.dtNascimento;
                    estabelecimento.telefoneDono = dados.telefoneDono;
                    //estabelecimento.emailDono = dados.emailDono;
                    estabelecimento.senhaEstab = dados.senhaEstab;
                    estabelecimento.cnpjEstab = dados.cnpjEstab;

                    _conexao.Entry(estabelecimento).State = EntityState.Modified;
                    var alterarsenha = _conexao.Controle_De_Acesso.FirstOrDefault(d => d.Login.Equals(estabelecimento.emailDono));
                    alterarsenha.Senha = dados.senhaEstab;

                    _conexao.Entry(alterarsenha).State = EntityState.Modified;
                    //await _conexao.Controle_De_Acesso.AddAsync(alterarsenha);
                    await _conexao.SaveChangesAsync();

                    mensagem = "Estabelecimento editado com sucesso.";
                }
            }
            catch (Exception e)
            {
                mensagem = "Erro ao editar.";
            }


            return mensagem;
        }

        [HttpGet("ListarEstabelecimento")]
        public async Task<ActionResult<List<Estabelecimentos>>> ListarEstabelecimento()
        {
            var lista = _conexao.Estabelecimentos.ToList();

            return lista;
        }

        [HttpGet("ListarEstabelecimentoParametro")]
        public async Task<ActionResult<Estabelecimentos>> ListarEstabelecimentoParametro(int idEstab)
        {
            var estabelecimento = _conexao.Estabelecimentos.FirstOrDefault(d => d.idEstab.Equals(idEstab));

            return estabelecimento;
        }

        [HttpPost("CadastrarInfoExtraEstab")]
        public async Task<ActionResult<string>> CadastrarInfoExtraEstab([FromForm] EstabelecimentoClasse dados)
        {
            var mensagem = "";
            var entidadeNewInfo = new Estabelecimentos();
            try
            {
                entidadeNewInfo = _conexao.Estabelecimentos.FirstOrDefault(d => d.idEstab.Equals(dados.idEstab));

                var dataString = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                var nomeArquivoFotoPerfil = string.Format("{0}-{1}", dataString, (dados.fotoPerfil.FileName).ToLowerInvariant());
                var nomeArquivoBanner = string.Format("{0}-{1}", dataString, (dados.banner.FileName).ToLowerInvariant());
                var CaminhoPasta = Convert.ToString(_config.GetSection("Caminho").GetValue(typeof(string), "LocalEstabelecimento"));
                var caminhoArquivoFotoPerfil = string.Format(@"{0}{1}", CaminhoPasta, nomeArquivoFotoPerfil);
                var caminhoArquivoBanner = string.Format(@"{0}{1}", CaminhoPasta, nomeArquivoBanner);

                using (var stream = System.IO.File.Create(caminhoArquivoFotoPerfil))
                {
                    await dados.fotoPerfil.CopyToAsync(stream);
                }

                using (var stream = System.IO.File.Create(caminhoArquivoBanner))
                {
                    await dados.banner.CopyToAsync(stream);
                }


                entidadeNewInfo.fotoPerfil = caminhoArquivoFotoPerfil;
                entidadeNewInfo.banner = caminhoArquivoBanner;

                entidadeNewInfo.descrição = dados.descrição;
                entidadeNewInfo.telefoneEstab2 = dados.telefoneEstab2;
                entidadeNewInfo.whatsapp = dados.whatsapp;
                entidadeNewInfo.facebook = dados.facebook;
                entidadeNewInfo.instagram = dados.instagram;

                _conexao.Entry(entidadeNewInfo).State = EntityState.Modified;
                await _conexao.SaveChangesAsync();

                mensagem = "Informações adicionadas com sucesso.";
            }
            catch (Exception e)
            {
                mensagem = "Erro ao cadastrar informações adicionais.";
            }

            return mensagem;
        }

        [HttpPost("CadastrarServiços")]
        public async Task<ActionResult<string>> CadastrarServiços(ServiçosClasse dados)
        {
            var mensagem = "";
            try
            {
                var serviçoCadastrado = new Serviços();

                serviçoCadastrado.idEstab = dados.idEstab;
                serviçoCadastrado.nomeEstab = dados.nomeEstab;

                serviçoCadastrado.Serviço = dados.Serviço;
                serviçoCadastrado.Preço = dados.Preço;

                await _conexao.Serviços.AddAsync(serviçoCadastrado);
                await _conexao.SaveChangesAsync();

                mensagem = "Serviço cadastrado com sucesso.";

            }
            catch (Exception e)
            {
                mensagem = "Erro ao cadastrar.";
            }
            return mensagem;
        }

        [HttpGet("ListarServiços")]
        public async Task<ActionResult<List<Serviços>>> ListarServiços()
        {
            var lista = _conexao.Serviços.ToList();

            return lista;
        }

        [HttpGet("ListarServiçosParametro")]
        public async Task<ActionResult<Serviços>> ListarServiçosParametro(int idServiço)
        {
            var cliente = _conexao.Serviços.FirstOrDefault(d => d.idServiço.Equals(idServiço));

            return cliente;
        }

        [HttpPut("EditarServiços")]
        public async Task<ActionResult<string>> EditarServiços(ServiçosClasse dados)
        {
            var mensagem = "";
            var serviçoEditado = new Serviços();

            serviçoEditado = _conexao.Serviços.FirstOrDefault(d => d.idServiço.Equals(dados.idServiço));
            try
            {
                serviçoEditado.Serviço = dados.Serviço;
                serviçoEditado.Preço = dados.Preço;

                _conexao.Entry(serviçoEditado).State = EntityState.Modified;
                await _conexao.SaveChangesAsync();

                mensagem = "Serviço editado com sucesso.";

            }
            catch (Exception e)
            {
                mensagem = "Erro ao editar.";
            }

            return mensagem;
        }

        [HttpDelete("DeletarServiços")]
        public async Task<ActionResult<string>> DeletarServiços(int idServiço)
        {
            var mensagem = "";
            var serviço = new Serviços();
            try
            {
                serviço = _conexao.Serviços.FirstOrDefault(d => d.idServiço.Equals(idServiço));
                if (serviço == null)
                {
                    mensagem = "Serviço não encontrado.";
                }
                else
                {
                    _conexao.Serviços.Remove(serviço);
                    _conexao.SaveChanges();
                    mensagem = "Removido com sucesso.";
                }

            }

            catch (Exception e)
            {
                return new JsonResult(false);
            }

            return mensagem;
        }

        [HttpPost("CadastrarAgenda")]
        public async Task<ActionResult<string>> CadastrarAgenda(AgendaClasse dadosAgenda)
        {
            var mensagem = "";
            try
            {
                var valida = _conexao.Agenda.FirstOrDefault(d => d.horário.Equals(dadosAgenda.horário));
                if (valida == null)
                {
                    var agenda = new Agenda();

                    agenda.horário = dadosAgenda.horário;
                    agenda.idServiço = dadosAgenda.idServiço;
                    agenda.idEstab = dadosAgenda.idEstab;
                    agenda.nomeCliente = dadosAgenda.nomeCliente;
                    agenda.idCliente = dadosAgenda.idCliente;
                    agenda.nomeEstab = dadosAgenda.nomeEstab;

                    await _conexao.Agenda.AddAsync(agenda);
                    await _conexao.SaveChangesAsync();

                    mensagem = "Agenda cadastrada com sucesso.";
                }
                else
                {
                    mensagem = "Horário já reservado.";
                }
            }
            catch (Exception e)
            {
                mensagem = "Erro ao cadastrar.";
            }
            return mensagem;
        }

        [HttpGet("ListarAgenda")]
        public async Task<ActionResult<List<Agenda>>> ListarAgenda()
        {
            var lista = _conexao.Agenda.ToList();

            return lista;
        }

        [HttpGet("ListarAgendaParametro")]
        public async Task<ActionResult<Agenda>> ListarAgendaParametro(int idAgenda)
        {
            var agenda = _conexao.Agenda.FirstOrDefault(d => d.idServiço.Equals(idAgenda));

            return agenda;
        }

        [HttpDelete("DeletarAgenda")]
        public async Task<ActionResult<BaseRetorno>> DeletarAgenda(int idAgenda)
        {         
            var retorno = new BaseRetorno();
            var agendaDelete = new Agenda();
            try
            {
                agendaDelete = _conexao.Agenda.FirstOrDefault(d => d.idAgenda.Equals(idAgenda));
                if (agendaDelete == null)
                {
                    retorno.mensagem = "Agenda não encontrada.";
                    retorno.sucesso = false;
                }
                else
                {
                    _conexao.Agenda.Remove(agendaDelete);
                    _conexao.SaveChanges();
                    retorno.mensagem = "Removido com sucesso.";
                    retorno.sucesso = true;
                }

            }

            catch (Exception e)
            {
                retorno.mensagem = "Erro ao remover.";
                retorno.sucesso = false;
            }

            return retorno;
        }

    }
}
