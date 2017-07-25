using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TesteDeveloper.Application.Interfaces;
using TesteDeveloper.Application.Services;
using TesteDeveloper.Domain.Core.Bus;
using TesteDeveloper.Domain.Core.Events;
using TesteDeveloper.Domain.Core.Notifications;
using TesteDeveloper.Domain.Interfaces;
using TesteDeveloper.Domain.Produtos.CommandHandlers;
using TesteDeveloper.Domain.Produtos.Commands;
using TesteDeveloper.Domain.Produtos.EventHandlers;
using TesteDeveloper.Domain.Produtos.Events;
using TesteDeveloper.Domain.Produtos.Repository;
using TesteDeveloper.Infra.CrossCutting.AspNetFilters;
using TesteDeveloper.Infra.CrossCutting.Bus;
using TesteDeveloper.Infra.CrossCutting.Identity.Models;
using TesteDeveloper.Infra.CrossCutting.Identity.Services;
using TesteDeveloper.Infra.Data.Context;
using TesteDeveloper.Infra.Data.Repository;
using TesteDeveloper.Infra.Data.UoW;

namespace TesteDeveloper.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IProdutoAppService, ProdutoAppService>();            

            // Domain - Commands
            services.AddScoped<IHandler<RegistrarProdutoCommand>, ProdutoCommandHandler>();
            services.AddScoped<IHandler<AtualizarProdutoCommand>, ProdutoCommandHandler>();
            services.AddScoped<IHandler<ExcluirProdutoCommand>, ProdutoCommandHandler>();                                  
            // Domain - Produtos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ProdutoRegistradoEvent>, ProdutoEventHandler>();
            services.AddScoped<IHandler<ProdutoAtualizadoEvent>, ProdutoEventHandler>();
            services.AddScoped<IHandler<ProdutoExcluidoEvent>, ProdutoEventHandler>();
            

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ProdutosContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
        }
    }
}