using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRApp.Shared;

public class Item{
    public Guid Id { get; set; }
    public String name { get; set; }
    public String value { get; set; }    
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
}
