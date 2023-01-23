using E_CommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Infrastructure.EntityTypeConfiguration
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            builder.HasMany(x => x.Products)
                .WithMany(x => x.Categories);
            base.Configure(builder);
        }
    }
}
