using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace new_project.Models;

public partial class UserDatum
{
    [Key]
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
