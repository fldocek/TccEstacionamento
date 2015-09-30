using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dados;

namespace ParkingService
{
    public class MobileService : IMobileService
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
                             QtdVagas = (from B in A.Bloco
                                         from V in B.Vaga
                                         select V).Count(),
                             QtdLivre = (from B in A.Bloco
                                        from V in B.Vaga
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
                             QtdLivre = (from V in B.Vaga
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
                             Deficiente = V.Deficiente,
                             Disponivel = (V.Bloqueada == false && V.Situacao == SITUACAO_LIVRE)
                         });

            return lista;
        }

        public void ReservarVaga(int Id_Vaga, int Id_Carro)
        {
            Vaga vaga = Util.ConsultarVaga(Id_Vaga, ct);

            if (vaga.Situacao == eSituacaoVaga.Reservada.ToString())
            {
                throw new exVagaJaReservada(vaga.Nome);
            }

            vaga.Situacao = eSituacaoVaga.Reservada.ToString();
            vaga.Id_Carro = Id_Carro;
            vaga.HoraReserva = DateTime.Now;
            vaga.AguardandoSinalizacao = true;

            ct.SaveChanges();

            //TODO: Log ReservarVaga
        }

        public void CancelarReserva(int Id_Vaga, int Id_Carro)
        {
            Vaga vaga = Util.ConsultarVaga(Id_Vaga, ct);

            if (vaga.Situacao != eSituacaoVaga.Reservada.ToString())
            {
                throw new exVagaNaoReservada(vaga.Nome);
            }

            if (vaga.Id_Carro != Id_Carro)
            {
                throw new exCancelamentoNaoPermitido(vaga.Nome);
            }

            vaga.Situacao = eSituacaoVaga.Livre.ToString();
            vaga.Id_Carro = null;
            vaga.HoraReserva = null;
            vaga.AguardandoSinalizacao = true;

            ct.SaveChanges();

            //TODO: Log CancelarReserva
        }

        public IEnumerable<dtoCarro> ListarCarros(string CPF)
        {
            Cliente cliente = Util.ConsultarCliente(CPF, ct);

            var ListaCarros = (from Ca in cliente.Carro
                               select new dtoCarro
                               {
                                   Id = Ca.Id,
                                   Marca = Ca.Marca,
                                   Placa = Ca.Placa
                               });

            return ListaCarros;
        }

        #endregion

        #region Fluxo Manter Vaga Reservada

        public dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga, int Id_Carro)
        {
            Vaga vaga = Util.ConsultarVaga(Id_Vaga, ct);

            dtoSituacaoVaga situacao = new dtoSituacaoVaga();
            situacao.VagaAindaReservada = false;
            situacao.ReservaConcluidaComSucesso = false;

            if (vaga.Situacao == eSituacaoVaga.Reservada.ToString() && vaga.Id_Carro == Id_Carro)
            {
                situacao.VagaAindaReservada = true;
            }
            else if (vaga.Situacao == eSituacaoVaga.Ocupada.ToString() && vaga.Id_Carro == Id_Carro)
            {
                situacao.ReservaConcluidaComSucesso = true;

            }

            return situacao;
        }

        #endregion

        #region Fluxo Localizar Carro

        public dtoCaminho LocalizarCarro(int Id_Totem, int Id_Carro)
        {
            var caminho = (from C in ct.Caminho
                           where C.Id_Totem == Id_Totem && C.Vaga.Id_Carro == Id_Carro
                           select C).SingleOrDefault();

            if (caminho == null)
            {
                return null;
            }

            dtoCaminho dto = new dtoCaminho();
            dto.ListaImagens = new List<string>();

            foreach (var caminhoMapa in caminho.Caminho_Mapa)
            {
                string base64 = Convert.ToBase64String(caminhoMapa.Mapa.Imagem);

                dto.ListaImagens.Add(base64);
            }

            return dto;
            //TODO: Log LocalizarCarro (guardar totem pesquisado)
        }

        #endregion

    }
}
