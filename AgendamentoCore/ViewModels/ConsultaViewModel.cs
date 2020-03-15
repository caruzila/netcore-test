using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AgendamentoCore.ViewModels
{
    public class ConsultaViewModel
    {
        public DateTime ConsultaData { get; set; }

        public int MedicoId { get; set; }

        public int PacienteId { get; set; }
    }
}
