using System;
using System.Collections.Generic;
using IRepositorio;
using SerieRepositorio;
using Entidade;
using EnumGenero;


namespace SerieRepositorio
{
    public class Serie : EntidadeBase
    {
        //Atributos
        public Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }


        private bool Excluido { get; set; }

        //Metodo

        //Construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        //Metodo ToString
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }


        //Metodos de retorno

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public int RetornaExcluido()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

        public string RetornaDescrição()
        {
            return this.Descricao;
        }
    }


}
