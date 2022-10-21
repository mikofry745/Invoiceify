﻿using System.ComponentModel.DataAnnotations;
using Invoiceify.Entities.Enums;

namespace Invoiceify.Entities.Entities;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]
    public UnitType UnitType { get; set; }
    
    public string? Description { get; set; }
    public int? TaxPercentage { get; set; }
    
    public int BusinessId { get; set; }
    public Business? Business { get; set; }
}