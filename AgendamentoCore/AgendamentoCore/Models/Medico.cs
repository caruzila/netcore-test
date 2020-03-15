using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AgendamentoCore.Models
{
    public class Medico
    {
        public int MedicoId { get; set; } 

        public string MedicoNome { get; set; }

        public string MedicoCrm{ get; set; }

    }
}
