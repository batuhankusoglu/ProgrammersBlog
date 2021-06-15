using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings {
	public class ArticleMap : IEntityTypeConfiguration<Article> {
		public void Configure( EntityTypeBuilder<Article> builder ) {

			// Id
			builder.HasKey( a => a.Id );
			builder.Property( a => a.Id ).ValueGeneratedOnAdd();        // Id teker teker artmalı
			
			// Title
			builder.Property( a => a.Title ).HasMaxLength(100);
			builder.Property( a => a.Title ).IsRequired();
			
			// Content
			builder.Property( a => a.Content ).IsRequired();
			builder.Property( a => a.Content ).HasColumnType( "NVARCHAR(MAX)" );
			
			builder.Property( a => a.Date ).IsRequired();

			// SEO
			builder.Property( a => a.SeoAuthor ).IsRequired();
			builder.Property( a => a.SeoAuthor ).HasMaxLength(50);
			builder.Property( a => a.SeoDescription ).IsRequired();
			builder.Property( a => a.SeoDescription ).HasMaxLength(150);
			builder.Property( a => a.SeoTags ).IsRequired();
			builder.Property( a => a.SeoTags ).HasMaxLength(70);

			// Counts
			builder.Property( a => a.ViewCount ).IsRequired();
			builder.Property( a => a.CommentCount ).IsRequired();
			
			// Thumbnails
			builder.Property( a => a.Thumbnail ).IsRequired();
			builder.Property( a => a.Thumbnail ).HasMaxLength(250);
			
			// Created and Modified
			builder.Property( a => a.CreatedByName ).IsRequired();
			builder.Property( a => a.CreatedByName ).HasMaxLength(50);
			builder.Property( a => a.CreatedDate ).IsRequired();
			builder.Property( a => a.ModifiedByName ).IsRequired();
			builder.Property( a => a.ModifiedByName ).HasMaxLength(50);
			builder.Property( a => a.ModifiedDate ).IsRequired();

			builder.Property( a => a.IsActive ).IsRequired();
			builder.Property( a => a.IsDeleted ).IsRequired();

			builder.Property( a => a.Note ).HasMaxLength(500);


			#region One to Many Relations
			
			builder.HasOne<Category>( a => a.Category ).WithMany( c => c.Articles ).HasForeignKey( a => a.CategoryId );
			builder.HasOne<User>( a => a.User ).WithMany( u => u.Articles ).HasForeignKey( a => a.UserId );

			#endregion

			builder.ToTable( "Articles" );

			builder.HasData( new Article {
				Id = 1,
				CategoryId = 1,
				Title = "C# 9 and .NET 5 News",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
				"when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, " +
				"but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
				"and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
				Thumbnail = "Default.jpg",
				SeoAuthor = "Batuhan Kusoglu",
				SeoDescription = "C# 9 and .NET 5 News",
				SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C# 9 and .NET 5 News",
				UserId = 1,
				ViewCount = 100,
				CommentCount = 3
			}, new Article {
				Id = 2,
				CategoryId = 2,
				Title = "C++ 11 News",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
				"when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, " +
				"but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
				"and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
				Thumbnail = "Default.jpg",
				SeoAuthor = "Batuhan Kusoglu",
				SeoDescription = "C# 11 News",
				SeoTags = "C++, C++ 11",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "C# 9 and .NET 5 News",
				UserId = 1,
				ViewCount = 150,
				CommentCount = 3
			}, new Article {
				Id = 3,
				CategoryId = 3,
				Title = "JavaScript News",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
				"when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, " +
				"but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
				"and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
				Thumbnail = "Default.jpg",
				SeoAuthor = "Batuhan Kusoglu",
				SeoDescription = "JavaScript News",
				SeoTags = "JavaScript",
				IsActive = true,
				IsDeleted = false,
				CreatedByName = "InitialCreate",
				CreatedDate = DateTime.Now,
				ModifiedByName = "InitialCreate",
				ModifiedDate = DateTime.Now,
				Note = "JavaScript News",
				UserId = 1,
				ViewCount = 200,
				CommentCount = 3
			} );
		}
	}
}
