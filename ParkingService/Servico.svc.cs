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
                             QtdVagas = (from B in A.Bloco
                                         from V in B.Vaga
                                         select V).Count(),
                             QtdLive = (from B in A.Bloco
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

            if (vaga.Situacao == eSituacaoVaga.Reservada.ToString())
            {
                throw new exVagaJaReservada(vaga.Nome);
            }

            vaga.Situacao = eSituacaoVaga.Reservada.ToString();
            vaga.Id_Carro = Id_Carro;
            vaga.HoraReserva = DateTime.Now;

            ct.SaveChanges();

            return true;

            //TODO: Log ReservarVaga
        }

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

        #endregion

        #region Fluxo Manter Vaga Reservada

        public dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga, int Id_Carro)
        {
            Vaga vaga = ConsultarVaga(Id_Vaga);

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

            foreach (var mapa in caminho.Caminho_Mapa)
            {
                Bitmap bmp;
                using (var ms = new MemoryStream(mapa.Mapa.Imagem))
                {
                    bmp = new Bitmap(ms);
                }

                dto.ListaImagens.Add(bmp);
            }

            return dto;
            //TODO: Log LocalizarCarro (guardar totem pesquisado)
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
