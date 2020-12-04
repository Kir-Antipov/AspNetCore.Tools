using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace AspNetCore.Tools.ViewModels.Internal
{
    internal abstract class ViewModelBuilderWrapper<TViewModel> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel> Instance = Create<ViewModelBuilderWrapper<TViewModel>>();

        public virtual bool TryGetViewModel(ControllerBase controller, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller)
        {
            bool success = TryGetViewModel(controller, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1)
        {
            bool success = TryGetViewModel(controller, arg1, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2, T3> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2, T3> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2, T3>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2, arg3).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, arg3, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, arg3, arg4, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }

    internal abstract class ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8> : ViewModelBuilderWrapper
    {
        public static ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8> Instance = Create<ViewModelBuilderWrapper<TViewModel, T1, T2, T3, T4, T5, T6, T7, T8>>();

        public virtual bool TryGetViewModel(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, [MaybeNull, NotNullWhen(true)] out TViewModel model)
        {
            var (success, result) = TryGetViewModelAsync(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8).Result;
            model = result!;
            return success;
        }

        public virtual Task<(bool success, TViewModel model)> TryGetViewModelAsync(ControllerBase controller, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            bool success = TryGetViewModel(controller, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, out TViewModel model);
            return Task.FromResult((success, model!));
        }
    }
}