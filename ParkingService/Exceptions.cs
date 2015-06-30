using System;
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
}