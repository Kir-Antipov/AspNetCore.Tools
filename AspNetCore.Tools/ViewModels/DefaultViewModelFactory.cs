using AspNetCore.Tools.ViewModels.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ViewModels
{
    /// <summary>
    /// Default implementation of the <see cref="IViewModelFactory"/>.
    /// </summary>
    public class DefaultViewModelFactory : IViewModelFactory
    {
        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel>(ControllerBase controller, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel>.Instance.TryGetViewModel(controller, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel>(ControllerBase controller) => ViewModelBuilderWrapper<TViewModel>.Instance.TryGetViewModelAsync(controller);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1>(ControllerBase controller, T1 arg1, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1>.Instance.TryGetViewModel(controller, arg1, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1>(ControllerBase controller, T1 arg1) => ViewModelBuilderWrapper<TViewModel, T1>.Instance.TryGetViewModelAsync(controller, arg1);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2>(ControllerBase controller, T1 arg1, T2 arg2, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2>.Instance.TryGetViewModel(controller, arg1, arg2, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2>(ControllerBase controller, T1 arg1, T2 arg2) => ViewModelBuilderWrapper<TViewModel, T1, T2>.Instance.TryGetViewModelAsync(controller, arg1, arg2);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2, T3>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3>.Instance.TryGetViewModel(controller, arg1, arg2, arg3, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3>.Instance.TryGetViewModelAsync(controller, arg1, arg2, arg3);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2, T3, T4>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4>.Instance.TryGetViewModel(controller, arg1, arg2, arg3, arg4, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4>.Instance.TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5>.Instance.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5>.Instance.TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5, T6>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6>.Instance.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6>.Instance.TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5, T6, T7>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7>.Instance.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7>.Instance.TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7);


        /// <inheritdoc cref="IViewModelFactory.TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        public virtual bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, [MaybeNull, NotNullWhen(true)] out TViewModel model) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>.Instance.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, out model);

        /// <inheritdoc cref="IViewModelFactory.TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>.Instance.TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }
}