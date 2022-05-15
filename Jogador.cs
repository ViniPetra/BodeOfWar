﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodeOfWar
{
    public class Jogador
    {
        public Jogador(int id, string senha, int idpartida, List<Cartas> mao, Cartas[] todascartas, string nome)
        {
            Id = id;
            Senha = senha;
            idPartida = idpartida;
            Mao = mao;
            TodasCartas = todascartas;
            Nome = nome;
        }

        public Jogador()
        {
            this.MaoId = new List<int>();
        }

        public int Id { get; set; }
        public string Senha { get; set; }
        public int idPartida { get; set; }
        public List<Cartas> Mao { get; set; }
        public Cartas[] TodasCartas { get; set; }
        public string Nome { get; set; }
        public List<int> MaoId { get; set; }
    }
}
