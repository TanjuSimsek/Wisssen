using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Model;

namespace Wissen.Data.Builder
{
   public class PostBuilder
    {
        public PostBuilder(EntityTypeConfiguration<Post> entity) {

            entity.Property(p => p.Title).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Description).IsRequired().HasMaxLength(200);
            entity.HasRequired(p => p.Category).WithMany(m => m.Posts).HasForeignKey(p => p.CategoryId);

        }
    }
}
