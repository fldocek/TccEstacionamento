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
    
    public partial class Caminho
    {
        public Caminho()
        {
            this.Caminho_Mapa = new HashSet<Caminho_Mapa>();
        }
    
        public int Id { get; set; }
        public int Id_Vaga { get; set; }
        public int Id_Totem { get; set; }
    
        public virtual ICollection<Caminho_Mapa> Caminho_Mapa { get; set; }
        public virtual Totem Totem { get; set; }
        public virtual Vaga Vaga { get; set; }
    }
}
