﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkingService
{

    [ServiceContract]
    public interface IServico
    {

        //Fluxo Reservar Vaga
        //===================

        [OperationContract]
        IEnumerable<dtoAndar> ListarAndares();

        [OperationContract]
        IEnumerable<dtoBloco> ListarBlocos(int Id_Andar);

        [OperationContract]
        IEnumerable<dtoVaga> ListarVagas(int Id_Bloco);

        [OperationContract]
        bool ReservarVaga(int Id_Vaga, int Id_Carro);

        //Fluxo Manter Vaga Reservada
        //===========================

        [OperationContract]
        dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga);

        //Fluxo Localizar Carro
        //=====================

        [OperationContract]
        dtoCaminho LocalizarCarro(int Id_QRCode, int Id_Carro);

        //Fluxo Manter Carros
        //===========================

        [OperationContract]
        IEnumerable<dtoCarro> ListarCarros(string CPF);

        [OperationContract]
        IEnumerable<string> ListarMarcasCarro();

        [OperationContract]
        bool CadastrarCarro(string CPF, dtoCarro novoCarro);

        [OperationContract]
        bool AlterarCarro(dtoCarro novoCarro);

        [OperationContract]
        bool ExcluirCarro(int Id_Carro);

    }

}
