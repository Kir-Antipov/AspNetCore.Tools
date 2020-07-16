using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ViewModels
{
    /// <summary>
    /// Basic interface for view model factory.
    /// </summary>
    public interface IViewModelFactory
    {
        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel>(ControllerBase controller, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel>(ControllerBase controller);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1>(ControllerBase controller, T1 arg1, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1>(ControllerBase controller, T1 arg1);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1, T2>(ControllerBase controller, T1 arg1, T2 arg2, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2>(ControllerBase controller, T1 arg1, T2 arg2);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1, T2, T3>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1, T2, T3, T4>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5, T6>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);


        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5, T6, T7>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <inheritdoc cref="TryGetViewModelAsync{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);


        /// <summary>
        /// Attempts to obtain <typeparamref name="TViewModel"/> from the presented data.
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel type.</typeparam>
        /// <param name="model">
        /// When this method returns, contains the <typeparamref name="TViewModel"/> ViewModel, if the processing succeeded.
        /// </param>
        /// <param name="controller">The controller with which the processing of the presented data is associated.</param>
        /// <returns><see langword="true"/> if the processing succeeded; otherwise, <see langword="false"/>.</returns>
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
        bool TryGetViewModel<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, [MaybeNull, NotNullWhen(true)] out TViewModel model);

        /// <returns>A <see cref="Task"/> that represents the completion of request processing.</returns>
        /// <inheritdoc cref="TryGetViewModel{TViewModel, T1, T2, T3, T4, T5, T6, T7, T8}(ControllerBase, T1, T2, T3, T4, T5, T6, T7, T8, out TViewModel)"/>
        Task<(bool success, TViewModel model)> TryGetViewModelAsync<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
    }
}