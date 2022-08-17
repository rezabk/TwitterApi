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
    public class TweetUserMapping : IEntityTypeConfiguration<TweetUserModel>
    {
        public void Configure(EntityTypeBuilder<TweetUserModel> builder)
        {
            builder.ToTable("TweetUsers");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Tweet).WithMany(x => x.TweetUser).HasForeignKey(x => x.TweetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User).WithMany(x => x.TweetUser).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
