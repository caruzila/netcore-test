using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AgendamentoCore.Models;
using AutoMapper;
using AgendamentoCore.ViewModels;

namespace AgendamentoCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AgendamentoContext _context;
        private readonly IMapper _mapper;

        public PacienteController(AgendamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaPaciente()
        {
            return Ok(_context.Pacientes.ToList());
        }

        [HttpPost]
        public IActionResult IncluirPaciente([FromBody]PacienteViewModel pacienteVM)
        {
            Paciente paciente = _mapper.Map<Paciente>(pacienteVM);
            var ret = _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Ok(ret.Entity);
        }

        [HttpPut]
        public IActionResult EditarPaciente([FromBody]Paciente paciente)
        {
            var ret = _context.Pacientes.Update(paciente);
            _context.SaveChanges();
            return Ok(ret.Entity);
        }

        [HttpDelete]
        public IActionResult DeletarPaciente(int id)
        {
            var paciente = _context.Pacientes.Where(x => x.PacienteId == id).FirstOrDefault();
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return Ok();
        }


    }
}
