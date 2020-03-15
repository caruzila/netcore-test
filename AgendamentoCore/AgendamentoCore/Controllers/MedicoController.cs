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
    public class MedicoController: ControllerBase
    {
        private readonly AgendamentoContext _context;
        private readonly IMapper _mapper;

        public MedicoController(AgendamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaMedico()
        {
            return Ok(_context.Medicos.ToList());
        }

        [HttpPost]
        public IActionResult IncluirMedico([FromBody]MedicoViewModel medicoVM)
        {
            Medico medico = _mapper.Map<Medico>(medicoVM);
            var ret = _context.Medicos.Add(medico);
            _context.SaveChanges();
            return Ok(ret.Entity);
        }

        [HttpPut]
        public IActionResult EditarMedico([FromBody]Medico medico)
        {
            var ret = _context.Medicos.Update(medico);
            _context.SaveChanges();
            return Ok(ret.Entity);
        }

        [HttpDelete]
        public IActionResult DeletarMedico(int id)
        {
            var medico = _context.Medicos.Where(x => x.MedicoId == id).FirstOrDefault();
            _context.Medicos.Remove(medico);
            _context.SaveChanges();
            return Ok();
        }


    }
}
