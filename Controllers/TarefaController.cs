using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListaTarefas.Models;
using ListaTarefas.Context;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }


        // -- ENDPOINTS
        [HttpPost]
        public IActionResult CreateTask(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue) return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(tarefa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = tarefa.Id}, tarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult GetAllTasks()
        {
            var tarefas = _context.Tarefas.ToList();

            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null) return NotFound();

            return Ok(tarefa);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult GetTaskByTitle(string titulo)
        {
            var tarefas = _context.Tarefas.Where(tarefa => tarefa.Titulo.Contains(titulo));

            return Ok(tarefas);
        }

        [HttpGet("ObterPorData")]
        public IActionResult GetTaskByDate(DateTime _data)
        {
            var tarefas = _context.Tarefas.Where(tarefa => tarefa.Data.Date == _data.Date);

            return Ok(tarefas);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult GetTaskByStatus(EnumStatus status)
        {
            var tarefas = _context.Tarefas.Where(tarefa => tarefa.Status.Equals(status));

            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskById(int id, Tarefa tarefaAtualizada)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null) return NotFound();

            if (tarefaAtualizada.Data == DateTime.MinValue) return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Status = tarefaAtualizada.Status;
            tarefa.Data = tarefaAtualizada.Data;

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaskById(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null) return NotFound();

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}