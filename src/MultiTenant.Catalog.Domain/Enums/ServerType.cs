using System.ComponentModel.DataAnnotations;

namespace MultiTenant.Catalog.Domain.Enums;

public enum ServerType
{
    [Display(Name = "Virtual Machine")] Vm = 1,
    [Display(Name = "Physical Machine")] Physical = 2
}