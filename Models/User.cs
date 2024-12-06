using System;
using System.Collections.Generic;

namespace _api.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int AreaId { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public virtual Area AreaIdNavigation { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
