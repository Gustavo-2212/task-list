using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListaTarefas.Models;

namespace ListaTarefas.Context
{
    public class TarefaContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
            
        }
    }
}