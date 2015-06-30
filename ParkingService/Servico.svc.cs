using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dados;

namespace ParkingService
{
    public class Servico : IServico
    {
        ParkingDBEntities ct = new ParkingDBEntities();

        private string SITUACAO_LIVRE
        {
            get { return eSituacaoVaga.Livre.ToString(); }
        }
        
        #region Fluxo Reservar Vaga

        public IEnumerable<dtoAndar> ListarAndares()
        {
            var lista = (from A in ct.Andar
                         select new dtoAndar
                         {
                             Id = A.Id,
                             Nome = A.Nome,
                             QtdVagas = (from B in A.Bloco from V in B.Vaga 
                                         select V).Count(),
                             QtdLive = (from B in A.Bloco from V in B.Vaga 
                                        where V.Situacao == SITUACAO_LIVRE
                                        select V).Count()
                         });

            return lista;
        }

        public IEnumerable<dtoBloco> ListarBlocos(int Id_Andar)
        {
            var lista = (from B in ct.Bloco
                         where B.Id_Andar == Id_Andar
                         select new dtoBloco
                         {
                             Id = B.Id,
                             Nome = B.Nome,
                             QtdVagas = B.Vaga.Count(),
                             QtdLive = (from V in B.Vaga
                                        where V.Situacao == SITUACAO_LIVRE
                                        select V).Count()
                         });

            return lista;
        }

        public IEnumerable<dtoVaga> ListarVagas(int Id_Bloco)
        {            
            var lista = (from V in ct.Vaga
                         where V.Id_Bloco == Id_Bloco
                         select new dtoVaga
                         {
                             Id = V.Id,
                             Nome = V.Nome,
                             Disponivel = (V.Situacao == SITUACAO_LIVRE)
                         });

            return lista;
        }

        public bool ReservarVaga(int Id_Vaga, int Id_Carro)
        {
            Vaga vaga = ConsultarVaga(Id_Vaga);

            vaga.Situacao = eSituacaoVaga.Reservada.ToString();
            vaga.Id_Carro = Id_Carro;
            vaga.HoraReserva = DateTime.Now;

            ct.SaveChanges();

            return true;
        }

        #endregion

        #region Fluxo Manter Vaga Reservada

        public dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fluxo Localizar Carro

        public dtoCaminho LocalizarCarro(int Id_QRCode, int Id_Carro)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fluxo Manter Carros

        public IEnumerable<dtoCarro> ListarCarros(string CPF)
        {
            Cliente cliente = ConsultarCliente(CPF);

            var ListaCarros = (from Ca in cliente.Carro
                               select new dtoCarro
                               {
                                   Id = Ca.Id,
                                   Marca = Ca.Marca,
                                   Placa = Ca.Placa
                               });
            
            return ListaCarros;
        }

        public IEnumerable<string> ListarMarcasCarro()
        {
            throw new NotImplementedException();
        }

        public bool CadastrarCarro(string CPF, dtoCarro novoCarro)
        {
            throw new NotImplementedException();
        }

        public bool AlterarCarro(dtoCarro novoCarro)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirCarro(int Id_Carro)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Métodos Internos

        private Cliente ConsultarCliente(string CPF)
        {
            CPF = Util.RetirarFormatacaoCPF(CPF);

            Cliente cliente = (from C in ct.Cliente where C.CPF == CPF select C).SingleOrDefault();

            if (cliente == null)
            {
                throw new exClienteNaoEncontrado(CPF);
            }

            return cliente;
        }

        private Vaga ConsultarVaga(int Id_Vaga)
        {
            Vaga vaga = (from V in ct.Vaga where V.Id == Id_Vaga select V).SingleOrDefault();

            if (vaga == null)
            {
                throw new exVagaNaoEncontrada(Id_Vaga);
            }

            return vaga;
        }

        #endregion

    }
}
