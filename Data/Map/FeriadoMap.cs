using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class FeriadoMap : IEntityTypeConfiguration<FeriadoModel>
    {

        public void Configure(EntityTypeBuilder<FeriadoModel> builder)
        {
            builder.HasKey(x => x.idFeriado);
            builder.Property(x => x.nomeFeriado).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dataFeriado).IsRequired();
        }
    }
}

