using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebService.Models;
using WebService.Commands.BookCommands;
using WebService.Commands.UserCommands;
using WebService.Commands.CharacterCommands;
using WebService.Commands.ProductCommands;
using WebService.Commands.Interfaces;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddScoped<IRepository<Book>, BookRepo>();
            services.AddScoped<IRepository<User>, UserRepo>();
            services.AddScoped<IAsyncRepository<Character>, CharacterRepo>();
            services.AddScoped<IAsyncRepository<Product>, ProductRepo>();

            services.AddSingleton<IMapper<Book, BookDTO>, BookToBookDTO>();
            services.AddSingleton<IMapper<User, UserDTO>, UserToUserDTO>();
            services.AddSingleton<IMapper<Character, CharacterDTO>, CharacterToCharacterDTO>();
            services.AddSingleton<IMapper<Product, ProductDTO>, ProductToProductDTO>();

            services.AddTransient<IDeleteCommand<Book>, DeleteBookCommand>();
            services.AddTransient<IGetAllCommand<BookDTO>, GetAllBooksCommand>();
            services.AddTransient<IGetOneCommand<BookDTO>, GetOneBookCommand>();
            services.AddTransient<IPostCommand<Book>, PostBookCommand>();
            services.AddTransient<IPutCommand<Book>, PutBookCommand>();

            services.AddTransient<IDeleteCommand<User>, DeleteUserCommand>();
            services.AddTransient<IGetAllCommand<UserDTO>, GetAllUsersCommand>();
            services.AddTransient<IGetOneCommand<UserDTO>, GetOneUserCommand>();
            services.AddTransient<IPostCommand<User>, PostUserCommand>();
            services.AddTransient<IPutCommand<User>, PutUserCommand>();

            services.AddTransient<IAsyncDeleteCommand<Character>, DeleteCharacterCommand>();
            services.AddTransient<IAsyncGetAllCommand<CharacterDTO>, GetAllCharactersCommand>();
            services.AddTransient<IAsyncGetOneCommand<CharacterDTO>, GetOneCharacterCommand>();
            services.AddTransient<IAsyncPostCommand<Character>, PostCharacterCommand>();
            services.AddTransient<IAsyncPutCommand<Character>, PutCharacterCommand>();

            services.AddTransient<IAsyncDeleteCommand<Product>, DeleteProductCommand>();
            services.AddTransient<IAsyncGetAllCommand<ProductDTO>, GetAllProductsCommand>();
            services.AddTransient<IAsyncGetOneCommand<ProductDTO>, GetOneProductCommand>();
            services.AddTransient<IAsyncPostCommand<Product>, PostProductCommand>();
            services.AddTransient<IAsyncPutCommand<Product>, PutProductCommand>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
