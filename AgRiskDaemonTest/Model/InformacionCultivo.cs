using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgRiskDaemonTest.Model
{
    public class InformacionCultivo
    {
        public string ValidacionDatos { get; set; }
        public int IdVereda { get; set; }
        public int IdSistema { get; set; }
        public int IdCultivo { get; set; }
        public double AreaCultivo { get; set; }
        public int TamanoProductor { get; set; }
        public int CostoProduccion { get; set; }
        public int Cosecha { get; set; }
        public DateTime FechaInicioVigenia { get; set; }
        public DateTime FechaFinalVigencia { get; set; }
    }
}
