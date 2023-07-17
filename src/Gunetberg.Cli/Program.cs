using Gunetberg.Application.Post;
using Gunetberg.Application.Tag;
using Gunetberg.Application.User;
using Gunetberg.Client.Hash;
using Gunetberg.Domain.Post;
using Gunetberg.Domain.User;
using Gunetberg.Repository;
using Gunetberg.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer("Server=127.0.0.1;Database=GunetbergDB;User Id=sa;Password=pass123456!;TrustServerCertificate=true;");
            var repositoryContext = new RepositoryContext(options.Options);
            var repositoryContextFactory = new RepositoryContextFactory(repositoryContext);
            var userRepository = new UserRepository(repositoryContextFactory);
            var tagRepository = new TagRepository(repositoryContextFactory);
            var hashClient = new Sha256HashClient();
            var userService = new UserService(userRepository, hashClient);
            //var postRepository = new PostRepository(repositoryContextFactory);
            //var postService = new PostService(postRepository);
            var tagService = new TagService(tagRepository);

            var content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi facilisis tincidunt ultricies. Vivamus commodo lectus quam, nec pretium dui gravida sit amet. Aliquam tincidunt ac metus vel blandit. Phasellus ut lacus tortor. Donec egestas dui dui, vitae ultricies nisi fringilla vitae. Proin lobortis elit et porta imperdiet. Vestibulum rhoncus vulputate accumsan. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nunc convallis aliquet cursus. Proin egestas nisi quis nisl sodales, eget pretium lectus mattis.\r\n\r\nInterdum et malesuada fames ac ante ipsum primis in faucibus. Fusce quis elit tellus. In hac habitasse platea dictumst. Phasellus finibus, dui in venenatis fermentum, ex neque pellentesque diam, quis dignissim ex dolor aliquet urna. In in nunc in elit ullamcorper fermentum eget dapibus est. Nam accumsan ante vestibulum orci dapibus, quis tincidunt mauris pharetra. Vestibulum cursus sapien convallis, venenatis massa sollicitudin, posuere nunc. Vivamus a leo nisi. Vivamus ut mauris ac erat finibus mollis eu sit amet neque. Ut libero turpis, finibus maximus consequat id, ultrices vel felis. Pellentesque vitae molestie nunc, ornare consectetur nisl. Suspendisse vel velit semper, scelerisque purus luctus, eleifend turpis. Sed nec hendrerit leo. Sed eu tincidunt magna.\r\n\r\nMorbi luctus maximus ante in iaculis. In consequat ultrices malesuada. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Proin tristique placerat urna, in congue orci sodales nec. Quisque semper odio tristique, efficitur neque non, condimentum diam. Donec at iaculis risus. Pellentesque eget nibh erat. Nullam auctor diam non eros efficitur pulvinar. Vivamus interdum eros eget fringilla lobortis. Mauris accumsan bibendum risus, iaculis consectetur risus dignissim a. Fusce cursus enim massa, et mattis sem ullamcorper sed. Nunc suscipit pulvinar ante sit amet eleifend. Mauris malesuada aliquam leo.\r\n\r\nAenean venenatis gravida odio a dictum. Ut lobortis mattis elementum. Aliquam erat volutpat. Suspendisse interdum eu ante eu dictum. Proin finibus et dui eget ornare. Integer dui dolor, interdum quis semper in, malesuada sed velit. Donec sagittis ante eget justo tincidunt tincidunt. Integer ultrices efficitur eros. Nam efficitur imperdiet neque non congue. Vestibulum a mauris ac nisl volutpat ultrices vel sit amet nunc. In laoreet leo lectus, eget consequat magna ultricies quis. Pellentesque venenatis ipsum metus, in aliquam libero congue id.\r\n\r\nNulla nec fringilla sapien. Praesent sed condimentum orci. Aenean porta leo quis leo molestie fermentum. Nam faucibus, sem nec tempor aliquam, nisi magna condimentum velit, quis ullamcorper odio augue id velit. In hac habitasse platea dictumst. Maecenas vehicula sed arcu sit amet ultrices. Donec nunc diam, blandit aliquam congue sed, sodales eget odio. Phasellus diam tortor, viverra et tortor ut, ullamcorper fermentum tellus. Sed at consequat eros, non aliquam ligula. Proin feugiat mattis turpis eget interdum. Nunc metus ex, blandit nec molestie at, tristique eu ligula. Etiam quis magna dapibus, consectetur quam sed, fringilla tortor. Integer a maximus erat. Mauris lacus lacus, sollicitudin nec sem malesuada, semper dapibus lectus.\r\n\r\nCurabitur fermentum mauris at maximus condimentum. Donec nec cursus ipsum. Mauris scelerisque arcu id pulvinar rutrum. Proin eget lorem tristique, pretium lacus sit amet, consequat purus. Praesent vitae neque sagittis, commodo risus a, congue dolor. Vivamus est magna, elementum ut consectetur vel, sollicitudin vitae nisi. Fusce vel eros vitae augue suscipit vestibulum at nec risus. Mauris dignissim lorem lobortis quam interdum";

            var user = new CreateUserRequest
            {
                Email = "daniel.avilaf@outlook.es",
                Alias = "daniavfe",
                Password = "pass",
                PasswordCheck = "pass"
            };

            var userId = Guid.Parse("263A2E9F-00C8-4219-4950-08DB8472C680");

            var posts = new List<CreatePostRequest> {
                new CreatePostRequest
                {
                    Title="Post de prueba 1",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/6cb/winter-2-1169713.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 2",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/a95/forest-1313632.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 3",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/068/power-plant-1-1250601.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 4",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/212/flowers-1370428.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 5",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/d71/flower-1184503.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 6",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/4ca/maldives-unseen-beauty-1641934.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 7",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/8ff/abstract-stone-at-yellowstonepark-4-1181348.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 8",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/974/city-nightscape-1446087.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 9",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/c15/dresden-sunrisin-2-1184173.jpg",
                    Language="es"
                },
                new CreatePostRequest
                {
                    Title="Post de prueba 10",
                    Content=content,
                    CreatedBy = userId,
                    ImageUrl = "https://images.freeimages.com/images/large-previews/ce3/city-1570944.jpg",
                    Language="es"
                }
            };

            var postWithTags = new CreatePostRequest
            {
                Title = "Post de prueba 16",
                Content = content,
                CreatedBy = userId,
                ImageUrl = "https://images.freeimages.com/images/large-previews/6cb/winter-2-1169713.jpg",
                Language = "en",
                Tags = new List<Guid> {
                    Guid.Parse("C048F004-F1B1-47D6-51D3-08DB8472ED7A"),
                    Guid.Parse("4091FABF-DDB2-46FB-51D4-08DB8472ED7A"),
                }
            };

            var t = Task.Run(async () =>
            {

                using (repositoryContext)
                {

                    //await userService.CreateUser(user);

                    //await postService.CreatePost(postWithTags);

                    //await tagService.CreateTag(new CreateTagRequest{ Name = "OtherTag"});
                    //await tagService.CreateTags(new List<CreateTagRequest> {
                    //    new CreateTagRequest{Name = "Technology"},
                    //    new CreateTagRequest{Name = "Art"},
                    //    new CreateTagRequest{Name = "Music"},
                    //});

                    foreach(var post in posts)
                    {
                        var op = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer("Server=127.0.0.1;Database=GunetbergDB;User Id=sa;Password=pass123456!;TrustServerCertificate=true;");
                        var rc = new RepositoryContext(op.Options);
                        var crf = new RepositoryContextFactory(rc);
                        var pr = new PostRepository(crf);
                        var ps = new PostService(pr);
                        await ps.CreatePost(post);
                    }
                    

                }

            });

            t.Wait();
        }




    }
}