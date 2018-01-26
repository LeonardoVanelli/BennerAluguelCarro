using LocadoraCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraCarro.DAO
{
    public class CarroDAO
    {
        public void Adiciona(Carro carro)
        {
            using (var context = new LocadoraContext())
            {
                context.Carros.Add(carro);
                context.SaveChanges();
            }
        }

        public void Remove(Carro carro)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(carro).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Carro> Lista()
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Carros.ToList();
            }
        }

        public Carro BuscaPorId(int id)
        {
            using (var contexto = new LocadoraContext())
            {
                return contexto.Carros.Find(id);
            }
        }

        public void Atualiza(Carro carro)
        {
            using (var contexto = new LocadoraContext())
            {
                contexto.Entry(carro).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        public IList<Carro> RetornaCarrosDisponiveisPorData(DateTime DataRetirada, DateTime DataDevolucao)
        {
            using (var contexto = new LocadoraContext())
            {
                var query = $@"Select ca.Id, ca.Placa, ca.Descricao, ca.PrecoDia, ca.ModeloId, ca.Imagem
                                from Aluguels al
                                    , Carroes  ca
   	                                , Modeloes mo
                                where ca.modeloId = mo.Id
                                and al.CarroId = ca.Id 
                                and ca.Id NOT IN 
                                    (
                                        SELECT CarroId 
		                                FROM Aluguels al
                                        WHERE '{DataDevolucao.ToString("MM/dd/yyyy HH:mm:ss")}' < al.DataHoraDevolucao
                                        AND '{DataRetirada.ToString("MM/dd/yyyy HH:mm:ss")}' > al.DataHoraRetirada
			                            and al.StatusId <> 2
		                                and al.StatusId <> 3
                                        and al.StatusId <> 6  
                                    )";
                var Carros = contexto.Carros.SqlQuery(query).ToList();

                return Carros;
            }
        }
    }
}