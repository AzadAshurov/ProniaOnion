using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using ProniaOnion.Application.DTOs.Tags;
using ProniaOnion.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace ProniaOnion.Application.DTOs.Blogs
{
   public record CreateBlogDto( string Title,
string Article,
string Image,
int AuthorId,
int GenreId, int[] TagIds); 

}
