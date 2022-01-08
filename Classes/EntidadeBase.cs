using System;
using System.Collections.Generic;
using IRepositorio;
using SerieRepositorio;
using Entidade;
using EnumGenero;


namespace Entidade
{
   public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}
