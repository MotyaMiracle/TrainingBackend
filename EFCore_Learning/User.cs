using System;
using System.Collections.Generic;

namespace EFCore_Learning;

public partial class User
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long Age { get; set; }
}
