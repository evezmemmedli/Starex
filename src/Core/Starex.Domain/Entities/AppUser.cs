﻿using Microsoft.AspNetCore.Identity;
using Starex.Domain.Entities;
public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Adress { get; set; }
    public DeliveryPoint DeliveryPoint { get; set; }
    public int? DeliveryPointId { get; set; }
    public PoctAdress PoctAdress { get; set; }
    public int PoctAdressId { get; set; }
    public string IdentityNumber { get; set; }
    public string Fin { get; set; }
    public decimal Balans { get; set; }
    public List<Package> Packages { get; set; }
    public List<Order> Orders { get; set; }
    public List<Commitment> Commitments { get; set; }
    public List<ReturnPackage> ReturnPackages { get; set; }
    public List<Declare> Declares { get; set; }
    public List<Appeal> Appeals { get; set; }
}

