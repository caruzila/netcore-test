using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoCore.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }

        public DateTime ConsultaData{ get; set; }

        public int MedicoId { get; set; }

        public int PacienteId { get; set; }


    }
}
