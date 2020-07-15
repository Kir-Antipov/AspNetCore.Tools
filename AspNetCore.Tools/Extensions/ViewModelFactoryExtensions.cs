using AspNetCore.Tools.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetCore.Tools.Extensions
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) helpful methods for objects
    /// that implement <see cref="IViewModelFactory"/>.
    /// </summary>
    public static class ViewModelFactoryExtensions
    {
        private static Exception GetExceptionFor<TViewModel>() => new InvalidOperationException($"An attempt to create {typeof(TViewModel).FullName} was unsuccessful.");

        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel>(this IViewModelFactory factory, ControllerBase controller) =>
            factory.TryGetViewModel(controller, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel>(this IViewModelFactory factory, ControllerBase controller, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel>(this IViewModelFactory factory, ControllerBase controller, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel>(this IViewModelFactory factory, ControllerBase controller) =>
            await factory.TryGetViewModelAsync<TViewModel>(controller) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel>(this IViewModelFactory factory, ControllerBase controller, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel>(this IViewModelFactory factory, ControllerBase controller, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel>(controller) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1>(this IViewModelFactory factory, ControllerBase controller, T1 arg1) =>
            factory.TryGetViewModel(controller, arg1, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1>(this IViewModelFactory factory, ControllerBase controller, T1 arg1) =>
            await factory.TryGetViewModelAsync<TViewModel, T1>(controller, arg1) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1>(controller, arg1) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2) =>
            factory.TryGetViewModel(controller, arg1, arg2, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2>(controller, arg1, arg2) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2>(controller, arg1, arg2) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2, T3>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, arg3, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2, T3>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3>(controller, arg1, arg2, arg3) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, arg3, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3>(controller, arg1, arg2, arg3) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2, T3, T4>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, arg3, arg4, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2, T3, T4>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4>(controller, arg1, arg2, arg3, arg4) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, arg3, arg4, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4>(controller, arg1, arg2, arg3, arg4) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2, T3, T4, T5>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, arg3, arg4, arg5, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2, T3, T4, T5>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5>(controller, arg1, arg2, arg3, arg4, arg5) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, arg3, arg4, arg5, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5>(controller, arg1, arg2, arg3, arg4, arg5) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2, T3, T4, T5, T6>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5, T6>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, arg3, arg4, arg5, arg6, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5, T6>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6>(controller, arg1, arg2, arg3, arg4, arg5, arg6) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5, T6>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5, T6>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6>(controller, arg1, arg2, arg3, arg4, arg5, arg6) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <inheritdoc cref="GetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2, T3, T4, T5, T6, T7>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5, T6, T7>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <inheritdoc cref="GetActionResult{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5, T6, T7>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7) is (true, TViewModel model) ? onSuccess(model) : onFailure();


        /// <returns>The <typeparamref name="TViewModel"/> instance.</returns>
        /// <inheritdoc cref="GetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        public static TViewModel GetViewModel<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, out TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <returns>The <see cref="IActionResult"/> provided by the <paramref name="onSuccess"/> callback.</returns>
        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResult(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, onSuccess, () => throw GetExceptionFor<TViewModel>());
        
        /// <returns>The <see cref="IActionResult"/> provided by one of the callbacks (<paramref name="onSuccess"/> or <paramref name="onFailure"/>).</returns>
        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static IActionResult GetActionResult<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            factory.TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, out TViewModel model) ? onSuccess(model) : onFailure();
                
        /// <summary>
        /// Obtains <typeparamref name="TViewModel"/> from the presented data.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static async Task<TViewModel> GetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) is (true, TViewModel model) ? model : throw GetExceptionFor<TViewModel>();

        /// <summary>
        /// If <typeparamref name="TViewModel"/> was successfully obtained,
        /// passes it to the <paramref name="onSuccess"/> callback;
        /// otherwise it throws the <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <inheritdoc cref="GetActionResultAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(IViewModelFactory, ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, Func{TViewModel, IActionResult}, Func{IActionResult})"/>
        public static Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Func<TViewModel, IActionResult> onSuccess) =>
            factory.GetActionResultAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, onSuccess, () => throw GetExceptionFor<TViewModel>());

        /// <summary>
        /// If <typeparamref name="TViewModel"/> was successfully obtained,
        /// passes it to the <paramref name="onSuccess"/> callback;
        /// otherwise it calls the <paramref name="onFailure"/> callback.
        /// </summary>
        /// <param name="factory">The <see cref="IViewModelFactory"/> instance.</param>
        /// <param name="controller">The controller with which the processing of the presented data is associated.</param>
        /// <param name="onSuccess">Callback that will be called if the model was successfully obtained.</param>
        /// <param name="onFailure">Callback that will be called if the model wasn't obtained.</param>
        /// <typeparam name="TViewModel">ViewModel type.</typeparam>
        /// <returns>A <see cref="Task"/> that represents the completion of request processing.</returns>
        /// <typeparam name="T1">The 1st parameter's type.</typeparam>
        /// <param name="arg1">The 1st parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T2">The 2nd parameter's type.</typeparam>
        /// <param name="arg2">The 2nd parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T3">The 3rd parameter's type.</typeparam>
        /// <param name="arg3">The 3rd parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T4">The 4th parameter's type.</typeparam>
        /// <param name="arg4">The 4th parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T5">The 5th parameter's type.</typeparam>
        /// <param name="arg5">The 5th parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T6">The 6th parameter's type.</typeparam>
        /// <param name="arg6">The 6th parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T7">The 7th parameter's type.</typeparam>
        /// <param name="arg7">The 7th parameter to be passed to ViewModelBuilder.</param>
        /// <typeparam name="T8">The 8th parameter's type.</typeparam>
        /// <param name="arg8">The 8th parameter to be passed to ViewModelBuilder.</param>
        public static async Task<IActionResult> GetActionResultAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(this IViewModelFactory factory, ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Func<TViewModel, IActionResult> onSuccess, Func<IActionResult> onFailure) =>
            await factory.TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) is (true, TViewModel model) ? onSuccess(model) : onFailure();
    }
}