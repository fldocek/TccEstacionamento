﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingService
{
    public class exClienteNaoEncontrado : ApplicationException
    {
        public exClienteNaoEncontrado(string CPF) :
            base("Usuário de CPF \"" + Util.FormatarCPF(CPF) + "\" não encontrado!") { }
    }

    public class exVagaNaoEncontrada : ApplicationException
    {
        public exVagaNaoEncontrada(int Id_Vaga) :
            base("Vaga de Id \"" + Id_Vaga + "\" não encontrada!") { }
    }

    public class exVagaJaReservada : ApplicationException
    {
        public exVagaJaReservada(string NomeVaga) :
            base("A Vaga " + NomeVaga + " já se encontra reservada.") { }
    }

    public class exVagaNaoReservada : ApplicationException
    {
        public exVagaNaoReservada(string NomeVaga) :
            base("A Vaga " + NomeVaga + " não se encontra reservada.") { }
    }

    public class exCancelamentoNaoPermitido : ApplicationException
    {
        public exCancelamentoNaoPermitido(string NomeVaga) :
            base("O cancelamento da vaga " + NomeVaga + " não permitido.") { }
    }
}