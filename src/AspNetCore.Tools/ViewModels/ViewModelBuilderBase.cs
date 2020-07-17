using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Security.Claims;
using RouteData = Microsoft.AspNetCore.Routing.RouteData;

namespace AspNetCore.Tools.ViewModels
{
    /// <summary>
    /// Base class for ViewModelBuilders that provides access
    /// to the same properties as the <see cref="ControllerBase"/>.
    /// </summary>
    public abstract class ViewModelBuilderBase
    {
        /// <summary>
        /// Controller associated with the current request.
        /// </summary>
        public ControllerBase Controller { get; }

        /// <inheritdoc cref="ControllerBase.ControllerContext"/>
        public ControllerContext ControllerContext
        {
            get => Controller.ControllerContext;
            set => Controller.ControllerContext = value;
        }

        /// <inheritdoc cref="ControllerBase.HttpContext"/>
        public HttpContext HttpContext => Controller.HttpContext;

        /// <inheritdoc cref="ControllerBase.MetadataProvider"/>
        public IModelMetadataProvider MetadataProvider
        {
            get => Controller.MetadataProvider;
            set => Controller.MetadataProvider = value;
        }

        /// <inheritdoc cref="ControllerBase.ModelBinderFactory"/>
        public IModelBinderFactory ModelBinderFactory
        {
            get => Controller.ModelBinderFactory;
            set => Controller.ModelBinderFactory = value;
        }

        /// <inheritdoc cref="ControllerBase.ModelState"/>
        public ModelStateDictionary ModelState => Controller.ModelState;

        /// <inheritdoc cref="ControllerBase.ObjectValidator"/>
        public IObjectModelValidator ObjectValidator
        {
            get => Controller.ObjectValidator;
            set => Controller.ObjectValidator = value;
        }

        /// <summary>
        /// Gets or sets <see cref="Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory"/>.
        /// </summary>
        public ProblemDetailsFactory ProblemDetailsFactory
        {
            get => Controller.ProblemDetailsFactory;
            set => Controller.ProblemDetailsFactory = value;
        }

        /// <inheritdoc cref="ControllerBase.Request"/>
        public HttpRequest Request => Controller.Request;

        /// <inheritdoc cref="ControllerBase.Response"/>
        public HttpResponse Response => Controller.Response;

        /// <inheritdoc cref="ControllerBase.RouteData"/>
        public RouteData RouteData => Controller.RouteData;

        /// <inheritdoc cref="ControllerBase.Url"/>
        public IUrlHelper Url
        {
            get => Controller.Url;
            set => Controller.Url = value;
        }

        /// <inheritdoc cref="ControllerBase.User"/>
        public ClaimsPrincipal User => Controller.User;

        /// <inheritdoc cref="HttpContext.Session"/>
        public ISession Session
        {
            get => Controller.HttpContext.Session;
            set => Controller.HttpContext.Session = value;
        }


        /// <inheritdoc cref="HttpContext.WebSockets"/>
        public WebSocketManager WebSockets => Controller.HttpContext.WebSockets;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBuilderBase"/> class.
        /// </summary>
        /// <param name="controller">Controller associated with the current request.</param>
        public ViewModelBuilderBase(ControllerBase controller) => Controller = controller;
    }
}
