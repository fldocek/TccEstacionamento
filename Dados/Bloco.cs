//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dados
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bloco
    {
        public Bloco()
        {
            this.Vaga = new HashSet<Vaga>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Id_Andar { get; set; }
    
        public virtual Andar Andar { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}