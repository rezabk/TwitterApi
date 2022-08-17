using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Mapping
{
    public class TweetMapping : IEntityTypeConfiguration<TweetModel>
    {
        public void Configure(EntityTypeBuilder<TweetModel> builder)
        {
            builder.ToTable("Tweets");
            builder.HasKey(x => x.Id);
        }
    }
}
