using EcommerceAPI.Infraestructura.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Infraestructura.Database.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() { } 
        public EcommerceContext(DbContextOptions<EcommerceContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        #region DBSets
            public virtual DbSet<ClienteEntity> Clientes { get; set;}   
            public virtual DbSet<CompraEntity> Compra {get; set;}  
        #endregion
    }
}
