using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ExpensaDTO
    {
        public int AnioExpensa { get; set; }
        public int MesExpensa { get; set; }
        public double GastoTotal { get; set; }
        public double ExpensaPorUnidad { get; set; }

    }
}