using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Conf.Options
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //builder.Property(x => x.CreatedDate).HasColumnName("Veri Yaratılma Tarihi");
            //builder.Property(x => x.UpdatedDate).HasColumnName("Veri Güncelleme Tarihi");
            //builder.Property(x => x.DeletedDate).HasColumnName("Veri Silme Tarihi");
            //builder.Property(x => x.Status).HasColumnName("Veri Durumu");
        }
    }
}
