using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Tools.ViewModels
{
    /// <inheritdoc cref="ViewModelBuilderBase"/>
    public abstract class ViewModelBuilderBase<TController> : ViewModelBuilderBase where TController : ControllerBase
    {
        /// <inheritdoc cref="ViewModelBuilderBase.Controller"/>
        public new TController Controller { get; }

        /// <inheritdoc cref="ViewModelBuilderBase(ControllerBase)"/>
        public ViewModelBuilderBase(TController controller) : base(controller) => Controller = controller;
    }
}
