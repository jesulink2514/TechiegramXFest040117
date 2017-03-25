using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Techiegram.Models;

namespace Techiegram.Services
{
    public class FeedsService : IFeedsService
    {
        public async Task<List<Post>> GetPostsForUserAsync(string userId,int page=1)
        {
            await Task.Delay(750);

            return (new List<Post>()
            {
                new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = "SomosTechies.com",
                    ImageUrl = "https://instagram.flim2-1.fna.fbcdn.net/t51.2885-15/e35/17493786_177642709414779_2279584472519147520_n.jpg",
                    Author = new User()
                    {
                        FullName = "Jesus Angulo",UserName = "jesulink2514", UserId = "17493786"
                    }
                },
                new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = "Hi!!",
                    ImageUrl = "https://instagram.flim2-1.fna.fbcdn.net/t51.2885-15/e35/17493786_177642709414779_2279584472519147520_n.jpg",
                    Author = new User()
                    {
                        FullName = "Jesus Angulo",UserName = "jesulink2514", UserId = "17493786"
                    }
                },
                new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = "Insta user",
                    ImageUrl = "https://instagram.flim2-1.fna.fbcdn.net/t51.2885-15/e35/17493786_177642709414779_2279584472519147520_n.jpg",
                    Author = new User()
                    {
                        FullName = "Jesus Angulo",UserName = "jesulink2514", UserId = "17493786"
                    }
                },
                new Post()
                {
                    Id = Guid.NewGuid(),
                    Title = "Photo 4",
                    ImageUrl = "https://instagram.flim2-1.fna.fbcdn.net/t51.2885-15/e35/17493786_177642709414779_2279584472519147520_n.jpg",
                    Author = new User()
                    {
                        FullName = "Jesus Angulo",UserName = "jesulink2514", UserId = "17493786"
                    }
                }
            });
        }
    }
}
