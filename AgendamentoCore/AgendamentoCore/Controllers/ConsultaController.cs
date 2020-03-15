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
    public class ConsultaController : ControllerBase
    {
        private readonly AgendamentoContext _context;
        private readonly IMapper _mapper;

        public ConsultaController(AgendamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaConsulta()
        {
            return Ok(_context.Consultas.ToList());
        }

        [Route("Medico")]
        [HttpGet]
        public IActionResult GetByNomeMedico([FromQuery]string nomeMedico)
        {
            var medicos = _context.Medicos.Where(x => x.MedicoNome.Contains(nomeMedico)).Select(x => x.MedicoId);
            var listaMedicos = medicos.ToArray();
            var consultas = _context.Consultas.Where(x => listaMedicos.Contains(x.MedicoId));
            if (consultas == null || !consultas.Any())
            {
                return NotFound("Não existem consultas marcadas para este medico.");
            }
            else
            {
                return Ok(consultas.ToArray());
            }

        }

        [Route("Paciente")]
        [HttpGet]
        public IActionResult GetByNomePaciente([FromQuery]string nomePaciente)
        {
            var pacientes = _context.Pacientes.Where(x => x.PacienteNome.Contains(nomePaciente)).Select(x => x.PacienteId);
            var listaPacientes = pacientes.ToArray();
            var consultas = _context.Consultas.Where(x => listaPacientes.Contains(x.PacienteId));
            if (consultas == null || !consultas.Any())
            {
                return NotFound("Não existem consultas marcadas para este paciente.");
            }
            else
            {
                return Ok(consultas.ToArray());
            }
        }

        [HttpPost]
        public IActionResult IncluirConsulta([FromBody]ConsultaViewModel consultaVM)
        {
            var consultas = _context.Consultas.Where(x => x.MedicoId == consultaVM.MedicoId && x.ConsultaData  == consultaVM.ConsultaData);
            if (consultas == null || !consultas.Any())
            {
                Consulta consulta = _mapper.Map<Consulta>(consultaVM);
                var ret = _context.Consultas.Add(consulta);
                _context.SaveChanges();
                return Ok(ret.Entity);
            }
            else
            {
                return BadRequest("Já existe consulta marcada para esse horario");
            }
        }

        [HttpDelete]
        public IActionResult DeletarConsulta(int id)
        {
            var consulta = _context.Consultas.Where(x => x.ConsultaId == id).FirstOrDefault();
            _context.Consultas.Remove(consulta);
            _context.SaveChanges();
            return Ok();
        }
    }
}
