using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRApp.Shared;

public class Item{
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public String? Value { get; set; }    
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
