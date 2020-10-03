using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AdminDTO
    {
    public int Id { get; set; }
    public DateTime StartingWorking { get; set; }
    public DateTime FinishingWorking { get; set; }
    public int PersonId { get; set; }
    }
}

